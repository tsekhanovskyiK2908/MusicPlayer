using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Client.CommandsCustom
{   
    /// <summary>
    /// Invoker
    /// </summary>
    public class Invoker
    {
        private List<ICommandCustom> _commands;
        private ICommandCustom _command;
        public int CurrentCommand { get; private set; }

        public int RedoCount { get; private set; }

        public Invoker()
        {
            _commands = new List<ICommandCustom>();
            CurrentCommand = -1;
        }

        public void SetCommand(ICommandCustom commandCustom)
        {
            _command = commandCustom;
        }

        public void Invoke()
        {
            CurrentCommand++;
            _commands.Insert(CurrentCommand, _command);
            RedoCount = 0;
            _command.Execute();
        }

        public void ReInvoke()
        {   
            if(CurrentCommand >= 0)
            {
                _commands[CurrentCommand].UnExecute();
                CurrentCommand--;
                RedoCount++;
            }            
        }
        public void Redo()
        {
            CurrentCommand++;
            _commands[CurrentCommand].Execute();
            RedoCount--;
        }
    }
}
