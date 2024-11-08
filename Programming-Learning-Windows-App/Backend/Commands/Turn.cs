namespace Programming_Learning_Windows_App;

public class Turn : Command
{
    public Turn(Direction Direction)
    {
        this.Direction = Direction;
    }

    public Direction Direction { get; set; }

    public override void Execute(Character character)
    {
        character.Turn(Direction);
    }


    public override string Display()
    {
        return "Turn " + Direction + " ";
    }
}