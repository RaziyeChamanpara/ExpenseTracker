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
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExpenseContext expenseContext = new ExpenseContext();
                expenseContext.ExpenseTypes.Add(new ExpenseType() { Id = 3, Name = "utilities" });
                expenseContext.ExpenseTypes.Add(new ExpenseType() { Id = 4, Name = "daily" });

                expenseContext.SaveChanges();
                MessageBox.Show("Added");

                List<ExpenseType> expenseTypes= expenseContext.ExpenseTypes.ToList();
                dataGrid.ItemsSource = expenseTypes;


            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
    }
}
