using DataAccess;
using System.Windows;

namespace ExpenseTracker
{
    public partial class AddEditExpenseTypeWindow : BaseModifyWindow<ExpenseType>
    {
        public AddEditExpenseTypeWindow() : base(new ExpenseType())
        {
            InitializeComponent();
        }

        public override bool? ShowForAdd()
        {
            this.Title = "Add Expense Type";
            return this.ShowDialog();
        }

        public override bool? ShowForEdit(ExpenseType expenseType)
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
