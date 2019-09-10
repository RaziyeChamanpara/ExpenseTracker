using System.Collections.Generic;

namespace DataAccess
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        void Remove(int id);
        TEntity Get(int id);
        List<TEntity> GetAll();
        void Update(TEntity entity);
    }
}
