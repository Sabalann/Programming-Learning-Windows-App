using System.Windows.Forms;

namespace Programming_Learning_Windows_App
{
    public partial class Form1 : Form
    {
        private CommandsProgram program;
        private Character character;
        private Grid grid;
        private Interpreter interpreter;

        public Form1()
        {
            InitializeComponent();
            InitializeGrid(10, 10); // Example: 5x5 grid
            grid = new Grid(10, 10);
            character = new Character(grid);
            program = new(character);
            interpreter = new Interpreter(character, grid);
        }

        private void InitializeGrid(int rows, int columns)
        {
            // Clear existing controls and styles
            GridPanel.Controls.Clear();
            GridPanel.RowStyles.Clear();
            GridPanel.ColumnStyles.Clear();

            // Set row and column count
            GridPanel.RowCount = rows;
            GridPanel.ColumnCount = columns;

            // Set row and column styles to equally divide the space
            for (int i = 0; i < rows; i++)
            {
                GridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));
            }
            for (int i = 0; i < columns; i++)
            {
                GridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columns));
            }

            // Populate the grid with labels for each cell without numbers
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Label cellLabel = new Label
                    {
                        BackColor = Color.White, // Default color for unvisited cells
                        Dock = DockStyle.Fill,
                        Margin = new Padding(1),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Text = "" // Set to an empty string to remove the number
                    };
                    GridPanel.Controls.Add(cellLabel, col, row);
                }
            }
        }

        private void HighlightPath(List<(int X, int Y)> path)
        {
            // Reset grid colors before each move
            foreach (Control control in GridPanel.Controls)
            {
                control.BackColor = Color.White;
            }

            // Highlight each cell in the path
            foreach (var (x, y) in path)
            {
                if (x >= 0 && x < GridPanel.ColumnCount && y >= 0 && y < GridPanel.RowCount)
                {
                    Control cell = GridPanel.GetControlFromPosition(x, y);
                    if (cell != null)
                    {
                        cell.BackColor = Color.LightBlue;
                    }
                }
            }
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
            HighlightPath(character.Path);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            TextInput.Clear();
            TextBoxCommands.Clear();
        }
    }
}
