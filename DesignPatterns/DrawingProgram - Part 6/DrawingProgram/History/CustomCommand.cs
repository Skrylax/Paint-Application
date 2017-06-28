using System;
using DrawingProgram.Commands;

namespace DrawingProgram.History
{
    class CustomCommand : Command
    {
        public Action doAction;
        public Action undoAction;

        public CustomCommand(Action doAction, Action undoAction = null)
        {
            this.doAction = doAction;
            this.undoAction = undoAction;
        }

        public void Do()
        {
            doAction?.Invoke();
        }

        public void Undo()
        {
            undoAction?.Invoke();
        }
    }
}
