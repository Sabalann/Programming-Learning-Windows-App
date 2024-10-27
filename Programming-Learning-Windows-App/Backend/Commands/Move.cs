namespace Programming_Learning_Windows_App
{
    public class Move : Command
    {
        public int Steps { get; set; }
        public Move(int Steps) 
        {
            this.Steps = Steps;
        }

        public override void Execute(Character Character)
        {
            Character.Move(Steps);
            Console.Write(Display());
        }

        public override string Display()
        {
            return "Move " + Steps + " ";
        }
    }
}
