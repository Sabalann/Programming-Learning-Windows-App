using Programming_Learning_App;

namespace Programming_Learning_Windows_App
{
    public class CommandsProgram
    {

        Character Character = new Character();
        List<Command> commands = new List<Command>();

        public string Execute()
        {
            foreach (Command command in commands)
            {
                command.Execute(Character);

            }

            return "\n" + "End state " + Character.Position.ToString() + " facing " + Character.Facing + "\n" + "  -  Path: " + Character.GetPathString();
        }

        public string CalculateMetrics()
        {
            return "Total commands: " + CountCommands() + Environment.NewLine +
                   "Max nesting level: " + CountMaxNesting() + Environment.NewLine +
                   "Total repeats: " + CountRepeats();
        }

        private int CountCommands()
        {
            int commandsCount = commands.Count;

            foreach (Command command in commands)
            {
                if (command is Repeat repeat) commandsCount += repeat.CommandsCount;
            }

            return commandsCount;
        }

        private int CountRepeats()
        {

            int repeatsCount = 0;

            foreach (Command command in commands)
            {
                if (command is Repeat repeat) { repeatsCount += repeat.RepeatsCount + 1; }
            }

            return repeatsCount;
        }

        private int CountMaxNesting()
        {
            int maxLevel = 0;

            foreach (var command in commands)
            {
                if (command is Repeat repeat && repeat.MaxRecursion > maxLevel)
                    maxLevel = repeat.MaxRecursion;
            }

            return maxLevel;
        }

        public void SetMode(List<Command> Commands)
        {
            commands.Clear();
            commands.AddRange(Commands);
        }

    }
}  