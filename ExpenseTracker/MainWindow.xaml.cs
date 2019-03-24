using DataAccess;
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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace ExpenseTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ExpenseContext _expenseContext = new ExpenseContext();
        private List<ExpenseType> _expenseTypes;
        private int _selectedIndex = -1;
        private ExpenseType _selectedItem = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _expenseTypes = _expenseContext.ExpenseTypes.ToList();
            dataGrid.ItemsSource = _expenseTypes;
            GoFirst();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddWindow addWindow = new AddWindow();
                var resultDialog = addWindow.ShowDialog();

                if (resultDialog == false)
                    return;

                var newExpenseType = addWindow.ExpenseType;

                _expenseTypes.Add(newExpenseType);
                _expenseContext.ExpenseTypes.Add(newExpenseType);
                _expenseContext.SaveChanges();

                dataGrid.Items.Refresh();

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
            dataGrid.SelectedItem = _expenseTypes[_selectedIndex];

        }

        private void LastButton_Click(object sender, RoutedEventArgs e)
        {
            if (_expenseTypes.Count == 0)
                return;
            dataGrid.SelectedItem = _expenseTypes.Last();
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

            _selectedItem = _expenseTypes[_selectedIndex];
            _expenseTypes.Remove(_selectedItem);
            dataGrid.Items.Refresh();

            _expenseContext.ExpenseTypes.Remove(_selectedItem);
            _expenseContext.SaveChanges();

        }

        private void GoFirst()
        {
            if (_expenseTypes.Count == 0)
                return;

            dataGrid.SelectedItem = _expenseTypes.First();
            _selectedIndex = 0;

        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedIndex <= 0)
                return;

            _selectedIndex -= 1;

            dataGrid.SelectedItem = _expenseTypes[_selectedIndex];

        }
    }
}
