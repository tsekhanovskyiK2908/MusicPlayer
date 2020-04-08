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
        private Action _operation;

        public OperationMemento(Action commandCustom)
        {
            _operation = commandCustom;
        }

        public Action GetCommand()
        {
            return _operation;
        }

        
    }
}
