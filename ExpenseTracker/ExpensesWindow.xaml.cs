using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataAccess;

namespace ExpenseTracker
{
    public partial class ExpensesWindow : Window
    {
        ExpenseRepository ExpenseRepository { get; set; } = new ExpenseRepository();
        private List<Expense> _expenses = new List<Expense>();
        private int _selectedIndex = -1;

        public ExpensesWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _expenses = ExpenseRepository.GetAll();
            expensesDataGrid.ItemsSource = _expenses;
            expensesDataGrid.SelectedItem = _expenses.First();
            _selectedIndex = 0;

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow= new AddEditExpenseWindow();
            bool? result = addWindow.ShowForAdd();

            if (result == false)
                return;

            Expense newExpense = addWindow.Model;
            ExpenseRepository.Add(newExpense);
            _expenses.Add(newExpense);
            expensesDataGrid.Items.Refresh();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedIndex = expensesDataGrid.SelectedIndex;

            if (_selectedIndex == -1)
            {
                MessageBox.Show("Please choose a row for edit.");
                return;
            }

            var _selectedRecord = _expenses[_selectedIndex];

            AddEditExpenseWindow editWindow = new AddEditExpenseWindow();

            var result = editWindow.ShowForEdit(_selectedRecord);

            if (result == false)
                return;

            ExpenseRepository.Update(_selectedRecord);
            _expenses[_selectedIndex] = editWindow.Model;
            expensesDataGrid.Items.Refresh();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_expenses.Count() == 0)
                return;

            Expense selectedRow = _expenses[_selectedIndex];

            MessageBoxResult messageBoxResult = MessageBox
                .Show(selectedRow.Description + " will be removed." , "Delete", MessageBoxButton.OKCancel);

            if (messageBoxResult == MessageBoxResult.Cancel)
                return;

            ExpenseRepository.Remove(selectedRow.Id);
            _expenses.Remove(selectedRow);
            expensesDataGrid.Items.Refresh();
        }

    }


}
