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
    /// Interaction logic for ExpensesWindow.xaml
    /// </summary>
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
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddExpenseWindow addExpenseWindow = new AddExpenseWindow();
            var result = addExpenseWindow.ShowDialog();
            if (result == false)
                return;

            var newExpense = new Expense();
            newExpense = addExpenseWindow.Model;

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

            EditExpenseWindow editExpenseWindow = new EditExpenseWindow(_selectedRecord);
            var result = editExpenseWindow.ShowDialog();
            if (result == false)
                return;


            ExpenseRepository.Update(_selectedRecord);

            _expenses[_selectedIndex] = editExpenseWindow.Model;

            expensesDataGrid.Items.Refresh();
        }
    }

}
