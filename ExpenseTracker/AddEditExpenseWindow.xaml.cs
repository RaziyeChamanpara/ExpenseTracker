using System;
using System.Collections.Generic;
using System.Windows;
using DataAccess;

namespace ExpenseTracker
{
    public partial class AddEditExpenseWindow : BaseModifyWindow<Expense>
    {
        private ExpenseTypeRepository ExpenseTypeRepository { get; set; } = new ExpenseTypeRepository();
        private List<ExpenseType> _expenseTypes = new List<ExpenseType>();
       

        public AddEditExpenseWindow():base(new Expense())
        {
            InitializeComponent();
            _expenseTypes = ExpenseTypeRepository.GetAll();

        }

        public override  bool? ShowForAdd()
        {
            groupBox.Header = "Add";
            return this.ShowDialog();
        }

        public override bool? ShowForEdit(Expense oldExpense)
        {
            Model = oldExpense;
            groupBox.Header = "Edit";
            return this.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            expenseTypeComboBox.ItemsSource = _expenseTypes;

            amountTextBox.Text = Model.Amount.ToString();
            descriptionTextBox.Text = Model.Name;
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
            Model.Name = descriptionTextBox.Text;
            Model.ExpenseTypeName = (expenseTypeComboBox.SelectedItem as ExpenseType).Name;
            Model.ExpenseTypeId = (int)expenseTypeComboBox.SelectedValue;

            this.DialogResult = true;
        }
    }
}
