using MusicPlayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(PlayerService));
            host.Open();
            Console.WriteLine("Host is opened. Hit any key to exit");
            Console.ReadKey();
            host.Close();

        }
    }
}
