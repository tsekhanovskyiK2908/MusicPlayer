using MusicPlayer.Client.FrontendServices.Abs;
using MusicPlayer.Entities;
using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Client.FrontendServices.Impl
{
    public class TrackService : ITrackService
    {
        private ITrackCreator _trackCreator;
        public TrackService()
        {

        }
        public List<TrackFolderModel> GetTracks(List<string> fileNames)
        {
            List<TrackFolderModel> tracks = new List<TrackFolderModel>();

            foreach (var fileName in fileNames)
            {                
                if(fileName.ToLower().EndsWith(".mp3"))
                {
                    _trackCreator = new MP3TrackCreator();

                    tracks.Add(_trackCreator.CreateTrackFromFile(fileName));                    
                }
                else if(fileName.ToLower().EndsWith(".wav"))
                {
                    _trackCreator = new WavTrackCreator();

                    tracks.Add(_trackCreator.CreateTrackFromFile(fileName));
                }
            }

            return tracks;
        }
    }
}
