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
        private IUnitOfWork _unitOfWork;

        public TrackProcessor()
        {
            _unitOfWork = new UnitOfWork();
        }
        public IEnumerable<Track> LoadTracks()
        {
            return _unitOfWork.TrackRepository.GetAll();
        }

        public void SaveTrackToDb(Track track)
        {
            _unitOfWork.TrackRepository.Add(track);

            _unitOfWork.Commit();
        }

        public IEnumerable<Track> SortTracks()
        {
            throw new NotImplementedException();
        }
    }
}
