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


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _expenseTypes = _expenseContext.ExpenseTypes.ToList();
            dataGrid.ItemsSource = _expenseTypes;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _expenseContext.ExpenseTypes.Add(new ExpenseType() { Id = 1, Name = "daily" });
                MessageBox.Show("Added");
                _expenseContext.SaveChanges();

            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message);
            }
        }
        
    }
}
