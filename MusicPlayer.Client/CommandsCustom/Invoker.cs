using MusicPlayer.Client.Memento;
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
        private OperationCaretaker _operationCaretaker;

        public int RedoCount { get; private set; }
        public int CommandsCount { get; private set; }

        public Invoker()
        {
            _commands = new List<ICommandCustom>();
            _operationCaretaker = new OperationCaretaker();
        }

        public void SetCommand(ICommandCustom commandCustom)
        {
            _command = commandCustom;
        }


        public void Invoke()
        {
            var memento = CreateMemento();
            _operationCaretaker.UndoCommand = memento; 

            _commands.Add(_command);
            _command.Execute();

            RedoCount = 0;
            CommandsCount++;
        }

        public void Undo()
        {
            var mementoCurrent = _operationCaretaker.UndoCommand;

            var memento = CreateMemento();

            _operationCaretaker.RedoCommand = memento;

            SetMemento(mementoCurrent);
            _command.UnExecute();
            _commands.Remove(_command);
            
            RedoCount++;
            CommandsCount--;
        }

        public void Redo()
        {
            var mementoCurrent = _operationCaretaker.RedoCommand;

            SetMemento(mementoCurrent);
            _commands.Add(_command);
            _command.Execute();

            RedoCount--;
            CommandsCount++;
        }

        public void SetMemento(OperationMemento operationMemento)
        {
            _command = operationMemento.GetCommand();
        }

        public OperationMemento CreateMemento()
        {
            return new OperationMemento(_command);
        }
    }
}
