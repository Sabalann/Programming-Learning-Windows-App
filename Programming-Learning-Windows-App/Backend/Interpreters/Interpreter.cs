using System.Text;
using Programming_Learning_App;
using Programming_Learning_Windows_App;

public class Interpreter
{
    public string FormattedCommands { get; private set; }
    public List<Command> Commands { get; } = new();

    public void Interpret(string programText)
    {
        Commands.Clear(); // reset commands list

        var content = programText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None); // split string to lines

        var commandStack = new Stack<(List<Command> Commands, int IndentLevel)>(); // easier hierarchy managing
        commandStack.Push((Commands, -1));

        for (var i = 0; i < content.Length; i++) // goes through each line
        {
            var line = content[i];

            if (string.IsNullOrWhiteSpace(line)) continue; // skip empty lines in case there are any

            var indentLevel = line.TakeWhile(c => c == '\t').Count(); // count indent level
            var trimmedLine = line.Trim();

            while (commandStack.Count > 1 &&
                   commandStack.Peek().IndentLevel >= indentLevel) // adjust based on indent level
                commandStack.Pop();

            var command = parseCommand(trimmedLine);
            if (command != null)
            {
                commandStack.Peek().Commands.Add(command);

                if (command is Repeat repeat) commandStack.Push((repeat.Commands, indentLevel));

                if (command is RepeatUntil repeatUntil) commandStack.Push((repeatUntil.Commands, indentLevel));
            }
        }

        FormattedCommands =
            FormatCommands(Commands,
                0); // update FormattedCommands to display the current state of the program correctly
    }

    private Command parseCommand(string line)
    {
        var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0) return null;

        switch (parts[0])
        {
            case "Move":
                if (parts.Length >= 2 && int.TryParse(parts[1], out var steps))
                    return new Move(steps);
                break;

            case "Turn":
                if (parts.Length >= 2)
                {
                    var direction = parts[1].Equals("Left", StringComparison.OrdinalIgnoreCase)
                        ? Direction.Left
                        : Direction.Right;
                    return new Turn(direction);
                }

                break;

            case "Repeat":
                if (parts.Length >= 2 && int.TryParse(parts[1], out var times))
                    return new Repeat(times, new List<Command>());
                break;

            case "RepeatUntil":
                if (parts.Length >= 2)
                {
                    if (parts[1].Equals("WallAhead", StringComparison.OrdinalIgnoreCase))
                        return new RepeatUntil(RepeatUntilType.WallAhead, new List<Command>());
                    if (parts[1].Equals("GridEdge", StringComparison.OrdinalIgnoreCase))
                        return new RepeatUntil(RepeatUntilType.GridEdge, new List<Command>());
                }

                break;
        }

        return null;
    }

    private string FormatCommands(List<Command> _commands, int indentLevel)
    {
        var sb = new StringBuilder();
        foreach (var command in _commands)
        {
            sb.Append(new string('\t', indentLevel)); // add indentation

            if (command is Repeat repeat) // add repeat text
            {
                sb.AppendLine($"Repeat {repeat.RepeatsCount}");
                sb.Append(FormatCommands(repeat.Commands, indentLevel + 1));
            }
            else
            {
                sb.AppendLine(command.Display().Trim()); // other commands
            }
        }

        return sb.ToString();
    }
}