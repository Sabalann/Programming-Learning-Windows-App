using Programming_Learning_App;

namespace Programming_Learning_Windows_App
{
    public class RepeatUntil : Command
    {
        public List<Command> Commands { get; } = new();
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
            RepeatsCount = 0;

            while (ShouldContinue(character))
            { 
                foreach (var command in Commands)
                {
                       command.Execute(character);
                }

                RepeatsCount++;
                System.Diagnostics.Debug.WriteLine($"RepeatsCount: {RepeatsCount}, Position: {character.Position}, Facing: {character.Facing}, WallAhead: {character.IsWallAhead()}");


            }
        }

        private bool ShouldContinue(Character character)
        {
            switch (Type)
            {
                case RepeatUntilType.GridEdge:
                    return !character.IsAtGridEdge();
                case RepeatUntilType.WallAhead:
                    return !character.IsWallAhead();
                default:
                    return false;
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
