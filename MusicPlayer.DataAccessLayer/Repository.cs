using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DataAccessLayer
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public DbContext DbContext { get; }
        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(Guid id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}
