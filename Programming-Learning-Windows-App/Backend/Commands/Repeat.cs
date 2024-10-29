using Programming_Learning_Windows_App;

namespace Programming_Learning_App
{
    public class Repeat : Command
    {
        public List<Command> Commands { get; } = new List<Command>();
        public int CommandsCount { get; private set; }
        public int RepeatsCount { get; private set; }
        public int MaxRecursion { get; private set; }

        public Repeat(int times, List<Command> commands)
        {
            Commands.AddRange(commands);
            CommandsCount = commands.Count;
            RepeatsCount = times;
            CountMetrics();
        }

        public override void Execute(Character character)
        {
            Console.WriteLine(Display());

            for (int i = 0; i < RepeatsCount; i++)
            {
                foreach (var command in Commands)
                {
                    command.Execute(character);
                }
            }

        }

        public override string Display()
        {
            return $"Repeat {RepeatsCount}";
        }

        private void CountMetrics()
        {
            MaxRecursion = 1;
            foreach (var command in Commands)
            {
                if (command is Repeat repeat)
                {
                    CommandsCount += repeat.CommandsCount;
                    RepeatsCount += repeat.RepeatsCount;
                    MaxRecursion = Math.Max(MaxRecursion, repeat.MaxRecursion + 1);
                }
            }
        }
    }
}
