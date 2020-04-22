using MusicPlayer.Client.FrontendServices.Abs;
using MusicPlayer.Entities;
using MusicPlayer.Entities.Enum;
using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace MusicPlayer.Client.FrontendServices.Impl
{
    public class MP3TrackCreator : ITrackCreator
    {
        public TrackFolderModel CreateTrackFromFile(string musicFile)
        {
            using (var mp3 = TagLib.File.Create(musicFile))
            {
                Tag id3Frames = mp3.GetTag(TagTypes.Id3v2);

                var track = new TrackFolderModel
                {
                    Name = id3Frames.Title,
                    Duration = mp3.Properties.Duration,
                    PathToFile = musicFile,
                    Album = id3Frames.Album,
                    Artist = id3Frames.FirstAlbumArtist,
                    Genre = id3Frames.FirstGenre,
                    Format = MusicFormat.MP3
                };

                return track; 
            }
        }
    }
}
