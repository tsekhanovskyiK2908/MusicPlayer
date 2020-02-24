using MusicPlayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Services
{   
    [ServiceContract]
    public interface IPlayerService
    {   
        [OperationContract]
        IEnumerable<Track> GetTracks();
    }
}
