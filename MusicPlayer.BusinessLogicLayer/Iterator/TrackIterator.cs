using MusicPlayer.BusinessLogicLayer.Collection;
using MusicPlayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BusinessLogicLayer.Iterator
{
    public class TrackIterator : IIterator<Track>
    {
        private TrackAggregate _trackAggregate;
        private int _currentIndex = 0;

        public TrackIterator(TrackAggregate trackAggregate)
        {
            _trackAggregate = trackAggregate;
        }

        public bool IsDone => _currentIndex >= _trackAggregate.Count;

        public Track Current => _trackAggregate[_currentIndex];

        public Track First()
        {
            return _trackAggregate[0];
        }

        public Track Next()
        {
            _currentIndex++;

            if (!IsDone)
            {

                return _trackAggregate[_currentIndex];
            }

            return null;
        }
    }
}
