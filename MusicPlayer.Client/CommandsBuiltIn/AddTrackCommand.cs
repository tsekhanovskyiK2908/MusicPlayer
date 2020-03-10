using MusicPlayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicPlayer.Client.CommandsBuiltIn
{
    public class AddTrackCommand : ICommand
    {
        private PlaylistProcessor _playlistProcessor;
        private object _commandParameter;
        private Track _track;

        public AddTrackCommand(object parameter)
        {
            _commandParameter = parameter;
        }

        public AddTrackCommand(PlaylistProcessor playlistProcessor, Track track)
        {
            _playlistProcessor = playlistProcessor;
            _track = track;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return (_track != null) ? true : false;            
        }

        public void Execute(object parameter)
        {   
            if(CanExecute(parameter))
            {
                var track = (Track)_commandParameter;
                _playlistProcessor.AddTrack(_track);
            }
           
        }
    }
}
