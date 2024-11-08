namespace Programming_Learning_Windows_App;

namespace Programming_Learning_Windows_App
{
    public partial class Form1 : Form
    {
        private CommandsProgram program;
        private Character character;
        private Grid grid;
        private Interpreter interpreter;
        public static Form1 Instance { get; private set; }
        private bool isGridInitialized = false;

        public Form1()
        {
            InitializeComponent();
            Instance = this;
            grid = new Grid(10, 10);
            ResetGrid();
            InitializeGrid(10, 10);

        // Calculate the size of each grid cell
        var cellWidth = GridPanel.Width / GridPanel.ColumnCount;
        var cellHeight = GridPanel.Height / GridPanel.RowCount;
        var cellSize = new Size(cellWidth, cellHeight);


        // Initialize PictureBox controls for each direction
        var imgNorth = new PictureBox
        {
            Image = Image.FromFile(@"..\..\..\Backend\characterIMGS\character_north.png"),
            Size = cellSize
        };
        var imgEast = new PictureBox
        {
            Image = Image.FromFile(@"..\..\..\Backend\characterIMGS\character_east.png"),
            Size = cellSize
        };
        var imgSouth = new PictureBox
        {
            Image = Image.FromFile(@"..\..\..\Backend\characterIMGS\character_south.png"),
            Size = cellSize
        };
        var imgWest = new PictureBox
        {
            Image = Image.FromFile(@"..\..\..\Backend\characterIMGS\character_west.png"),
            Size = cellSize
        };

        // Add PictureBox controls to the form
        Controls.Add(imgNorth);
        Controls.Add(imgEast);
        Controls.Add(imgSouth);
        Controls.Add(imgWest);

        imgNorth.BringToFront();
        imgEast.BringToFront();
        imgSouth.BringToFront();
        imgWest.BringToFront();

        character = new Character(grid, imgNorth, imgEast, imgSouth, imgWest);
        program = new CommandsProgram(character);
        interpreter = new Interpreter();
    }

        private void InitializeGrid(int rows, int columns)
        {

            if (isGridInitialized) return;

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
                        Dock = DockStyle.Fill,
                        Margin = new Padding(1),
                    };

                    GridPanel.Controls.Add(cellLabel, col, row);
                }
            }

            isGridInitialized = true; // Mark as initialized

        }

        private void UpdateGridDisplay()
        {
            // Reset the colors of all cells to default
            foreach (Control control in GridPanel.Controls)
            {
                control.BackColor = Color.White;
            }

            // Set wall positions
            foreach (var (x, y) in grid.Walls)
            {
                if (x >= 0 && x < GridPanel.ColumnCount && y >= 0 && y < GridPanel.RowCount)
                {
                    Control cell = GridPanel.GetControlFromPosition(x, y);
                    if (cell != null)
                    {
                        cell.BackColor = Color.RebeccaPurple;
                    }
                }
            }

            if (grid.EndPosition.X >= 0 && grid.EndPosition.X < GridPanel.ColumnCount &&
                grid.EndPosition.Y >= 0 && grid.EndPosition.Y < GridPanel.RowCount)
            {
                Control endCell = GridPanel.GetControlFromPosition(grid.EndPosition.X, grid.EndPosition.Y);
                if (endCell != null)
                {
                    endCell.BackColor = Color.Pink;
                }
            }
        }


        private void HighlightPath(List<(int X, int Y)> path)
        {
            ResetGrid();

        // Highlight each cell in the path
        foreach (var (x, y) in path)
            if (x >= 0 && x < GridPanel.ColumnCount && y >= 0 && y < GridPanel.RowCount)
            {
                var cell = GridPanel.GetControlFromPosition(x, y);
                if (cell != null) cell.BackColor = Color.LightBlue;
            }
    }

    private void basicToolStripMenuItem_Click(object sender, EventArgs e) // set basic mode
    {
        var relativePath = @"..\..\..\Backend\Interpreters\BasicTemplate.txt";
        LoadFile(relativePath);
    }

    private void advancedToolStripMenuItem_Click(object sender, EventArgs e) // set advanced mode
    {
        var relativePath = @"..\..\..\Backend\Interpreters\AdvancedTemplate.txt";
        LoadFile(relativePath);
    }

    private void expertToolStripMenuItem_Click(object sender, EventArgs e) // set expert mode
    {
        var relativePath = @"..\..\..\Backend\Interpreters\ExpertTemplate.txt";
        LoadFile(relativePath);
    }

    private void customToolStripMenuItem_Click(object sender, EventArgs e) // set custom mode
    {
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK) LoadFile(openFileDialog.FileName);
        }
    }

        private void exerciseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files|*.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadExercise(openFileDialog.FileName);
                }
            }
        }



        private void LoadFile(string path)
        {
            string fileContents = File.ReadAllText(path);
            interpreter.Interpret(fileContents);
            UpdateTextBoxCommands();
        }

        private void LoadExercise(string path)
        {
            string fileContents = File.ReadAllText(path);
            interpreter.LoadGridFromFile(fileContents);
            UpdateGridDisplay();
            UpdateTextBoxCommands();
        }

        private void UpdateTextBoxCommands()
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
        ResetProgram();
        interpreter.Interpret(TextInput.Text);
        program.SetMode(interpreter.Commands);
        TextBoxCommands.Text = program.Execute();
        HighlightPath(character.Path);
    }

    private void ClearButton_Click(object sender, EventArgs e)
    {
        TextInput.Clear();
        ResetProgram();
    }

    private void ResetProgram()
    {
        TextBoxCommands.Clear();
        character.Reset();
        ResetGrid();
    }

        private void ResetGrid()
        {
            foreach (Control control in GridPanel.Controls) control.BackColor = Color.White;
            foreach (var (x, y) in grid.Walls)
            {
                if (x >= 0 && x < GridPanel.ColumnCount && y >= 0 && y < GridPanel.RowCount)
                {
                    Control cell = GridPanel.GetControlFromPosition(x, y);
                    if (cell != null)
                    {
                        cell.BackColor = Color.RebeccaPurple;
                    }

                }
            }

            if (grid.EndPosition.X >= 0 && grid.EndPosition.X < GridPanel.ColumnCount &&
                grid.EndPosition.Y >= 0 && grid.EndPosition.Y < GridPanel.RowCount)
            {
                Control endCell = GridPanel.GetControlFromPosition(grid.EndPosition.X, grid.EndPosition.Y);
                if (endCell != null)
                {
                    endCell.BackColor = Color.Pink;
                }
            }
    }

        public void DisplayErrorMessage(string message)
        {
            ErrorTextBox.Text = message;
            if (message != "Success") ErrorTextBox.ForeColor = Color.Red;
            else ErrorTextBox.ForeColor = Color.Green;
        }

        
    }
}