using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DataAccessLayer
{
    public interface IGenericKeyRepository<TKey, TEntity> where TEntity : class
                                                          where TKey : struct
    {
        void Add(TEntity entity);

        void Update(TEntity updatedEntity);

        void Remove(TEntity entity);

        TEntity GetById(TKey id);

        IEnumerable<TEntity> GetAll();
    }
}
