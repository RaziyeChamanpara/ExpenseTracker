using System;
using System.Windows;
using DataAccess;

namespace ExpenseTracker
{
    public abstract class BaseModifyWindow<T>:Window
    {
        public T Model;
        public BaseModifyWindow(T model)
        {
            Model = model;
        }
        public abstract bool? ShowForAdd();

        public abstract bool? ShowForEdit(T oldRecord);
    }
}
