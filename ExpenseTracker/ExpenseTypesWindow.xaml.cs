using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataAccess;

namespace ExpenseTracker
{
    /// <summary>
    /// Interaction logic for ExpenseTypesWindow.xaml
    /// </summary>
    public partial class ExpenseTypesWindow : Window
    {
        private ExpenseContext _expenseContext = new ExpenseContext();
        private List<ExpenseType> _expenseTypes;
        private int _selectedIndex = -1;

        public ExpenseTypesWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _expenseTypes = _expenseContext.ExpenseTypes.ToList();
            expenseTypesDataGrid.ItemsSource = _expenseTypes;
            GoFirst();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddExpenseTypeWindow addWindow = new AddExpenseTypeWindow();
                var result = addWindow.ShowDialog();

                if (result == false)
                    return;

                ExpenseType newExpenseType = addWindow.ExpenseType;

                _expenseTypes.Add(newExpenseType);
                _expenseContext.ExpenseTypes.Add(newExpenseType);
                _expenseContext.SaveChanges();

                expenseTypesDataGrid.Items.Refresh();

            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message);

            }
        }

        private void FirstButton_Click(object sender, RoutedEventArgs e)
        {
            GoFirst();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedIndex == _expenseTypes.Count - 1)
                return;

            _selectedIndex += 1;
            expenseTypesDataGrid.SelectedItem = _expenseTypes[_selectedIndex];

        }

        private void LastButton_Click(object sender, RoutedEventArgs e)
        {
            if (_expenseTypes.Count == 0)
                return;
            expenseTypesDataGrid.SelectedItem = _expenseTypes.Last();
            _selectedIndex = _expenseTypes.Count - 1;

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_expenseTypes.Count == 0)
                return;

            MessageBoxResult messageBoxResult = MessageBox.Show
                ("The selected item will be removed.", "Delete", MessageBoxButton.OKCancel);

            if (messageBoxResult == MessageBoxResult.Cancel)
                return;

            var selectedRow = _expenseTypes[_selectedIndex];
            _expenseTypes.Remove(selectedRow);
            expenseTypesDataGrid.Items.Refresh();

            _expenseContext.ExpenseTypes.Remove(selectedRow);
            _expenseContext.SaveChanges();

        }

        private void GoFirst()
        {
            if (_expenseTypes.Count == 0)
                return;

            expenseTypesDataGrid.SelectedItem = _expenseTypes.First();
            _selectedIndex = 0;

        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedIndex <= 0)
                return;

            _selectedIndex -= 1;

            expenseTypesDataGrid.SelectedItem = _expenseTypes[_selectedIndex];

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = _expenseTypes[_selectedIndex];

            EditWindow editWindow = new EditWindow(selectedRow);
            var result = editWindow.ShowDialog();

            if (result == false)
                return;

            //editing local list
            selectedRow = editWindow.Model;

            //editing database
            var oldRecord = _expenseContext.ExpenseTypes
                 .Where(x => x.Id == selectedRow.Id)
                 .FirstOrDefault();
            _expenseContext.Entry(oldRecord).CurrentValues.SetValues(selectedRow);
            _expenseContext.SaveChanges();

            expenseTypesDataGrid.Items.Refresh();
        }

        private void expenseTypesDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            _selectedIndex = expenseTypesDataGrid.SelectedIndex;

        }
    }
}
