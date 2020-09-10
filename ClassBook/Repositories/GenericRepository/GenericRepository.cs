using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBook.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ClassBookDbContext _context;
        protected readonly DbSet<TEntity> _table;
        public GenericRepository(ClassBookDbContext dbContext)
        {
            _context = dbContext;
            _table = _context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _table.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public TEntity FindById(object id)
        {
            return _table.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _table.AsNoTracking();
        }

        public bool Save()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();

                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                                         "Message: " + ex.Errors[i].Message + "\n" +
                                         "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                                         "Source: " + ex.Errors[i].Source + "\n" +
                                         "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());
            }
            return false;
        }

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }
    }
}
