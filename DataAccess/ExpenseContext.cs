using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccess
{
    public class ExpenseContext : DbContext
    {
        public ExpenseContext():
            base("ExpenseTrackerConnectionString")
        {

        }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Expense> Expenses { get; set; }

    }
}
