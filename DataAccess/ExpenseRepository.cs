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
            using (ExpenseTrackerContext db = new ExpenseTrackerContext())
            {
                db.Expenses.Add(entity);
                db.SaveChanges();
            }
        }

        public Expense Get(int id)
        {
            using (ExpenseTrackerContext db = new ExpenseTrackerContext())

                return db.Expenses
                        .Where(x => x.Id == id)
                        .FirstOrDefault();
        }

        public List<Expense> GetAll()
        {
            using (ExpenseTrackerContext db = new ExpenseTrackerContext())
                return db.Expenses.Include("ExpenseType").ToList();
        }

        public void Update(Expense newRecord)
        {
            using (ExpenseTrackerContext db = new ExpenseTrackerContext())
            {
                var oldRecord = db.Expenses.Where(x => x.Id == newRecord.Id).FirstOrDefault();

                db.Entry(oldRecord).CurrentValues.SetValues(newRecord);

                db.SaveChanges();
            }

        }

        public void Remove(int id)
        {
            using (ExpenseTrackerContext db = new ExpenseTrackerContext())
            {
                var expense=db.Expenses.Where(x => x.Id == id).FirstOrDefault();
                db.Expenses.Remove(expense);
                db.SaveChanges();
            }
        }
    }
}
