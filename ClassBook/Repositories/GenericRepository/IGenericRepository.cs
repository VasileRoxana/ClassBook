using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
        TEntity FindById(object id);
        bool Save();
    }
}
