namespace DrawingProgram.Commands
{
    interface Command
    {
        void Do();
        void Undo();
    }
}
