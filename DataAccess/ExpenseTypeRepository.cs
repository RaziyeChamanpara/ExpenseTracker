using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class ExpenseTypeRepository : IRepository<ExpenseType>
    {
        public void Add(ExpenseType expenseType)
        {
            using (ExpenseTrackerContext db = new ExpenseTrackerContext())
            {
                db.ExpenseTypes.Add(expenseType);
                db.SaveChanges();
            }
        }

        public ExpenseType Get(int id)
        {
            using (ExpenseTrackerContext db = new ExpenseTrackerContext())
            {
                return db.ExpenseTypes
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
            }
        }

        public List<ExpenseType> GetAll()
        {
            using (ExpenseTrackerContext db = new ExpenseTrackerContext())
            {
                return db.ExpenseTypes.ToList();
            }
        }

        public void Remove(int id)
        {
            using (ExpenseTrackerContext db = new ExpenseTrackerContext())
            {
               var expenseType = db.ExpenseTypes.Where(x => x.Id == id).FirstOrDefault();
                db.ExpenseTypes.Remove(expenseType);
                db.SaveChanges();
            }
        }

        public void Update(ExpenseType newRecord)
        {
            using (ExpenseTrackerContext db = new ExpenseTrackerContext())
            {
                var oldRecord = db.ExpenseTypes
                    .Where(x => x.Id == newRecord.Id)
                    .FirstOrDefault();

                db.Entry(oldRecord).CurrentValues.SetValues(newRecord);
                db.SaveChanges();

            }
        }
    }
}
