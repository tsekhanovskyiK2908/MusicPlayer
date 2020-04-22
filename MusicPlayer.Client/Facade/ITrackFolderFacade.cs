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
    public interface ITrackFolderFacade
    {
        ObservableCollection<TrackFolderModel> GetTracks();
    }
}
