using MusicPlayer.BusinessLogicLayer.Iterator;
using MusicPlayer.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BusinessLogicLayer.Collection
{
    public class TrackAggregateBuildIn : IEnumerable<Track>
    {
        private List<Track> _tracks = new List<Track>();
        public IEnumerator<Track> GetEnumerator()
        {
            return new TrackIteratorBuildIn(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count
        {
            get
            {
                return _tracks.Count;
            }
        }

        public Track this[int index]
        {
            get
            {
                return _tracks[index];
            }
            set
            {
                _tracks.Insert(index, value);
            }
        }
    }
}
