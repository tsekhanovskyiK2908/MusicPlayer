using MusicPlayer.Client.CommandsCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Client.Memento
{
    public class OperationCaretaker
    {
        private Stack<OperationMemento> _undoStack { get; set; }
        private Stack<OperationMemento> _redoStack { get; set; }

        public OperationCaretaker()
        {
            _undoStack = new Stack<OperationMemento>();
            _redoStack = new Stack<OperationMemento>();
        }

        public OperationMemento UndoCommand
        {
            get
            {
                return _undoStack.Pop();
            }
            set
            {
                _undoStack.Push(value);
            }
        }

        public OperationMemento RedoCommand
        {
            get
            {
                return _redoStack.Pop();
            }
            set
            {
                _redoStack.Push(value);
            }
        }
    }
}
