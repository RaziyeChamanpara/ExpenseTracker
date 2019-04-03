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
    /// Interaction logic for AddExpenseWindow.xaml
    /// </summary>
    public partial class AddExpenseWindow : Window
    {
        public Expense Model { get; set; }
        private ExpenseContext _expenseContext = new ExpenseContext();
        private List<ExpenseType> _expenseTypes = new List<ExpenseType>();
        private ExpenseType _expenseType = new ExpenseType();

        public AddExpenseWindow()
        {
            InitializeComponent();
            Model = new Expense();
            _expenseTypes = _expenseContext.ExpenseTypes.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            expensetypeComboBox.ItemsSource = _expenseTypes;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (expensetypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Choose the expense type");
                return;
            }
            if (descriptionTextBox.Text == "")
            {
                MessageBox.Show("Fill the Description");
                return;
            }
            if (calendar.SelectedDate == null)
            {
                MessageBox.Show("Choose a date");
                return;
            }
            if (amountTextBox.Text == "")
            {
                MessageBox.Show("Fill the Amount");
                return;
            }

            Model.ExpenseTypeId = (int)expensetypeComboBox.SelectedValue;
            Model.ExpenseType = expensetypeComboBox.SelectedItem as ExpenseType;
            Model.Description = descriptionTextBox.Text;
            Model.Date = calendar.SelectedDate.Value;
            Model.Amount = Convert.ToInt32(amountTextBox.Text);

            this.DialogResult = true;

        }

    }
}
