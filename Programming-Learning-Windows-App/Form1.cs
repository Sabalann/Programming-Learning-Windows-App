namespace Programming_Learning_Windows_App
{
    public partial class Form1 : Form
    {
        CommandsProgram program = new();
        private Point originalPosition;
        private Button? lastAddedButton;
        public Form1()
        {
            InitializeComponent();

        }

        // Program type selection
        private void basicToolStripMenuItem_Click(object sender, EventArgs e) { program.SetModeBasic(); } // basic mode
        private void advancedToolStripMenuItem_Click(object sender, EventArgs e) { program.SetModeAdvanced(); } // advanced mode
        private void expertToolStripMenuItem_Click(object sender, EventArgs e) { program.SetModeExpert(); } // expert mode
        private void customToolStripMenuItem_Click(object sender, EventArgs e) // custom mode
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    TXTFileInterpreter interpreter = new TXTFileInterpreter(filePath);
                    program.SetModeCustom(interpreter.GetCommandsList());
                }
            }
        }

        private void MetricsButton_Click(object sender, EventArgs e)
        {
            TextBoxCommands.Text = program.CalculateMetrics(); // temporary test
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            program.Execute();
            TextInput.Text = program.ShowProgram();
        }

        private void Button_MouseDown(object? sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                originalPosition = button.Location; // Store the original position
                button.DoDragDrop(button, DragDropEffects.Move);
            }
        }

        private void Button_MouseUp(object? sender, MouseEventArgs e)
        {
            if (sender is Button button && e.Button == MouseButtons.Right)
            {
                // Remove the button from the FlowLayoutPanel and the form's controls
                commandsFlowLayoutPanel.Controls.Remove(button);
                Controls.Remove(button);
                button.Dispose();
            }
        }


        private void FlowLayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(typeof(Button)) == true)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FlowLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data?.GetData(typeof(Button)) is Button button)
            {
                // Add the button to the FlowLayoutPanel if not already present
                if (!commandsFlowLayoutPanel.Controls.Contains(button))
                {
                    commandsFlowLayoutPanel.Controls.Add(button);

                    // Create a new button of the same type at the original position
                    Button newButton = new Button
                    {
                        Text = button.Text,
                        Location = originalPosition, // Use the stored original position
                        Size = button.Size,
                        BackColor = button.BackColor,
                        Font = button.Font,
                        ForeColor = button.ForeColor,

                    };

                    if (lastAddedButton != null && lastAddedButton.Text == "Repeat")
                    {
                        newButton.Margin = new Padding(lastAddedButton != null ? lastAddedButton.Margin.Left + 20 : newButton.Margin.Left + 20, newButton.Margin.Top, newButton.Margin.Right, newButton.Margin.Bottom);
                    }

                    newButton.MouseDown += Button_MouseDown;
                    newButton.MouseUp += Button_MouseUp;
                    lastAddedButton = newButton;
                    Controls.Add(newButton);
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            commandsFlowLayoutPanel.Controls.Clear();
            lastAddedButton = null;
        }
    }
}
