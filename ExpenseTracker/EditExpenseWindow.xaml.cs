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
    /// Interaction logic for EditExpense.xaml
    /// </summary>
    public partial class EditExpenseWindow : Window
    {
        private List<ExpenseType> _expenseTypes = new List<ExpenseType>();
        private ExpenseContext _expenseContext = new ExpenseContext();
        public Expense Model = new Expense();
        public EditExpenseWindow( Expense expense)
        {
            InitializeComponent();
            _expenseTypes = _expenseContext.ExpenseTypes.ToList();
            Model = expense;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            expenseTypeComboBox.ItemsSource = _expenseTypes;

            amountTextBox.Text = Model.Amount.ToString();
            descriptionTextBox.Text = Model.Description;
            expenseTypeComboBox.SelectedValue= Model.ExpenseType.Id;
            expenseDatePicker.SelectedDate = Model.Date;

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (descriptionTextBox.Text == "")
            {
                MessageBox.Show("Please fill the Discrption.");
                return;
            }
            if (expenseTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("please choose an expense type.");
                return;
            }
            if (expenseDatePicker.Text == "")
            {
                MessageBox.Show("please choose a date.");
                return;
            }
            if (amountTextBox.Text == "")
            {
                MessageBox.Show("Please fill the amount.");
                return;
            }
            Model.Amount = Convert.ToInt32(amountTextBox.Text);
            Model.Date = expenseDatePicker.SelectedDate.GetValueOrDefault();
            Model.Description = descriptionTextBox.Text;
            Model.ExpenseType = expenseTypeComboBox.SelectedItem as ExpenseType;
            Model.ExpenseTypeId = (int)expenseTypeComboBox.SelectedValue ;

            this.DialogResult = true;
        }
    }
}
