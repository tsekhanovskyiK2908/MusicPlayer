using MusicPlayer.BusinessLogicLayer.Abstraction;
using MusicPlayer.BusinessLogicLayer.Implementation;
using MusicPlayer.Client.CommandsBuiltIn;
using MusicPlayer.Client.CommandsCustom;
using MusicPlayer.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicPlayer.Client.ViewModel
{   
    /// <summary>
    /// Client
    /// </summary>
    public class AddTrackToPlaylistWindowViewModel : ViewModelBase
    {
        private Track _selectedTrack;
        private Track _selectedTrackInPlaylist;
        private ObservableCollection<Track> _tracks;
        private ObservableCollection<Track> _tracksInPlaylist;
        private ITrackProcessor _trackProcessor;

        //Custom command
        private Invoker _invoker;
        private PlaylistProcessor _playlistProcessor;
        


        public ICommand AddTrackCommand { get; set; }
        public ICommand RemoveTrackCommand { get; set; }
        public ICommand UndoTrackCommand { get; set; }
        public ICommand RedoTrackCommand { get; set; }

        private ICommandCustom _addTrackCommandCustom;

        private ICommandCustom _removeTrackCommandCustom;


        public AddTrackToPlaylistWindowViewModel()
        {            
            _tracks = new ObservableCollection<Track>();
            _tracksInPlaylist = new ObservableCollection<Track>();
            _trackProcessor = new TrackProcessor();
            _tracks = _trackProcessor.LoadTracks().ToObservableCollection();
            AddTrackCommand = new RelayCommand(OnAddTrack, OnCanAddTrack);
            RemoveTrackCommand = new RelayCommand(OnRemoveTrack, OnCanRemoveTrack);
            UndoTrackCommand = new RelayCommand(OnUndoTrack, OnCanUndoTrack);
            RedoTrackCommand = new RelayCommand(OnRedoTrack, OnCanRedoTrack);

            _invoker = new Invoker();
        }

        private bool OnCanRedoTrack()
        {
            if(_invoker.RedoCount > 0)
            {
                return true;
            }

            return false;
        }

        private bool OnCanUndoTrack()
        {
            if(_invoker.CommandsCount > -1)
            {
                return true;
            }

            return false;
        }

        private void OnRedoTrack()
        {
            _invoker.Redo();
        }

        private void OnUndoTrack()
        {
            _invoker.Undo();
        }

        private bool OnCanRemoveTrack()
        {
            if (_selectedTrackInPlaylist != null)
            {
                return true;
            }

            return false;
        }

        private void OnRemoveTrack()
        {
            _playlistProcessor = new PlaylistProcessor(_tracksInPlaylist);
            _removeTrackCommandCustom = new RemoveTrackCommandCustom(_playlistProcessor, _selectedTrackInPlaylist);

            _invoker.SetCommand(_removeTrackCommandCustom);
            _invoker.Invoke();
        }

        private bool OnCanAddTrack()
        {
            if(!_tracksInPlaylist.Contains(_selectedTrack) && _selectedTrack != null)
            {
                return true;
            }

            return false;
        }

        private void OnAddTrack()
        {
            _playlistProcessor = new PlaylistProcessor(_tracksInPlaylist);
            _addTrackCommandCustom = new AddTrackCommandCustom(_playlistProcessor, _selectedTrack);

            _invoker.SetCommand(_addTrackCommandCustom);
            _invoker.Invoke();

        }

        public Track Track 
        { 
            get
            {
                return _selectedTrack;
            }
            set
            {
                _selectedTrack = value;
                OnPropertyChanged("Track");
            }
        }

        public Track TrackInPlaylist
        {
            get
            {
                return _selectedTrackInPlaylist;
            }
            set
            {
                _selectedTrackInPlaylist = value;
                OnPropertyChanged("TrackInPlaylist");
            }
        }

        public ObservableCollection<Track> Tracks
        {
            get 
            {
                return _tracks;
            }
            set
            {
                _tracks = value;
                OnPropertyChanged("Tracks");
            }
        }

        public ObservableCollection<Track> TracksInPlaylist
        {
            get
            {
                return _tracksInPlaylist;
            }
            set
            {
                _tracks = value;
                OnPropertyChanged("TracksInPlaylist");
            }
        }
    }
}
