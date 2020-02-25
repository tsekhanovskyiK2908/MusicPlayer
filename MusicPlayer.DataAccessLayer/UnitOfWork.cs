using MusicPlayer.DataAccessLayer.Repository;
using MusicPlayer.DataAccessLayer.RepositoryRealization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private readonly string _connectionString;
        private ITrackRepository _trackRepository;

        public UnitOfWork()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["MusicPlayerDB"].ConnectionString;
            _dbContext = new DbContext(_connectionString);
        }
        public ITrackRepository TrackRepository
        {
            get
            {
                if(_trackRepository == null)
                {
                    _trackRepository = new TrackRepository(_dbContext);
                }

                return _trackRepository;
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
