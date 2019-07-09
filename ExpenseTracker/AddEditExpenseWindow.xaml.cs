using System;
using System.Collections.Generic;
using System.Windows;
using DataAccess;

namespace ExpenseTracker
{
    /// <summary>
    /// Interaction logic for EditExpense.xaml
    /// </summary>
    public partial class AddEditExpenseWindow : Window
    {
        private ExpenseTypeRepository ExpenseTypeRepository { get; set; } = new ExpenseTypeRepository();
        private List<ExpenseType> _expenseTypes = new List<ExpenseType>();
        public Expense Model = new Expense();

        public AddEditExpenseWindow()
        {
            InitializeComponent();
            _expenseTypes = ExpenseTypeRepository.GetAll();

        }

        public bool? ShowForAdd()
        {
            groupBox.Header = "Add";
            return this.ShowDialog();
        }

        public bool? ShowForEdit(Expense oldExpense)
        {
            Model = oldExpense;
            groupBox.Header = "Edit";
            return this.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            expenseTypeComboBox.ItemsSource = _expenseTypes;

            amountTextBox.Text = Model.Amount.ToString();
            descriptionTextBox.Text = Model.Description;
            expenseTypeComboBox.SelectedValue = Model.ExpenseTypeId;
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
            Model.ExpenseTypeName = (expenseTypeComboBox.SelectedItem as ExpenseType).Name;
            Model.ExpenseTypeId = (int)expenseTypeComboBox.SelectedValue;

            this.DialogResult = true;
        }
    }
}
