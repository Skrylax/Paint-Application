using DrawingProgram.Commands;
using System.Collections.Generic;

namespace DrawingProgram.History
{
    class MacroCommand : Command
    {
        List<Command> commands;

        public MacroCommand()
        {
            commands = new List<Command>();
        }

        public void Add(Command command)
        {
            commands.Add(command);
        }

        public void Do()
        {
            commands.ForEach(c => c.Do());
        }

        public void Undo()
        {
            commands.ForEach(c => c.Undo());
        }
    }
}
