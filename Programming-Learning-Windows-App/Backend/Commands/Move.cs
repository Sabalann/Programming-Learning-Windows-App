namespace Programming_Learning_Windows_App;

public class Move : Command
{
    public Move(int Steps)
    {
        this.Steps = Steps;
    }

    public int Steps { get; set; }

    public override void Execute(Character Character)
    {
        Character.Move(Steps);
    }

    public override string Display()
    {
        return "Move " + Steps + " ";
    }
}