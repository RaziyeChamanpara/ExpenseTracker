using System.Data.Entity;

namespace DataAccess
{
    public class ExpenseTrackerContext : DbContext
    {
        public ExpenseTrackerContext():
            base("ExpenseTrackerConnectionString")
        {

        }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Expense> Expenses { get; set; }

    }
}
