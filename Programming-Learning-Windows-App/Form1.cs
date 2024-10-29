using System.Windows.Forms;

namespace Programming_Learning_Windows_App
{
    public partial class Form1 : Form
    {
        CommandsProgram program = new();
        Interpreter interpreter = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void basicToolStripMenuItem_Click(object sender, EventArgs e) // set basic mode
        {
            string relativePath = @"..\..\..\Backend\Interpreters\BasicTemplate.txt";
            LoadFile(relativePath);
        }

        private void advancedToolStripMenuItem_Click(object sender, EventArgs e)  // set advanced mode
        {
            string relativePath = @"..\..\..\Backend\Interpreters\AdvancedTemplate.txt";
            LoadFile(relativePath);
        }

        private void expertToolStripMenuItem_Click(object sender, EventArgs e)  // set expert mode
        {
            string relativePath = @"..\..\..\Backend\Interpreters\ExpertTemplate.txt";
            LoadFile(relativePath);
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e) // set custom mode
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files|*.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadFile(openFileDialog.FileName);
                }
            }
        }
        private void LoadFile(string path) // helper function
        {
            string fileContents = File.ReadAllText(path);
            interpreter.Interpret(fileContents);
            updateTextBoxCommands();
        }

        private void updateTextBoxCommands()
        {
            TextInput.Text = interpreter.FormattedCommands;
            TextBoxCommands.Clear();
        }

        private void MetricsButton_Click(object sender, EventArgs e)
        {
            TextBoxCommands.Clear();
            interpreter.Interpret(TextInput.Text);
            program.SetMode(interpreter.Commands);
            TextBoxCommands.Text = program.CalculateMetrics();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            TextBoxCommands.Clear();
            interpreter.Interpret(TextInput.Text);
            program.SetMode(interpreter.Commands);
            TextBoxCommands.Text = program.Execute();

        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            TextInput.Clear();
            TextBoxCommands.Clear();
        }
    }
}
