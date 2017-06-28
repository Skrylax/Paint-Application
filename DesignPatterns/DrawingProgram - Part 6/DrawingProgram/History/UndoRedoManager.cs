using DrawingProgram.Commands;
using System.Collections.Generic;

namespace DrawingProgram.History
{
    class UndoRedoManager 
    {
        Stack<Command> undoStack;
        Stack<Command> redoStack;

        public UndoRedoManager()
        {
            undoStack = new Stack<Command>();
            redoStack = new Stack<Command>();
        }

        public void Undo()
        {
            if (undoStack.Count != 0)
            {
                Command c = undoStack.Pop();
                redoStack.Push(c);
                c.Undo();
            }
        }

        public void Redo()
        {
            if(redoStack.Count > 0)
            {
                Command c = redoStack.Pop();
                undoStack.Push(c);
                c.Do();
            }
        }

        public void Add(Command command)
        {
            undoStack.Push(command);
            command.Do();
        }
    }
}
