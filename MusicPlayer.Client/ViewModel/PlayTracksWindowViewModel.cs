using MusicPlayer.Client.MusicPlayerServices;
using MusicPlayer.DataAccessLayer;
using MusicPlayer.BusinessLogicLayer.Iterator;
using MusicPlayer.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MusicPlayer.BusinessLogicLayer.Collection;

namespace MusicPlayer.Client.ViewModel
{
    public class PlayTracksWindowViewModel : ViewModelBase
    {
        private IEnumerable<Track> _tracks;
        private ObservableCollection<Track> _reverseTracks = new ObservableCollection<Track>();

        public ObservableCollection<Track> Tracks 
        { 
            get 
            {
                return _tracks.ToObservableCollection();
            } 
            set
            {
                _tracks = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Track> TracksReverse
        {
            get
            {
                return _reverseTracks;
            }
            set
            {
                _reverseTracks = value;
                OnPropertyChanged();
            }
        }

        public PlayTracksWindowViewModel()
        {
            LoadTracks();
            ReverseTracks();

        }

        private void OnTrackTraverseThroughOne()
        {
            throw new NotImplementedException();
        }

        private void ReverseTracks()
        {
            TrackAggregateParameter trackAggregateParameter = new TrackAggregateParameter(_tracks);
            var iterator = trackAggregateParameter.GetIterator();

            for (iterator.First(); !iterator.IsDone;iterator.Next())
            {
                _reverseTracks.Add(iterator.Current);
            }


        }

        private void LoadTracks()
        {
            //PlayerServiceClient proxy = new PlayerServiceClient("NetTcpBinding_IPlayerService");

            //try
            //{
            //    _tracks = proxy.GetTracks();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Failed to load server data " + ex.Message);
            //}
            //finally
            //{
            //    proxy.Close();
            //}

            _tracks = new UnitOfWork().TrackRepository.GetAll();
        }
    }
}
