using MusicPlayer.BusinessLogicLayer.Collection;
using MusicPlayer.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BusinessLogicLayer.Iterator
{
    public class TrackIteratorBuildIn : IEnumerator<Track>
    {
        private int _current = -1;
        private TrackAggregateBuildIn _trackAggregate;
        public Track Current => _trackAggregate[_current];

        object IEnumerator.Current => Current;

        public TrackIteratorBuildIn(TrackAggregateBuildIn tracks)
        {
            _trackAggregate = tracks;
        }

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            _current++;

            return _current < _trackAggregate.Count;
        }

        public void Reset()
        {
            _current = -1;
        }
    }
}
