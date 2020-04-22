using MusicPlayer.Client.FrontendServices.Abs;
using MusicPlayer.Client.FrontendServices.Impl;
using MusicPlayer.Entities;
using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Client.Facade
{
    public class TrackFolderFacade : ITrackFolderFacade
    {
        private readonly IDialogService _dialogService;
        private readonly IIOService _ioService;
        private readonly ITrackService _trackService;

        public TrackFolderFacade()
        {
            _dialogService = new DialogService();
            _ioService = new IOService();
            _trackService = new TrackService();
        }

        public ObservableCollection<TrackFolderModel> GetTracks()
        {
            var pathToDirectory = _dialogService.OpenFolderExplorer();
            var fileNames = _ioService.GetFilesFromFolder(pathToDirectory);
            var tracks = _trackService.GetTracks(fileNames);

            return tracks.ToObservableCollection();
        }
    }
}
