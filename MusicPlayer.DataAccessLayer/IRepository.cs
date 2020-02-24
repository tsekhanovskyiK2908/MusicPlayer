using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DataAccessLayer
{
    public interface IRepository<TEntity> : IGenericKeyRepository<Guid, TEntity> where TEntity : class
    {
    }
}
