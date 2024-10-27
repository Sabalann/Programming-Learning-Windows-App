namespace Programming_Learning_Windows_App
{
    public abstract class FileInterpreter // base class
    {
        protected List<Command> Commands = new List<Command>();

        protected abstract void Interpret();

        public virtual List<Command> GetCommands() { return Commands; }
    }
}
