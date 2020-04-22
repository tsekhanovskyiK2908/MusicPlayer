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
    public class DialogService : IDialogService
    {
        public string[] OpenFileExplorer()
        {
            var dialog = new OpenFileDialog
            {
                Filter = DialogSettings.Filter,
                Multiselect = true
            };

            var result = dialog.ShowDialog();

            if (result == true)
            {
                return dialog.FileNames;
            }

            return null;
        }

        public string OpenFolderExplorer()
        {
            var dialog = new OpenFileDialog();

            var result = dialog.ShowDialog();

            if (result == true)
            {
                return Path.GetDirectoryName(dialog.FileName);
            }

            return null;
        }
    }
}
