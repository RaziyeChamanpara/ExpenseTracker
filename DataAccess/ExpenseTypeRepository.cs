﻿using System;
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
            using (ExpenseContext db = new ExpenseContext())
            {
                db.ExpenseTypes.Add(expenseType);
                db.SaveChanges();
            }
        }

        public ExpenseType Get(int id)
        {
            using (ExpenseContext db = new ExpenseContext())
            {
                return db.ExpenseTypes
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
            }
        }

        public List<ExpenseType> GetAll()
        {
            using (ExpenseContext db = new ExpenseContext())
            {
                return db.ExpenseTypes.ToList();
            }
        }

        public void Remove(ExpenseType expenseType)
        {
            using (ExpenseContext db= new ExpenseContext())
            {
                db.ExpenseTypes.Remove(expenseType);
                db.SaveChanges();
            }
        }

        public void Update(ExpenseType newRecord)
        {
            using (ExpenseContext db = new ExpenseContext())
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
