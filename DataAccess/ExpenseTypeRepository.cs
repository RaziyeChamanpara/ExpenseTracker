using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ExpenseTypeRepository : IRepository<ExpenseType>
    {

        public void Add(ExpenseType expenseType)
        {
            using (ExpenseContext _expenseContext = new ExpenseContext())
            {
                _expenseContext.ExpenseTypes.Add(expenseType);
                _expenseContext.SaveChanges();
            }
        }

        public ExpenseType Get(int id)
        {
            using (ExpenseContext _expenseContext = new ExpenseContext())
            {
                return _expenseContext.ExpenseTypes.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public List<ExpenseType> GetAll()
        {
            using (ExpenseContext _expenseContext = new ExpenseContext())
            {
                return _expenseContext.ExpenseTypes.ToList();
            }
        }

        public void Remove(ExpenseType expenseType)
        {
            using (ExpenseContext _expenseContext = new ExpenseContext())
            {
                _expenseContext.ExpenseTypes.Remove(expenseType);
            }
        }

        public void Update(ExpenseType entity)
        {
            throw new NotImplementedException();
        }
    }
}
