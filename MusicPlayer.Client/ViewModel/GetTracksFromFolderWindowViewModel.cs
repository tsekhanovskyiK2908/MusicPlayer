using MusicPlayer.Client.CommandsBuiltIn;
using MusicPlayer.Client.Facade;
using MusicPlayer.Entities;
using MusicPlayer.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MusicPlayer.Client.ViewModel
{
    public class GetTracksFromFolderWindowViewModel : ViewModelBase
    {
        private ITrackFolderFacade _trackFolderFacade;
        private ObservableCollection<TrackFolderModel> _tracksFromFolder;
        public ICommand OpenFileDialogCommand { get; set; }

        public GetTracksFromFolderWindowViewModel()
        {
            OpenFileDialogCommand = new RelayCommand(OnDialogOpen);
            _trackFolderFacade = new TrackFolderFacade();
            _tracksFromFolder = new ObservableCollection<TrackFolderModel>();
        }

        private void OnDialogOpen()
        {
            _tracksFromFolder = _trackFolderFacade.GetTracks();
        }

        public ObservableCollection<TrackFolderModel> TracksFromFolder
        {
            get
            {
                return _tracksFromFolder;
            }
            set
            {
                _tracksFromFolder = value;
                OnPropertyChanged("TracksFromFolder");
            }
        }
    }
}
