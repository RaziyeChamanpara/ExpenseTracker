using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DataAccess;

namespace ExpenseTracker
{
    public class BaseListWindow<TEntity> : Window where TEntity :IEntity
    {
        protected readonly IRepository<TEntity> Repository;
        protected List<TEntity> List = new List<TEntity>();
        DataGrid DataGrid;
        BaseModifyWindow<TEntity> ModifyWindow;
        protected int selectedIndex = -1;
        protected TEntity selectedRecord;

        public BaseListWindow(IRepository<TEntity> repository, BaseModifyWindow<TEntity> modifyWindow)
        {
            Initialize(DataGrid);
            Repository = repository;
            ModifyWindow = modifyWindow;
            this.Loaded += BaseListWindow_Loaded;
        }
        protected void Initialize(DataGrid dataGrid)
        {
            DataGrid = dataGrid;
        }
        private void BaseListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List = Repository.GetAll();

        }
        protected void AddClick()
        {
            bool? result = ModifyWindow.ShowForAdd();

            if (result == false)
                return;

            TEntity newRecord = ModifyWindow.Model;

            Repository.Add(newRecord);
            List.Add(newRecord);
            DataGrid.Items.Refresh();
        }
        protected void EditClick()
        {
            selectedIndex = DataGrid.SelectedIndex;

            if (selectedIndex == -1)
            {
                MessageBox.Show("Please choose a row for edit.");
                return;
            }

            selectedRecord = List[selectedIndex];
            bool? result = ModifyWindow.ShowForEdit(selectedRecord);
            if (result == false)
                return;

            Repository.Update(selectedRecord);
            List[selectedIndex] = ModifyWindow.Model;
            DataGrid.Items.Refresh();
        }
        protected void DeleteClick()
        {
            if (List.Count() == 0)
            {
                return;
            }

            selectedRecord = List[selectedIndex];

            MessageBoxResult messageBoxResult = MessageBox
                .Show(selectedRecord.Name + " will be removed.", "Delete", MessageBoxButton.OKCancel);

            if (messageBoxResult == MessageBoxResult.Cancel)
                return;

            Repository.Remove(selectedRecord.Id);
            List.Remove(selectedRecord);
            DataGrid.Items.Refresh();
        }
    }
}

