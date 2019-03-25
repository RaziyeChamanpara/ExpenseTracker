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
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public ExpenseType Model { get; set; }
        public string EditedName { get; set; }

        public EditWindow(ExpenseType expenseType)
        {
            InitializeComponent();

            Model = expenseType;

            editNameTextBox.Text = Model.Name;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Model.Name = editNameTextBox.Text;
            this.DialogResult = true;

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
