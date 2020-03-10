using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Client.Commands
{
    public interface ICommandCustom
    {
        void Execute();
        void Undo();
    }
}
