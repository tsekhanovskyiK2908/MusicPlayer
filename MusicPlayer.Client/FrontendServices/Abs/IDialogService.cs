using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Client.FrontendServices.Abs
{
    public interface IDialogService
    {
        string OpenFolderExplorer();

        string[] OpenFileExplorer();

    }
}
