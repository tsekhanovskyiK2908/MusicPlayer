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
        private Action _commandReverse;

        public int RedoCount { get; private set; }
        public int CommandsCount { get; private set; }

        public Invoker()
        {
            _commands = new List<ICommandCustom>();
            _operationCaretaker = new OperationCaretaker();
            CommandsCount = -1;
        }

        public void SetCommand(ICommandCustom commandCustom)
        {
            _command = commandCustom;
        }


        public void Invoke()
        {
            _commandReverse = _command.UnExecute;

            var memento = CreateMemento();
            _operationCaretaker.UndoCommand = memento;

            CommandsCount++;
            _commands.Insert(CommandsCount, _command);
            _command.Execute();

            RedoCount = 0;
        }

        public void Undo()
        {
            var mementoToComeBack = _operationCaretaker.UndoCommand;

            _commandReverse = _commands[CommandsCount].Execute;

            var memento = CreateMemento();
            _operationCaretaker.RedoCommand = memento;

            SetMemento(mementoToComeBack);

            _commandReverse();
            
            RedoCount++;
            CommandsCount--;
        }

        public void Redo()
        {
            var mementoToGoBack = _operationCaretaker.RedoCommand;

            _commandReverse = _commands[CommandsCount].UnExecute;

            var memento = CreateMemento();
            _operationCaretaker.UndoCommand = memento;

            SetMemento(mementoToGoBack);

            _commandReverse();

            RedoCount--;
            CommandsCount++;
        }

        public void SetMemento(OperationMemento operationMemento)
        {
            _commandReverse = operationMemento.GetCommand();
        }

        public OperationMemento CreateMemento()
        {
            return new OperationMemento(_commandReverse);
        }
    }
}
