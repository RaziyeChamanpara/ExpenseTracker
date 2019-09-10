using System.Linq;
using System.Windows;
using DataAccess;

namespace ExpenseTracker
{
    public partial class ExpensesWindow : BaseListWindow<Expense>
    {
        public ExpensesWindow() :
            base(new ExpenseRepository(), new AddEditExpenseWindow())
        {
            InitializeComponent();
            Initialize(expensesDataGrid);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            expensesDataGrid.ItemsSource = List;
            expensesDataGrid.SelectedItem = List.First();
            selectedIndex = 0;
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
