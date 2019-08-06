using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DataAccess;

namespace ExpenseTracker
{
    public partial class ExpenseTypesWindow : Window
    {
        private ExpenseTypeRepository ExpenseTypeRepository { get; set; } = new ExpenseTypeRepository();
        private List<ExpenseType> _expenseTypes;
        private int _selectedIndex = -1;

        public ExpenseTypesWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _expenseTypes = ExpenseTypeRepository.GetAll();
            expenseTypesDataGrid.ItemsSource = _expenseTypes;
            GoFirst();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddEditExpenseTypeWindow addWindow = new AddEditExpenseTypeWindow();
                var result = addWindow.ShowForAdd();

                if (result == false)
                    return;

                ExpenseType newExpenseType = addWindow.Model;
                ExpenseTypeRepository.Add(newExpenseType);
                _expenseTypes.Add(newExpenseType);
                expenseTypesDataGrid.Items.Refresh();

            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = _expenseTypes[_selectedIndex];

            AddEditExpenseTypeWindow editWindow = new AddEditExpenseTypeWindow();
            var result = editWindow.ShowForEdit(selectedRow);

            if (result == false)
                return;

            selectedRow = editWindow.Model;

            ExpenseTypeRepository.Update(selectedRow);
            _expenseTypes[_selectedIndex] = selectedRow;
            expenseTypesDataGrid.Items.Refresh();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_expenseTypes.Count == 0)
                return;

            MessageBoxResult messageBoxResult = MessageBox.Show
                ("The selected item will be removed."
                , "Delete", MessageBoxButton.OKCancel);

            if (messageBoxResult == MessageBoxResult.Cancel)
                return;

            var selectedRow = _expenseTypes[_selectedIndex];
            ExpenseTypeRepository.Remove(selectedRow.Id);
            _expenseTypes.Remove(selectedRow);
            expenseTypesDataGrid.Items.Refresh();

        }

        private void GoFirst()
        {
            if (_expenseTypes.Count == 0)
                return;

            expenseTypesDataGrid.SelectedItem = _expenseTypes.First();
            _selectedIndex = 0;
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

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedIndex <= 0)
                return;

            _selectedIndex -= 1;

            expenseTypesDataGrid.SelectedItem = _expenseTypes[_selectedIndex];

        }

        private void ExpenseTypesDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            _selectedIndex = expenseTypesDataGrid.SelectedIndex;

        }
    }
}
