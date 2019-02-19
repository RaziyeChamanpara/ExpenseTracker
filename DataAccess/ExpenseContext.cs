using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace DataAccess
{
    public class ExpenseContext:DbContext
    {
        public ExpenseContext()
            :base("ExpenseTrackerConnectionString")
        {

        }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
    }
}
