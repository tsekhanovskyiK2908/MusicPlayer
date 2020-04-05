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
        private ObservableCollection<Track> _tracks;
        private ObservableCollection<Track> _tracksInPlaylist;
        private bool _trackWasAdded;        
        private ITrackProcessor _trackProcessor;

        //Custom command
        private Invoker _invoker;
        private PlaylistProcessor _playlistProcessor;
        


        public ICommand AddTrackCommand { get; set; }

        public ICommand UndoAddTrackCommand { get; set; }

        //Custom command
        private ICommandCustom _addTrackCommandCustom;

        private ICommandCustom _removeTrackCommandCustom;


        public AddTrackToPlaylistWindowViewModel()
        {            
            _tracks = new ObservableCollection<Track>();
            _tracksInPlaylist = new ObservableCollection<Track>();
            _trackProcessor = new TrackProcessor();
            _tracks = _trackProcessor.LoadTracks().ToObservableCollection();
            AddTrackCommand = new RelayCommand(OnAddTrack, OnCanAddTrack);
            UndoAddTrackCommand = new RelayCommand(OnRemoveTrack, OnCanRemoveTrack);

            _invoker = new Invoker();
        }

        private bool OnCanRemoveTrack()
        {
            if (_trackWasAdded)
            {
                return true;
            }

            return false;
        }

        private void OnRemoveTrack()
        {
            //var count = _tracksInPlaylist.Count;
            //_tracksInPlaylist.RemoveAt(count - 1);
            //_trackWasAdded = false;

            _playlistProcessor = new PlaylistProcessor(_tracksInPlaylist);
            _removeTrackCommandCustom = new RemoveTrackCommandCustom(_playlistProcessor);

            _invoker.SetCommand(_removeTrackCommandCustom);
            _invoker.Invoke();
            _trackWasAdded = false;
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
            //_tracksInPlaylist.Add(_selectedTrack);
            //_trackWasAdded = true;

            _playlistProcessor = new PlaylistProcessor(_tracksInPlaylist);
            _addTrackCommandCustom = new AddTrackCommandCustom(_playlistProcessor, _selectedTrack);

            _invoker.SetCommand(_addTrackCommandCustom);
            _invoker.Invoke();

            _trackWasAdded = true;
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
