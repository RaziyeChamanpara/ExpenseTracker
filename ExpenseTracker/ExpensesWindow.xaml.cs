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
        private List<Expense> _expenses=new List<Expense>();
        ExpenseRepository ExpenseRepository { get; set; } = new ExpenseRepository();

        public ExpensesWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            expensesDataGrid.ItemsSource = ExpenseRepository.GetAll();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddExpenseWindow addExpenseWindow = new AddExpenseWindow();
            var result = addExpenseWindow.ShowDialog();
            if (result == false)
                return;

            var newExpense = new Expense();
            newExpense = addExpenseWindow.Model;

            _expenses.Add(newExpense);
            expensesDataGrid.Items.Refresh();

            var expenseContext = new ExpenseContext();
            expenseContext.Expenses.Add(newExpense);
            expenseContext.SaveChanges();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedIndex = expensesDataGrid.SelectedIndex;
            if (_selectedIndex == -1)
            {
                MessageBox.Show("Please choose a row for edit.");
                return;
            }

            var _editingRow = _expenses[_selectedIndex];

            EditExpenseWindow editExpenseWindow = new EditExpenseWindow(_editingRow);
            var result = editExpenseWindow.ShowDialog();
            if (result == false)
                return;


            var expenseContext = new ExpenseContext();

            _editingRow = editExpenseWindow.Model;
            expensesDataGrid.Items.Refresh();



            var _oldRecord = expenseContext.Expenses
                 .Where(x => x.Id == _editingRow.Id)
                 .FirstOrDefault();

            expenseContext.Entry(_oldRecord).CurrentValues.SetValues(_editingRow);
            expenseContext.SaveChanges();





            ExpenseRepository.Add(newExpense);
        }
    }

}
