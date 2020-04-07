using MusicPlayer.Client.CommandsCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Client.Memento
{
    public class OperationMemento
    {
        private ICommandCustom _operation;

        public OperationMemento(ICommandCustom commandCustom)
        {
            _operation = commandCustom;
        }

        public ICommandCustom GetCommand()
        {
            return _operation;
        }

        
    }
}
