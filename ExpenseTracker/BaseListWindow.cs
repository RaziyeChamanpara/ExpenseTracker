using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DataAccess;

namespace ExpenseTracker
{
    public class BaseListWindow<TEntity, ModifyWindowType> : Window
        where ModifyWindowType : BaseModifyWindow<TEntity>
        where TEntity : IEntity
    {
        protected readonly IRepository<TEntity> Repository;
        protected List<TEntity> List = new List<TEntity>();
        protected DataGrid DataGrid;
        protected int selectedIndex = -1;
        protected TEntity selectedRecord;

        public BaseListWindow(IRepository<TEntity> repository)
        {
            Initialize(DataGrid);
            Repository = repository;
            this.Loaded += BaseListWindow_Loaded;
            List = Repository.GetAll();

        }

        protected void Initialize(DataGrid dataGrid)
        {
            DataGrid = dataGrid;
        }

        private void BaseListWindow_Loaded(object sender, RoutedEventArgs e)
        {


        }

        protected void AddClick()
        {
            var modifyWindow = Activator.CreateInstance<ModifyWindowType>();

            bool? result = modifyWindow.ShowForAdd();

            if (result == false)
                return;

            TEntity newRecord = modifyWindow.Model;

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
            var modifyWindow = Activator.CreateInstance<ModifyWindowType>();
            selectedRecord = List[selectedIndex];
            bool? result = modifyWindow.ShowForEdit(selectedRecord);
            if (result == false)
                return;

            Repository.Update(selectedRecord);
            List[selectedIndex] = modifyWindow.Model;
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

        protected void GoFirst()
        {
            if (List.Count == 0)
                return;

            DataGrid.SelectedItem = List.First();
            selectedIndex = 0;
        }

        protected void FirstClick()
        {
            GoFirst();

        }

        protected void NextClick()
        {

            if (selectedIndex == List.Count - 1)
                return;

            selectedIndex += 1;
            DataGrid.SelectedItem = List[selectedIndex];
        }

        protected void LastClick()
        {
            if (List.Count == 0)
                return;

            DataGrid.SelectedItem = List.Last();
            selectedIndex = List.Count - 1;
        }

        protected void PreviouseClick()
        {
            if (selectedIndex <= 0)
                return;

            selectedIndex -= 1;

            DataGrid.SelectedItem = List[selectedIndex];
        }
    }
}

