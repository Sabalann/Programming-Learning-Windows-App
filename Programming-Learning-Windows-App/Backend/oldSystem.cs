namespace Programming_Learning_Windows_App
{
    public class oldSystem
    {
        CommandsProgram program = new CommandsProgram();
        

        private void SetProgramType(string input)
        {
            switch (input)
            {
                case "basic":
                    program.SetModeBasic(); break;
                case "advanced":
                    program.SetModeAdvanced(); break;
                case "expert":
                    program.SetModeExpert(); break;
                case "custom":
                    Console.WriteLine("Provide the path to the file");
                    string path = Console.ReadLine();
                    // logic for checking file type
                    break;
                default:
                    throw new ArgumentException("Wrong input");
            }
        }

        private string CheckOutputType(string input)
        {
            switch (input)
            {
                case "metrics":
                    return program.CalculateMetrics();
                case "execute":
                    return program.Execute();
                default:
                    throw new ArgumentException("Wrong input");
            }
        }

    }
}
