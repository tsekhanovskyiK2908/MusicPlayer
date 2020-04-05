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

        public Invoker()
        {
            _commands = new List<ICommandCustom>();
        }

        public void SetCommand(ICommandCustom commandCustom)
        {
            _command = commandCustom;
        }

        public void Invoke()
        {
            _commands.Add(_command);

            _command.Execute();
        }
    }
}
