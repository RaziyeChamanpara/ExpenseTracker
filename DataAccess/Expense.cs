using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Expense
    {
        public int Id { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
    }
}
