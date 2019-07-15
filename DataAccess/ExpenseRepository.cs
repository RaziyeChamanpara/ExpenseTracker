using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ExpenseRepository : IRepository<Expense>
    {
        public void Add(Expense entity)
        {
            using (ExpenseContext db = new ExpenseContext())
            {
                db.Expenses.Add(entity);
                db.SaveChanges();
            }
        }

        public Expense Get(int id)
        {
            using (ExpenseContext db = new ExpenseContext())

                return db.Expenses
                        .Where(x => x.Id == id)
                        .FirstOrDefault();
        }

        public List<Expense> GetAll()
        {
            using (ExpenseContext db = new ExpenseContext())
                return db.Expenses.Include("ExpenseType").ToList();
        }

        public void Update(Expense newRecord)
        {
            using (ExpenseContext db = new ExpenseContext())
            {
                var oldRecord = db.Expenses.Where(x => x.Id == newRecord.Id).FirstOrDefault();

                db.Entry(oldRecord).CurrentValues.SetValues(newRecord);

                db.SaveChanges();
            }

        }

        public void Remove(int id)
        {
            using (ExpenseContext db = new ExpenseContext())
            {
                var expense=db.Expenses.Where(x => x.Id == id).FirstOrDefault();
                db.Expenses.Remove(expense);
                db.SaveChanges();
            }
        }
    }
}
