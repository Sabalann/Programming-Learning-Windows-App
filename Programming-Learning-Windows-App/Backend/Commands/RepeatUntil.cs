using Programming_Learning_App;

namespace Programming_Learning_Windows_App
{
    public class RepeatUntil : Command
    {
        public List<Command> Commands { get; } = new List<Command>();
        public RepeatUntilType Type { get; }
        public int CommandsCount { get; private set; }
        public int MaxRecursion { get; private set; }
        public int RepeatsCount { get; private set; }

        public RepeatUntil(RepeatUntilType type, List<Command> commands)
        {
            Commands.AddRange(commands);
            Type = type;
            CommandsCount = commands.Count;
            CountMetrics();
        }

        public override void Execute(Character character)
        {
            Console.WriteLine(Display());
            bool shouldContinue = true;
            RepeatsCount = 0;

            while (shouldContinue)
            {
                switch (Type)
                {
                    case RepeatUntilType.GridEdge:
                        shouldContinue = !character.IsAtGridEdge();
                        break;
                    case RepeatUntilType.WallAhead:
                        shouldContinue = !character.IsWallAhead();
                        break;
                }

                if (shouldContinue)
                {
                    foreach (var command in Commands)
                    {
                        command.Execute(character);
                    }

                    RepeatsCount++;
                }
            }
        }

        public override string Display()
        {
            return $"RepeatUntil {Type}";
        }

        private void CountMetrics()
        {
            MaxRecursion = 1;
            foreach (var command in Commands)
            {
                if (command is RepeatUntil repeat)
                {
                    CommandsCount += repeat.CommandsCount;
                    MaxRecursion = Math.Max(MaxRecursion, repeat.MaxRecursion + 1);
                }
                else if (command is Repeat repeat2)
                {
                    CommandsCount += repeat2.CommandsCount;
                    MaxRecursion = Math.Max(MaxRecursion, repeat2.MaxRecursion + 1);
                }
            }
        }
    }
}
