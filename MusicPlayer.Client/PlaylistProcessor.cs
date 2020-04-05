using MusicPlayer.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Client
{   
    /// <summary>
    /// Receiver
    /// </summary>
    public class PlaylistProcessor
    {
        private ObservableCollection<Track> _tracksInPlaylist;

        public PlaylistProcessor(ObservableCollection<Track> tracksInPlaylist)
        {
            _tracksInPlaylist = tracksInPlaylist;
        }

        public void AddTrack(Track track)
        {
            _tracksInPlaylist.Add(track);
        }

        public void RemoveTrack()
        {
            var count = _tracksInPlaylist.Count;
            _tracksInPlaylist.RemoveAt(count - 1);
        }
    }
}
