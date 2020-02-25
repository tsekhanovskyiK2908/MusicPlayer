using MusicPlayer.BusinessLogicLayer.Abstraction;
using MusicPlayer.DataAccessLayer;
using MusicPlayer.DataAccessLayer.Repository;
using MusicPlayer.DataAccessLayer.RepositoryRealization;
using MusicPlayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BusinessLogicLayer.Implementation
{
    public class TrackProcessor : ITrackProcessor
    {
        private TrackRepository _trackRepository;
        private DbContext _dbContext;

        public TrackProcessor()
        {
            
        }
        public IEnumerable<Track> LoadTracks()
        {
            throw new NotImplementedException();
        }

        public void SaveTrackToDb(Track track)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Track> SortTracks()
        {
            throw new NotImplementedException();
        }
    }
}
