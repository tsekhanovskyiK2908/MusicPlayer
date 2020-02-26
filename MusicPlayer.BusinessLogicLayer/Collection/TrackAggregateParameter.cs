using MusicPlayer.BusinessLogicLayer.Iterator;
using MusicPlayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BusinessLogicLayer.Collection
{
    public class TrackAggregateParameter : IAggregateCollection<Track>
    {
        private List<Track> _tracks;

        public TrackAggregateParameter(IEnumerable<Track> tracks)
        {
            _tracks = tracks.ToList();
        }
        public IIterator<Track> GetIterator()
        {
            return new TrackIteratorReverse(this);
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
            get { return _tracks[index]; }
            set { _tracks.Insert(index, value); }
        }
    }
}
