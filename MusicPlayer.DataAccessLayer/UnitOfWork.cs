using MusicPlayer.DataAccessLayer.Repository;
using MusicPlayer.DataAccessLayer.RepositoryRealization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly string _connectionString;
        private ITrackRepository _trackRepository;

        public UnitOfWork()
        {
            //_connectionString = ConfigurationManager
            //    .ConnectionStrings["MusicPlayerDB"].ConnectionString;

            _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MusicPlayerNotCore;Trusted_Connection=True";
            _applicationDbContext = new ApplicationDbContext();
            Debug.WriteLine(_connectionString);
        }
        public ITrackRepository TrackRepository
        {
            get
            {
                if(_trackRepository == null)
                {
                    _trackRepository = new TrackRepository(_applicationDbContext);
                }

                return _trackRepository;
            }
        }

        public void Commit()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
