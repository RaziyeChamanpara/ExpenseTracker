using System.Windows;
using ExpenseTrackerComponents;


namespace ExpenseTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExpensesButton_Click(object sender, RoutedEventArgs e)
        {
            ExpensesWindow expensesWindow = new ExpensesWindow();
            expensesWindow.Show();

        }

        private void ExpenseTypesButton_Click(object sender, RoutedEventArgs e)
        {
            ExpenseTypesWindow expenseTypesWindow = new ExpenseTypesWindow();
            expenseTypesWindow.Show();
        }
    }
}
