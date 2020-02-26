using MusicPlayer.BusinessLogicLayer.Collection;
using MusicPlayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BusinessLogicLayer.Iterator
{
    public class TrackIteratorReverse : IIterator<Track>
    {
        private TrackAggregateParameter _trackAggregate;
        private int _currentIndex;

        public TrackIteratorReverse(TrackAggregateParameter trackAggregate)
        {
            _trackAggregate = trackAggregate;
            _currentIndex = trackAggregate.Count - 1;
        }

        public bool IsDone => _currentIndex < 0;

        public Track Current => _trackAggregate[_currentIndex];

        public Track First()
        {
            return _trackAggregate[_trackAggregate.Count - 1];
        }

        public Track Next()
        {
            _currentIndex--;

            if (!IsDone)
            {
                return _trackAggregate[_currentIndex];
            }

            return null;
        }
    }
}
