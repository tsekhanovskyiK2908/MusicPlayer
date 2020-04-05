using MusicPlayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Client.CommandsCustom
{   
    /// <summary>
    /// Concrete command
    /// </summary>
    public class AddTrackCommandCustom : ICommandCustom
    {
        private PlaylistProcessor _playlistProcessor;
        private Track _track; 
        public AddTrackCommandCustom(PlaylistProcessor playlistProcessor, Track track)
        {
            _playlistProcessor = playlistProcessor;
            _track = track;
        }
        public void Execute()
        {
            _playlistProcessor.AddTrack(_track);
        }

        public void UnExecute()
        {
            _playlistProcessor.RemoveTrack(_track);
        }
    }
}
