﻿namespace Programming_Learning_Windows_App
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RunButton = new Button();
            MetricsButton = new Button();
            TextBoxCommands = new TextBox();
            GridPanel = new TableLayoutPanel();
            menuStrip1 = new MenuStrip();
            loadFileToolStripMenuItem = new ToolStripMenuItem();
            basicToolStripMenuItem = new ToolStripMenuItem();
            advancedToolStripMenuItem = new ToolStripMenuItem();
            expertToolStripMenuItem = new ToolStripMenuItem();
            customToolStripMenuItem = new ToolStripMenuItem();
            exerciseToolStripMenuItem1 = new ToolStripMenuItem();
            exerciseToolStripMenuItem = new ToolStripMenuItem();
            ClearButton = new Button();
            TextInput = new TextBox();
            ErrorTextBox = new TextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // RunButton
            // 
            RunButton.BackColor = Color.CadetBlue;
            RunButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RunButton.ForeColor = Color.White;
            RunButton.Location = new Point(176, 345);
            RunButton.Name = "RunButton";
            RunButton.Size = new Size(82, 33);
            RunButton.TabIndex = 5;
            RunButton.Text = "Run";
            RunButton.UseVisualStyleBackColor = false;
            RunButton.Click += RunButton_Click;
            // 
            // MetricsButton
            // 
            MetricsButton.BackColor = Color.CadetBlue;
            MetricsButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MetricsButton.ForeColor = Color.White;
            MetricsButton.Location = new Point(278, 345);
            MetricsButton.Name = "MetricsButton";
            MetricsButton.Size = new Size(82, 33);
            MetricsButton.TabIndex = 6;
            MetricsButton.Text = "Metrics";
            MetricsButton.UseVisualStyleBackColor = false;
            MetricsButton.Click += MetricsButton_Click;
            // 
            // TextBoxCommands
            // 
            TextBoxCommands.Location = new Point(176, 426);
            TextBoxCommands.Multiline = true;
            TextBoxCommands.Name = "TextBoxCommands";
            TextBoxCommands.ReadOnly = true;
            TextBoxCommands.Size = new Size(289, 124);
            TextBoxCommands.TabIndex = 7;
            TextBoxCommands.Text = "<output>";
            // 
            // GridPanel
            // 
            GridPanel.BackColor = Color.Silver;
            GridPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
            GridPanel.ColumnCount = 4;
            GridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            GridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            GridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            GridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            GridPanel.Location = new Point(502, 38);
            GridPanel.Name = "GridPanel";
            GridPanel.RowCount = 4;
            GridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            GridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            GridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            GridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            GridPanel.Size = new Size(530, 530);
            GridPanel.TabIndex = 9;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveCaption;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { loadFileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1062, 24);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // loadFileToolStripMenuItem
            // 
            loadFileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { basicToolStripMenuItem, advancedToolStripMenuItem, expertToolStripMenuItem, customToolStripMenuItem, exerciseToolStripMenuItem1 });
            loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            loadFileToolStripMenuItem.Size = new Size(66, 20);
            loadFileToolStripMenuItem.Text = "Load File";
            // 
            // basicToolStripMenuItem
            // 
            basicToolStripMenuItem.Name = "basicToolStripMenuItem";
            basicToolStripMenuItem.Size = new Size(180, 22);
            basicToolStripMenuItem.Text = "Basic";
            basicToolStripMenuItem.Click += basicToolStripMenuItem_Click;
            // 
            // advancedToolStripMenuItem
            // 
            advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            advancedToolStripMenuItem.Size = new Size(180, 22);
            advancedToolStripMenuItem.Text = "Advanced";
            advancedToolStripMenuItem.Click += advancedToolStripMenuItem_Click;
            // 
            // expertToolStripMenuItem
            // 
            expertToolStripMenuItem.Name = "expertToolStripMenuItem";
            expertToolStripMenuItem.Size = new Size(180, 22);
            expertToolStripMenuItem.Text = "Expert";
            expertToolStripMenuItem.Click += expertToolStripMenuItem_Click;
            // 
            // customToolStripMenuItem
            // 
            customToolStripMenuItem.Name = "customToolStripMenuItem";
            customToolStripMenuItem.Size = new Size(180, 22);
            customToolStripMenuItem.Text = "Custom";
            customToolStripMenuItem.Click += customToolStripMenuItem_Click;
            // 
            // exerciseToolStripMenuItem1
            // 
            exerciseToolStripMenuItem1.Name = "exerciseToolStripMenuItem1";
            exerciseToolStripMenuItem1.Size = new Size(180, 22);
            exerciseToolStripMenuItem1.Text = "Exercise";
            exerciseToolStripMenuItem1.Click += exerciseToolStripMenuItem1_Click;
            // 
            // exerciseToolStripMenuItem
            // 
            exerciseToolStripMenuItem.Name = "exerciseToolStripMenuItem";
            exerciseToolStripMenuItem.Size = new Size(180, 22);
            exerciseToolStripMenuItem.Text = "Exercise";
            exerciseToolStripMenuItem.Click += exerciseToolStripMenuItem1_Click;
            // 
            // ClearButton
            // 
            ClearButton.BackColor = Color.CadetBlue;
            ClearButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ClearButton.ForeColor = Color.White;
            ClearButton.Location = new Point(383, 345);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(82, 33);
            ClearButton.TabIndex = 12;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = false;
            ClearButton.Click += ClearButton_Click;
            // 
            // TextInput
            // 
            TextInput.AcceptsReturn = true;
            TextInput.AcceptsTab = true;
            TextInput.BorderStyle = BorderStyle.None;
            TextInput.Location = new Point(176, 75);
            TextInput.Multiline = true;
            TextInput.Name = "TextInput";
            TextInput.Size = new Size(289, 264);
            TextInput.TabIndex = 13;
            TextInput.WordWrap = false;
            // 
            // ErrorTextBox
            // 
            ErrorTextBox.BackColor = SystemColors.Control;
            ErrorTextBox.BorderStyle = BorderStyle.FixedSingle;
            ErrorTextBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ErrorTextBox.ForeColor = Color.Green;
            ErrorTextBox.Location = new Point(176, 384);
            ErrorTextBox.Name = "ErrorTextBox";
            ErrorTextBox.ReadOnly = true;
            ErrorTextBox.Size = new Size(289, 33);
            ErrorTextBox.TabIndex = 14;
            ErrorTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 580);
            Controls.Add(ErrorTextBox);
            Controls.Add(TextInput);
            Controls.Add(ClearButton);
            Controls.Add(GridPanel);
            Controls.Add(TextBoxCommands);
            Controls.Add(MetricsButton);
            Controls.Add(RunButton);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Learn To Program";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button RunButton;
        private Button MetricsButton;
        private TextBox TextBoxCommands;
        private GroupBox groupBox2;
        private TableLayoutPanel GridPanel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem loadFileToolStripMenuItem;
        private ToolStripMenuItem basicToolStripMenuItem;
        private ToolStripMenuItem advancedToolStripMenuItem;
        private ToolStripMenuItem expertToolStripMenuItem;
        private ToolStripMenuItem customToolStripMenuItem;
        private ToolStripMenuItem exerciseToolStripMenuItem;
        private Button ClearButton;
        private TextBox TextInput;
        private TextBox ErrorTextBox;
        private ToolStripMenuItem exerciseToolStripMenuItem1;
    }
}
