using System.Linq;
using System.Windows;
using DataAccess;

namespace ExpenseTracker
{
    public partial class ExpensesWindow : BaseListWindow<Expense, AddEditExpenseWindow>
    {
        public ExpensesWindow() :
            base(new ExpenseRepository())
        {
            InitializeComponent();
            Initialize(expensesDataGrid);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            expensesDataGrid.ItemsSource = List;
            GoFirst();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddClick();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditClick();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteClick();
        }

    }


}
