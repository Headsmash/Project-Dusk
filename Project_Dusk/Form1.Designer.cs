namespace Project_Dusk
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.JobNumberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LengthTextBox = new System.Windows.Forms.TextBox();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.QuantityTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.PlexiTextBox = new System.Windows.Forms.ComboBox();
            this.RunButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LengthListBox = new System.Windows.Forms.ListBox();
            this.ListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deletePanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearPanelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WidthListBox = new System.Windows.Forms.ListBox();
            this.QuantityListBox = new System.Windows.Forms.ListBox();
            this.EditLengthTextBox = new System.Windows.Forms.TextBox();
            this.EditWidthTextBox = new System.Windows.Forms.TextBox();
            this.EditQuantityTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.EditButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label10 = new System.Windows.Forms.Label();
            this.SaveListButton = new System.Windows.Forms.Button();
            this.LoadListButton = new System.Windows.Forms.Button();
            this.OpenSaveFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ListContextMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Job Number:";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(234, 156);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(101, 25);
            this.ClearButton.TabIndex = 7;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // JobNumberTextBox
            // 
            this.JobNumberTextBox.Location = new System.Drawing.Point(111, 61);
            this.JobNumberTextBox.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.JobNumberTextBox.MaxLength = 7;
            this.JobNumberTextBox.Name = "JobNumberTextBox";
            this.JobNumberTextBox.Size = new System.Drawing.Size(100, 22);
            this.JobNumberTextBox.TabIndex = 0;
            this.JobNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JobNumberTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Plexi Type:";
            // 
            // LengthTextBox
            // 
            this.LengthTextBox.Location = new System.Drawing.Point(111, 169);
            this.LengthTextBox.MaxLength = 4;
            this.LengthTextBox.Name = "LengthTextBox";
            this.LengthTextBox.Size = new System.Drawing.Size(100, 22);
            this.LengthTextBox.TabIndex = 4;
            this.LengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JobNumberTextBox_KeyPress);
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(111, 133);
            this.WidthTextBox.MaxLength = 4;
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(100, 22);
            this.WidthTextBox.TabIndex = 3;
            this.WidthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JobNumberTextBox_KeyPress);
            // 
            // QuantityTextBox
            // 
            this.QuantityTextBox.Location = new System.Drawing.Point(111, 205);
            this.QuantityTextBox.MaxLength = 2;
            this.QuantityTextBox.Name = "QuantityTextBox";
            this.QuantityTextBox.Size = new System.Drawing.Size(100, 22);
            this.QuantityTextBox.TabIndex = 5;
            this.QuantityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JobNumberTextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 172);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Height:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 136);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "Width:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(344, 209);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "Edit:";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(234, 125);
            this.AddButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(101, 25);
            this.AddButton.TabIndex = 8;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // PlexiTextBox
            // 
            this.PlexiTextBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlexiTextBox.FormattingEnabled = true;
            this.PlexiTextBox.Items.AddRange(new object[] {
            "Clear PlexiGlass",
            "Smoked PlexiGlass"});
            this.PlexiTextBox.Location = new System.Drawing.Point(111, 97);
            this.PlexiTextBox.Name = "PlexiTextBox";
            this.PlexiTextBox.Size = new System.Drawing.Size(100, 22);
            this.PlexiTextBox.TabIndex = 1;
            // 
            // RunButton
            // 
            this.RunButton.Enabled = false;
            this.RunButton.Location = new System.Drawing.Point(6, 234);
            this.RunButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(698, 25);
            this.RunButton.TabIndex = 9;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(495, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Height (mm)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(396, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 14);
            this.label7.TabIndex = 10;
            this.label7.Text = "Width (mm)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(591, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 14);
            this.label8.TabIndex = 10;
            this.label8.Text = "Quantity";
            // 
            // LengthListBox
            // 
            this.LengthListBox.ContextMenuStrip = this.ListContextMenu;
            this.LengthListBox.FormattingEnabled = true;
            this.LengthListBox.ItemHeight = 14;
            this.LengthListBox.Location = new System.Drawing.Point(490, 55);
            this.LengthListBox.Name = "LengthListBox";
            this.LengthListBox.Size = new System.Drawing.Size(96, 144);
            this.LengthListBox.TabIndex = 11;
            this.LengthListBox.Click += new System.EventHandler(this.LengthListBox_Click);
            // 
            // ListContextMenu
            // 
            this.ListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deletePanelToolStripMenuItem,
            this.clearPanelsToolStripMenuItem});
            this.ListContextMenu.Name = "ListContextMenu";
            this.ListContextMenu.Size = new System.Drawing.Size(156, 48);
            // 
            // deletePanelToolStripMenuItem
            // 
            this.deletePanelToolStripMenuItem.Name = "deletePanelToolStripMenuItem";
            this.deletePanelToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.deletePanelToolStripMenuItem.Text = "Delete Panel";
            this.deletePanelToolStripMenuItem.Click += new System.EventHandler(this.deletePanelToolStripMenuItem_Click);
            // 
            // clearPanelsToolStripMenuItem
            // 
            this.clearPanelsToolStripMenuItem.Name = "clearPanelsToolStripMenuItem";
            this.clearPanelsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.clearPanelsToolStripMenuItem.Text = "Clear All Panels";
            this.clearPanelsToolStripMenuItem.Click += new System.EventHandler(this.clearPanelsToolStripMenuItem_Click);
            // 
            // WidthListBox
            // 
            this.WidthListBox.ContextMenuStrip = this.ListContextMenu;
            this.WidthListBox.FormattingEnabled = true;
            this.WidthListBox.ItemHeight = 14;
            this.WidthListBox.Location = new System.Drawing.Point(388, 55);
            this.WidthListBox.Name = "WidthListBox";
            this.WidthListBox.Size = new System.Drawing.Size(96, 144);
            this.WidthListBox.TabIndex = 11;
            this.WidthListBox.Click += new System.EventHandler(this.WidthListBox_Click);
            // 
            // QuantityListBox
            // 
            this.QuantityListBox.ContextMenuStrip = this.ListContextMenu;
            this.QuantityListBox.FormattingEnabled = true;
            this.QuantityListBox.ItemHeight = 14;
            this.QuantityListBox.Location = new System.Drawing.Point(592, 56);
            this.QuantityListBox.Name = "QuantityListBox";
            this.QuantityListBox.Size = new System.Drawing.Size(58, 144);
            this.QuantityListBox.TabIndex = 11;
            this.QuantityListBox.Click += new System.EventHandler(this.QuantityListBox_Click);
            // 
            // EditLengthTextBox
            // 
            this.EditLengthTextBox.Location = new System.Drawing.Point(490, 205);
            this.EditLengthTextBox.Name = "EditLengthTextBox";
            this.EditLengthTextBox.Size = new System.Drawing.Size(96, 22);
            this.EditLengthTextBox.TabIndex = 12;
            // 
            // EditWidthTextBox
            // 
            this.EditWidthTextBox.Location = new System.Drawing.Point(388, 205);
            this.EditWidthTextBox.Name = "EditWidthTextBox";
            this.EditWidthTextBox.Size = new System.Drawing.Size(96, 22);
            this.EditWidthTextBox.TabIndex = 12;
            // 
            // EditQuantityTextBox
            // 
            this.EditQuantityTextBox.Location = new System.Drawing.Point(592, 206);
            this.EditQuantityTextBox.Name = "EditQuantityTextBox";
            this.EditQuantityTextBox.Size = new System.Drawing.Size(58, 22);
            this.EditQuantityTextBox.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 209);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "Quantity:";
            // 
            // EditButton
            // 
            this.EditButton.Enabled = false;
            this.EditButton.Location = new System.Drawing.Point(656, 205);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(48, 23);
            this.EditButton.TabIndex = 13;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.preferencesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(708, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 35);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "PlexiGlass Panels";
            // 
            // SaveListButton
            // 
            this.SaveListButton.Enabled = false;
            this.SaveListButton.Location = new System.Drawing.Point(656, 91);
            this.SaveListButton.Name = "SaveListButton";
            this.SaveListButton.Size = new System.Drawing.Size(48, 23);
            this.SaveListButton.TabIndex = 13;
            this.SaveListButton.Text = "Save";
            this.SaveListButton.UseVisualStyleBackColor = true;
            this.SaveListButton.Click += new System.EventHandler(this.SaveListButton_Click);
            // 
            // LoadListButton
            // 
            this.LoadListButton.Location = new System.Drawing.Point(656, 120);
            this.LoadListButton.Name = "LoadListButton";
            this.LoadListButton.Size = new System.Drawing.Size(48, 23);
            this.LoadListButton.TabIndex = 13;
            this.LoadListButton.Text = "Load";
            this.LoadListButton.UseVisualStyleBackColor = true;
            this.LoadListButton.Click += new System.EventHandler(this.LoadListButton_Click);
            // 
            // OpenSaveFileDialog
            // 
            this.OpenSaveFileDialog.Filter = "GPCS files|*.gpcs";
            this.OpenSaveFileDialog.Title = "Open the GPCS file";
            // 
            // Form1
            // 
            this.AcceptButton = this.AddButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 264);
            this.Controls.Add(this.LoadListButton);
            this.Controls.Add(this.SaveListButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.EditQuantityTextBox);
            this.Controls.Add(this.EditWidthTextBox);
            this.Controls.Add(this.EditLengthTextBox);
            this.Controls.Add(this.QuantityListBox);
            this.Controls.Add(this.WidthListBox);
            this.Controls.Add(this.LengthListBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PlexiTextBox);
            this.Controls.Add(this.QuantityTextBox);
            this.Controls.Add(this.WidthTextBox);
            this.Controls.Add(this.LengthTextBox);
            this.Controls.Add(this.JobNumberTextBox);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GPCS 1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ListContextMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TextBox JobNumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LengthTextBox;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.TextBox QuantityTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ComboBox PlexiTextBox;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox LengthListBox;
        private System.Windows.Forms.ListBox WidthListBox;
        private System.Windows.Forms.ListBox QuantityListBox;
        private System.Windows.Forms.TextBox EditLengthTextBox;
        private System.Windows.Forms.TextBox EditWidthTextBox;
        private System.Windows.Forms.TextBox EditQuantityTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ContextMenuStrip ListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem deletePanelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearPanelsToolStripMenuItem;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button SaveListButton;
        private System.Windows.Forms.Button LoadListButton;
        private System.Windows.Forms.OpenFileDialog OpenSaveFileDialog;
    }
}

