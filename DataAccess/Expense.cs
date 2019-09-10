using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class Expense:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string ExpenseTypeName { get; set; }

        [Required]
        public int ExpenseTypeId { get; set; }

        public virtual ExpenseType ExpenseType { get; set; }
    }
}
