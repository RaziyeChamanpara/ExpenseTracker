using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Expense
    {
        public int Id { get; set; }
        public virtual ExpenseType ExpenseType { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }

        [Required]
        public int ExpenseTypeId { get; set; }
    }
}
