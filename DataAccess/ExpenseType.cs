﻿using System.Collections.Generic;

namespace DataAccess
{
    public class ExpenseType:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }

    }
}
