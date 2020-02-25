using MusicPlayer.BusinessLogicLayer.Implementation;
using MusicPlayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class PlayerService : IPlayerService
    {
        private TrackProcessor _trackProcessor;
        public PlayerService()
        {
            _trackProcessor = new TrackProcessor();
        }
        public IEnumerable<Track> GetTracks()
        {
            return _trackProcessor.LoadTracks();   
        }
    }
}
