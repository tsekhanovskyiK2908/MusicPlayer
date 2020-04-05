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
    public class RemoveTrackCommandCustom : ICommandCustom
    {
        private PlaylistProcessor _playlistProcessor;

        public RemoveTrackCommandCustom(PlaylistProcessor playlistProcessor)
        {
            _playlistProcessor = playlistProcessor;
        }
        public void Execute()
        {
            _playlistProcessor.RemoveTrack();
        }
    }
}
