using System;
using System.Windows;
using DataAccess;

namespace ExpenseTracker
{
    public abstract class BaseModifyWindow<TEntity> : Window
    {
        public TEntity Model;
        public BaseModifyWindow(TEntity model)
        {
            Model = model;
        }

        public abstract bool? ShowForAdd();

        public abstract bool? ShowForEdit(TEntity oldRecord);

        protected void CancelButton()
        {
            this.DialogResult = false;
            this.Hide();
        }
    }
}
