namespace Programming_Learning_Windows_App
{
    public class Turn : Command
    {
        public Direction Direction { get; set; }
        public Turn(Direction Direction) 
        { 
            this.Direction = Direction;
        }

        public override void Execute(Character character)
        {
            character.Turn(Direction);
        }


        public override string Display()
        {
            return "Turn " + Direction + " ";
        }
    }
}
