namespace DrawingProgram.Commands
{
    class SelectShapeCommand : Command
    {
        Shape newShape;
        Shape oldShape;
        MainForm form;
        
        public SelectShapeCommand(Shape d, MainForm f)
        {
            newShape = d;
            form = f;
        }

        public void Do()
        {
            if (newShape != null)
                newShape.selected = true;

            if (form.SelectedShape != null)
                form.SelectedShape.selected = false;

            oldShape = form.SelectedShape;
            form.SelectedShape = newShape;
        }

        public void Undo()
        {
            if (oldShape != null)
                oldShape.selected = true;

            if (form.SelectedShape != null)
                form.SelectedShape.selected = false;

            form.SelectedShape = oldShape;
        }
    }
}
