using System;
using System.Windows;
using System.Windows.Controls;
using DataAccess;

namespace ExpenseTracker
{
    public partial class ExpenseTypesWindow : BaseListWindow<ExpenseType, AddEditExpenseTypeWindow>
    {

        public ExpenseTypesWindow()
            : base(new ExpenseTypeRepository())
        {
            InitializeComponent();
            Initialize(expenseTypesDataGrid);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            expenseTypesDataGrid.ItemsSource = List;
            GoFirst();
                     
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddClick();
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditClick();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteClick();
        }

       
        private void FirstButton_Click(object sender, RoutedEventArgs e)
        {
            FirstClick();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            NextClick();

        }

        private void LastButton_Click(object sender, RoutedEventArgs e)
        {
            LastClick();

        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            PreviouseClick();

        }

        private void ExpenseTypesDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            selectedIndex = expenseTypesDataGrid.SelectedIndex;

        }
    }
}
