namespace Programming_Learning_Windows_App
{
    public class Repeat : Command
    {
        List<Command> commands = new List<Command>();

        // for the metrics
        public int CommandsCount = 0;
        public int MaxRecursion = 0;
        public int RepeatsCount = 0;

        public Repeat(int Times, List<Command> commands) 
        {
            for (int i = 0; i < Times; i++) this.commands.AddRange(commands); // adds list of commands to its own list 'Times' times

            CommandsCount = commands.Count;
            CountMetrics();
        }

        public override void Execute(Character Character) 
        {
            foreach (var command in commands)
            {
                command.Execute(Character);
            }
        }

        public override string Display() { return ""; } 

        private void CountMetrics() // should have it's own class based on domain model and class diagram
        {
            foreach (var command in commands)
            {
                if (command is Repeat repeat)
                {
                    CommandsCount += repeat.CommandsCount + 1;
                    RepeatsCount += repeat.RepeatsCount + 1;

                    if (repeat.MaxRecursion > MaxRecursion)
                    {
                        MaxRecursion = repeat.MaxRecursion;
                    }

                }
            }

            MaxRecursion++;
        }
    }
}
