using Programming_Learning_App;
using Programming_Learning_Windows_App;
using System.Text;

public class Interpreter
{
    private string programText;
    public string FormattedCommands;
    public List<Command> Commands { get; private set; } = new List<Command>();

    public Interpreter()
    {
    }

    public void Interpret(string programText)
    {
        Commands.Clear(); // reset commands list

        var content = programText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None); // split string to lines

        var commandStack = new Stack<(List<Command> Commands, int IndentLevel)>(); // easier hierarchy managing
        commandStack.Push((Commands, -1));

        for (int i = 0; i < content.Length; i++) // goes through each line
        {
            string line = content[i];

            if (string.IsNullOrWhiteSpace(line)) continue; // skip empty lines incase there are any

            int indentLevel = line.TakeWhile(c => c == '\t').Count(); // count indent level
            string trimmedLine = line.Trim();

            while (commandStack.Count > 1 && commandStack.Peek().IndentLevel >= indentLevel) // adjust based on indent level
            {
                commandStack.Pop();
            }

            Command command = parseCommand(trimmedLine);
            if (command != null)
            {
                commandStack.Peek().Commands.Add(command);

                if (command is Repeat repeat)
                {
                    commandStack.Push((repeat.Commands, indentLevel));
                }
            }
        }

        FormattedCommands = FormatCommands(Commands, 0); // update FormattedCommands to display the current state of the program correctly
    }



    private Command parseCommand(string line)
    {
        string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0) return null;

        switch (parts[0])
        {
            case "Move":
                if (parts.Length >= 2 && int.TryParse(parts[1], out int steps))
                    return new Move(steps);
                break;

            case "Turn":
                if (parts.Length >= 2)
                {
                    Direction direction = parts[1].Equals("Left", StringComparison.OrdinalIgnoreCase)
                        ? Direction.Left
                        : Direction.Right;
                    return new Turn(direction);
                }
                break;

            case "Repeat":
                if (parts.Length >= 2 && int.TryParse(parts[1], out int times))
                    return new Repeat(times, new List<Command>());
                break;
        }

        return null;
    }


    public string FormatCommands(List<Command> _commands, int indentLevel)
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