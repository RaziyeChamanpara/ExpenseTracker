using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        TEntity Get(int id);
        List<TEntity> GetAll();
    }
}
