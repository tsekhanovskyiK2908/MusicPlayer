using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Client.FrontendServices.Abs
{
    public interface IIOService
    {
        List<string> GetFilesFromFolder(string path);
    }
}
