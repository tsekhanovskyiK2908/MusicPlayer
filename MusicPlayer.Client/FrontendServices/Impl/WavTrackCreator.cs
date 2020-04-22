using MusicPlayer.Client.FrontendServices.Abs;
using MusicPlayer.Entities;
using MusicPlayer.Entities.Enum;
using MusicPlayer.Models;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Client.FrontendServices.Impl
{
    public class WavTrackCreator : ITrackCreator
    {
        public TrackFolderModel CreateTrackFromFile(string pathToTrack)
        {
            using(WaveFileReader wave = new WaveFileReader(pathToTrack))
            {
                var track = new TrackFolderModel
                {
                    Duration = wave.TotalTime,
                    Name = Path.GetFileNameWithoutExtension(pathToTrack),
                    PathToFile = pathToTrack,
                    Format = MusicFormat.WAV
                };

                return track;
            }
        }
    }
}
