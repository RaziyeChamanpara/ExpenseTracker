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
        public string Title { get; set; }
        public int Cost { get; set; }
        public int ExpenseTypeId { get; set; }
    }
}
