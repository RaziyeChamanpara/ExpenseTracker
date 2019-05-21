using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ExpenseRepository : IRepository<Expense>
    {
        private ExpenseContext _expenseContext = new ExpenseContext();

        public void Add(Expense entity)
        {
            _expenseContext.Expenses.Add(entity);
            _expenseContext.SaveChanges();
        }

        public void Remove(Expense entity)
        {
            _expenseContext.Expenses.Remove(entity);
            _expenseContext.SaveChanges();
        }

        public Expense Get(int id)
        {
            return _expenseContext.Expenses
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public List<Expense> GetAll()
        {
            return _expenseContext.Expenses.ToList();
        }

    }
}
