using MusicPlayer.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class TrackFolderModel
    {
        public string Name { get; set; }

        public TimeSpan Duration { get; set; }

        public string PathToFile { get; set; }

        public string Album { get; set; }

        public string Artist { get; set; }

        public string Genre { get; set; }

        public MusicFormat Format { get; set; }

        public override string ToString()
        {
            return $"{Name}\t {Artist}\t {Album}\t {Genre}\t {Duration.ToString()}";
        }
    }
}
