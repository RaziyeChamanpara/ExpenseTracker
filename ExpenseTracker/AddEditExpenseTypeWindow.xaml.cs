using DataAccess;
using System.Windows;

namespace ExpenseTracker
{
    public partial class AddEditExpenseTypeWindow : Window
    {
        public ExpenseType Model { get; set; } = new ExpenseType();

        public AddEditExpenseTypeWindow()
        {
            InitializeComponent();
        }

        public bool? ShowForAdd()
        {
            this.Title = "Add Expense Type";
            return this.ShowDialog();
        }

        public bool? ShowForEdit(ExpenseType expenseType)
        {
            Model = expenseType;
            this.Title = "Edit Expense Type";
            nameTextBox.Text = expenseType.Name;
            return this.ShowDialog();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            if (name == "")
            {
                MessageBox.Show("Choose a name");
                return;
            }

            Model.Name = name;

            this.DialogResult = true;

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

    }
}
