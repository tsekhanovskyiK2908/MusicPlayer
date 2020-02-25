using MusicPlayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BusinessLogicLayer.Abstraction
{
    public interface ITrackProcessor
    {
        void SaveTrackToDb(Track track);

        IEnumerable<Track> LoadTracks();

        IEnumerable<Track> SortTracks();
    }
}
