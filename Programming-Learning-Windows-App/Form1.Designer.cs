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
            ClearButton = new Button();
            TextInput = new TextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // RunButton
            // 
            RunButton.BackColor = Color.CadetBlue;
            RunButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RunButton.ForeColor = Color.White;
            RunButton.Location = new Point(251, 575);
            RunButton.Margin = new Padding(4, 5, 4, 5);
            RunButton.Name = "RunButton";
            RunButton.Size = new Size(117, 55);
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
            MetricsButton.Location = new Point(397, 575);
            MetricsButton.Margin = new Padding(4, 5, 4, 5);
            MetricsButton.Name = "MetricsButton";
            MetricsButton.Size = new Size(117, 55);
            MetricsButton.TabIndex = 6;
            MetricsButton.Text = "Metrics";
            MetricsButton.UseVisualStyleBackColor = false;
            MetricsButton.Click += MetricsButton_Click;
            // 
            // TextBoxCommands
            // 
            TextBoxCommands.Location = new Point(251, 710);
            TextBoxCommands.Margin = new Padding(4, 5, 4, 5);
            TextBoxCommands.Multiline = true;
            TextBoxCommands.Name = "TextBoxCommands";
            TextBoxCommands.ReadOnly = true;
            TextBoxCommands.Size = new Size(411, 204);
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
            GridPanel.Location = new Point(741, 125);
            GridPanel.Margin = new Padding(4, 5, 4, 5);
            GridPanel.Name = "GridPanel";
            GridPanel.RowCount = 4;
            GridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            GridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            GridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            GridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            GridPanel.Size = new Size(410, 440);
            GridPanel.TabIndex = 9;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveCaption;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { loadFileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(1517, 35);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // loadFileToolStripMenuItem
            // 
            loadFileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { basicToolStripMenuItem, advancedToolStripMenuItem, expertToolStripMenuItem, customToolStripMenuItem });
            loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            loadFileToolStripMenuItem.Size = new Size(98, 29);
            loadFileToolStripMenuItem.Text = "Load File";
            // 
            // basicToolStripMenuItem
            // 
            basicToolStripMenuItem.Name = "basicToolStripMenuItem";
            basicToolStripMenuItem.Size = new Size(193, 34);
            basicToolStripMenuItem.Text = "Basic";
            basicToolStripMenuItem.Click += basicToolStripMenuItem_Click;
            // 
            // advancedToolStripMenuItem
            // 
            advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            advancedToolStripMenuItem.Size = new Size(193, 34);
            advancedToolStripMenuItem.Text = "Advanced";
            advancedToolStripMenuItem.Click += advancedToolStripMenuItem_Click;
            // 
            // expertToolStripMenuItem
            // 
            expertToolStripMenuItem.Name = "expertToolStripMenuItem";
            expertToolStripMenuItem.Size = new Size(193, 34);
            expertToolStripMenuItem.Text = "Expert";
            expertToolStripMenuItem.Click += expertToolStripMenuItem_Click;
            // 
            // customToolStripMenuItem
            // 
            customToolStripMenuItem.Name = "customToolStripMenuItem";
            customToolStripMenuItem.Size = new Size(193, 34);
            customToolStripMenuItem.Text = "Custom";
            customToolStripMenuItem.Click += customToolStripMenuItem_Click;
            // 
            // ClearButton
            // 
            ClearButton.BackColor = Color.CadetBlue;
            ClearButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ClearButton.ForeColor = Color.White;
            ClearButton.Location = new Point(547, 575);
            ClearButton.Margin = new Padding(4, 5, 4, 5);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(117, 55);
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
            TextInput.Location = new Point(251, 125);
            TextInput.Margin = new Padding(4, 5, 4, 5);
            TextInput.Multiline = true;
            TextInput.Name = "TextInput";
            TextInput.Size = new Size(413, 440);
            TextInput.TabIndex = 13;
            TextInput.WordWrap = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1517, 966);
            Controls.Add(TextInput);
            Controls.Add(ClearButton);
            Controls.Add(GridPanel);
            Controls.Add(TextBoxCommands);
            Controls.Add(MetricsButton);
            Controls.Add(RunButton);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
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
        private Button ClearButton;
        private TextBox TextInput;
    }
}
