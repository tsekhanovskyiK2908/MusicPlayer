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
        private int _commandsCount;

        public int CurrentCommand { get; private set; }

        public int CommandsCount { get; private set; }

        public Invoker()
        {
            _commands = new List<ICommandCustom>();
            CommandsCount = _commands.Count;
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
            _command.Execute();
        }

        public void ReInvoke()
        {   
            if(CurrentCommand >= 0)
            {
                _commands[CurrentCommand].UnExecute();
                CurrentCommand--;
            }            
        }
        //public void Redo()
        //{
        //    CurrentCommand++;
        //    _commands[CurrentCommand].Execute();
        //}
    }
}
