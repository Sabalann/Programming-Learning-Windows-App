namespace Programming_Learning_Windows_App
{
    public class TXTFileInterpreter : FileInterpreter
    {

        string path;
        private List<Command> Commands = new List<Command>();
        public TXTFileInterpreter(string path)
        {
            this.path = path;
            Interpret();
        }

        public List<Command> GetCommandsList()
        {
            return Commands;
        }

        protected override void Interpret() // doesn't work properly yet (particularly the repeat part)
        {
            var content = File.ReadAllLines(path);
            int currentIndentLevel = 0;
            Stack<List<Command>> commandStack = new Stack<List<Command>>();
            commandStack.Push(Commands);

            foreach (var line in content)
            {

                int indentLevel = line.TakeWhile(c => c == '\t').Count(); // counts indentation
                string trimmedLine = line.Trim();

                while (indentLevel < currentIndentLevel)
                {
                    commandStack.Pop();
                    currentIndentLevel--;
                }

                if (trimmedLine.StartsWith("Move")) // making Move object
                {
                    int steps = int.Parse(trimmedLine.Substring(5));// number is at index 5
                    commandStack.Peek().Add(new Move(steps));
                }
                else if (trimmedLine.StartsWith("Turn")) // making Turn object
                {
                    Direction direction = trimmedLine.Contains("Left") ? Direction.Left : Direction.Right;
                    commandStack.Peek().Add(new Turn(direction));
                }
                else if (trimmedLine.StartsWith("Repeat")) // making Repeat object
                {
                    int repeatCount = int.Parse(trimmedLine.Substring(7)); // number is at index 7
                    var repeatCommandsList = new List<Command>();
                    var repeat = new Repeat(repeatCount, repeatCommandsList);
                    commandStack.Peek().Add(repeat);
                    commandStack.Push(repeatCommandsList);
                    currentIndentLevel++; // new repeat so increase indent level
                }
            }
        }
    }
}

