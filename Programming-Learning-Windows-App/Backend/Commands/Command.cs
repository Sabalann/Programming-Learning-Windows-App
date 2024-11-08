namespace Programming_Learning_Windows_App;

public abstract class Command
{
    public abstract void Execute(Character character);
    public abstract string Display();
}