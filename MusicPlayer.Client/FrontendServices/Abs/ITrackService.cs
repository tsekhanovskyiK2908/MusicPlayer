using MusicPlayer.Entities;
using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Client.FrontendServices.Abs
{
    public interface ITrackService
    {
        List<TrackFolderModel> GetTracks(List<string> fileNames);
    }
}
