using Programming_Learning_App;

namespace Programming_Learning_Windows_App;

public class RepeatUntil : Command
{
    public RepeatUntil(RepeatUntilType type, List<Command> commands)
    {
        Commands.AddRange(commands);
        Type = type;
        CommandsCount = commands.Count;
        CountCommands();
    }

    public List<Command> Commands { get; } = new();
    private RepeatUntilType Type { get; }
    public int CommandsCount { get; private set; }
    public int MaxRecursion { get; private set; }
    public int RepeatsCount { get; private set; }

    public override void Execute(Character character)
    {
        RepeatsCount = 0;

        while (ShouldContinue(character))
        {
            foreach (var command in Commands) command.Execute(character);

            RepeatsCount++;
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

    private void CountCommands()
    {
        int count = 1;
        int countRepeats = 1;

        foreach (var command in Commands)
        {
            if (command is Repeat repeat)
            {
                count += repeat.CommandsCount;
                countRepeats += repeat.RepeatsCount;
            }
            else if (command is RepeatUntil repeatUntil)
            {
                count += repeatUntil.CommandsCount;
                countRepeats += repeatUntil.RepeatsCount;
            }
            else count++;

        }
    }
}