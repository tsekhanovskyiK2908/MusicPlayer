using MusicPlayer.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DataAccessLayer
{
    public interface IUnitOfWork
    {
        ITrackRepository TrackRepository { get; }
        void Commit();
    }
}
