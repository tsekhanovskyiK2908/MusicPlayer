using Microsoft.Win32;
using MusicPlayer.Client.FrontendServices.Abs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Client.FrontendServices.Impl
{
    public class IOService : IIOService
    {
        public List<string> GetFilesFromFolder(string pathToFolder)
        {   
            if(!String.IsNullOrEmpty(pathToFolder) && Directory.Exists(pathToFolder))
            {
                var musicFiles = Directory.EnumerateFiles(pathToFolder, "*.*", SearchOption.AllDirectories)
                .Where(fn => fn.ToLower().EndsWith(".mp3") || fn.ToLower().EndsWith(".wav")).ToList();

                return musicFiles;
            }

            return null;
        }
    }
}
