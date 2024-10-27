namespace Programming_Learning_Windows_App
{
    public abstract class Command // base command class
    {
        public abstract void Execute(Character character);
        public abstract string Display();
    }
}
