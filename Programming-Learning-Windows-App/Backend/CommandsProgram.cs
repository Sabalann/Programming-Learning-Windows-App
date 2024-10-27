namespace Programming_Learning_Windows_App
{
    public class CommandsProgram
    {

        Character Character = new Character();
        List<Command> commands = new List<Command>();
        string commandslist = "";

        public string Execute()
        {

            foreach (Command command in commands)
            {
                command.Execute(Character);
                commandslist += command.Display();
            }

            return "\n" + "End state " + Character.Position.ToString() + " facing " + Character.Facing;
        }

        public string CalculateMetrics()
        {
            return "Total commands: " + CountCommands() + "\n" +
                   "Max nesting level: " + CountMaxNesting() + "\n" +
                   "Total repeats: " + CountRepeats();
        }

        public string ShowProgram()
        {
            return commandslist;
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


        public void SetModeBasic()
        {
            commands.Clear();

            commands.AddRange(new List<Command>
               {
                   new Turn(Direction.Right),
                   new Move(3),
                   new Turn(Direction.Right),
                   new Move(2),
                   new Turn(Direction.Left),
               });
        }

        public void SetModeAdvanced()
        {
            commands.Clear();

            List<Command> repeatList = new List<Command>
            {
                new Move(5),
                new Turn(Direction.Left),
                new Move(3),
            };

            commands.AddRange(new List<Command>
            {
                new Repeat(3, repeatList),
                new Turn(Direction.Right)
            });
        }

        public void SetModeExpert()
        {
            commands.Clear();

            List<Command> nestedRepeatList = new List<Command>
            {
                new Move(3),
                new Turn(Direction.Right),
                new Move(6),
            };

            List<Command> repeatList = new List<Command>
            {
                new Move(5),
                new Repeat(2, nestedRepeatList),
                new Turn(Direction.Left),
                new Move(3),
            };

            commands.AddRange(new List<Command>
            {
                new Repeat(2, repeatList),
                new Turn(Direction.Left)
            });
        }

        public void SetModeCustom(List<Command> Commands)
        {
            commands.Clear();
            commands = Commands;
        }
    }
}