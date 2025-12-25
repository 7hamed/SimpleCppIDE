namespace SimpleCppIDE
{
    partial class frmIDE
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
            this.btnCompile = new System.Windows.Forms.Button();
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTerminal = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.lblSaveFlag = new System.Windows.Forms.Label();
            this.cbOpenedFiles = new System.Windows.Forms.ComboBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnFileInfo = new System.Windows.Forms.Button();
            this.ofdIDE = new System.Windows.Forms.OpenFileDialog();
            this.rtxtCodeEditor = new System.Windows.Forms.RichTextBox();
            this.sfdIDE = new System.Windows.Forms.SaveFileDialog();
            this.rtxtTerminal = new System.Windows.Forms.RichTextBox();
            this.pTerminal = new System.Windows.Forms.Panel();
            this.lblTerminalTitle = new System.Windows.Forms.Label();
            this.btnCloseTerminal = new System.Windows.Forms.Button();
            this.tsmPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCut = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pTerminal.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCompile
            // 
            this.btnCompile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompile.Location = new System.Drawing.Point(97, 19);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(90, 29);
            this.btnCompile.TabIndex = 1;
            this.btnCompile.TabStop = false;
            this.btnCompile.Text = "Compile";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            // 
            // msMainMenu
            // 
            this.msMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile,
            this.tsmEdit,
            this.viewToolStripMenuItem});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(984, 28);
            this.msMainMenu.TabIndex = 2;
            this.msMainMenu.Text = "menuStrip1";
            // 
            // tsmFile
            // 
            this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNew,
            this.tsmOpen,
            this.tsmSave,
            this.tsmClose});
            this.tsmFile.Name = "tsmFile";
            this.tsmFile.Size = new System.Drawing.Size(46, 24);
            this.tsmFile.Text = "&File";
            // 
            // tsmNew
            // 
            this.tsmNew.Name = "tsmNew";
            this.tsmNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmNew.Size = new System.Drawing.Size(224, 26);
            this.tsmNew.Text = "&New";
            this.tsmNew.Click += new System.EventHandler(this.tsmNew_Click);
            // 
            // tsmOpen
            // 
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmOpen.Size = new System.Drawing.Size(224, 26);
            this.tsmOpen.Text = "&Open";
            this.tsmOpen.Click += new System.EventHandler(this.tsmOpen_Click);
            // 
            // tsmSave
            // 
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmSave.Size = new System.Drawing.Size(224, 26);
            this.tsmSave.Text = "&Save";
            this.tsmSave.Click += new System.EventHandler(this.tsmSave_Click);
            // 
            // tsmClose
            // 
            this.tsmClose.Name = "tsmClose";
            this.tsmClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.tsmClose.Size = new System.Drawing.Size(224, 26);
            this.tsmClose.Text = "&Close";
            this.tsmClose.Click += new System.EventHandler(this.tsmClose_Click);
            // 
            // tsmEdit
            // 
            this.tsmEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmUndo,
            this.tsmRedo,
            this.tsmCopy,
            this.tsmPaste,
            this.tsmCut});
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(49, 24);
            this.tsmEdit.Text = "&Edit";
            // 
            // tsmUndo
            // 
            this.tsmUndo.Name = "tsmUndo";
            this.tsmUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.tsmUndo.Size = new System.Drawing.Size(224, 26);
            this.tsmUndo.Text = "&Undo";
            this.tsmUndo.Click += new System.EventHandler(this.tsmUndo_Click);
            // 
            // tsmRedo
            // 
            this.tsmRedo.Name = "tsmRedo";
            this.tsmRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.tsmRedo.Size = new System.Drawing.Size(224, 26);
            this.tsmRedo.Text = "&Redo";
            this.tsmRedo.Click += new System.EventHandler(this.tsmRedo_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmTerminal});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // tsmTerminal
            // 
            this.tsmTerminal.Name = "tsmTerminal";
            this.tsmTerminal.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.tsmTerminal.Size = new System.Drawing.Size(199, 26);
            this.tsmTerminal.Text = "&Terminal";
            this.tsmTerminal.Click += new System.EventHandler(this.tsmTerminal_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRedo);
            this.groupBox1.Controls.Add(this.btnUndo);
            this.groupBox1.Controls.Add(this.lblSaveFlag);
            this.groupBox1.Controls.Add(this.cbOpenedFiles);
            this.groupBox1.Controls.Add(this.btnRun);
            this.groupBox1.Controls.Add(this.btnCompile);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 60);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnRedo
            // 
            this.btnRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedo.Location = new System.Drawing.Point(410, 19);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(90, 29);
            this.btnRedo.TabIndex = 8;
            this.btnRedo.TabStop = false;
            this.btnRedo.Text = "Redo";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Location = new System.Drawing.Point(306, 19);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(90, 29);
            this.btnUndo.TabIndex = 7;
            this.btnUndo.TabStop = false;
            this.btnUndo.Text = "undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // lblSaveFlag
            // 
            this.lblSaveFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaveFlag.Location = new System.Drawing.Point(542, 23);
            this.lblSaveFlag.Name = "lblSaveFlag";
            this.lblSaveFlag.Size = new System.Drawing.Size(100, 23);
            this.lblSaveFlag.TabIndex = 6;
            this.lblSaveFlag.Text = "not save";
            this.lblSaveFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbOpenedFiles
            // 
            this.cbOpenedFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOpenedFiles.FormattingEnabled = true;
            this.cbOpenedFiles.Location = new System.Drawing.Point(648, 22);
            this.cbOpenedFiles.Name = "cbOpenedFiles";
            this.cbOpenedFiles.Size = new System.Drawing.Size(261, 24);
            this.cbOpenedFiles.TabIndex = 5;
            this.cbOpenedFiles.DropDown += new System.EventHandler(this.cbOpenedFiles_DropDown);
            this.cbOpenedFiles.SelectionChangeCommitted += new System.EventHandler(this.cbOpenedFiles_SelectionChangeCommitted);
            this.cbOpenedFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbOpenedFiles_KeyDown);
            // 
            // btnRun
            // 
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Location = new System.Drawing.Point(203, 19);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(90, 29);
            this.btnRun.TabIndex = 2;
            this.btnRun.TabStop = false;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnFileInfo
            // 
            this.btnFileInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileInfo.Location = new System.Drawing.Point(936, 118);
            this.btnFileInfo.Name = "btnFileInfo";
            this.btnFileInfo.Size = new System.Drawing.Size(90, 29);
            this.btnFileInfo.TabIndex = 3;
            this.btnFileInfo.Text = "FIle Info";
            this.btnFileInfo.UseVisualStyleBackColor = true;
            this.btnFileInfo.Visible = false;
            this.btnFileInfo.Click += new System.EventHandler(this.btnFileInfo_Click);
            // 
            // ofdIDE
            // 
            this.ofdIDE.DefaultExt = "cpp";
            this.ofdIDE.Filter = "C++ Files|*.cpp|All Files|*.*";
            this.ofdIDE.Title = "Open Cpp File";
            // 
            // rtxtCodeEditor
            // 
            this.rtxtCodeEditor.AcceptsTab = true;
            this.rtxtCodeEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtCodeEditor.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtCodeEditor.Location = new System.Drawing.Point(49, 105);
            this.rtxtCodeEditor.Name = "rtxtCodeEditor";
            this.rtxtCodeEditor.Size = new System.Drawing.Size(881, 507);
            this.rtxtCodeEditor.TabIndex = 4;
            this.rtxtCodeEditor.Text = "";
            this.rtxtCodeEditor.WordWrap = false;
            this.rtxtCodeEditor.TextChanged += new System.EventHandler(this.rtxtCodeEditor_TextChanged);
            this.rtxtCodeEditor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtCodeEditor_KeyPress);
            // 
            // sfdIDE
            // 
            this.sfdIDE.DefaultExt = "cpp";
            this.sfdIDE.Filter = "C++ Files|*.cpp|All Files|*.*";
            this.sfdIDE.Title = "Save Cpp File";
            // 
            // rtxtTerminal
            // 
            this.rtxtTerminal.AcceptsTab = true;
            this.rtxtTerminal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.rtxtTerminal.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtTerminal.Location = new System.Drawing.Point(3, 27);
            this.rtxtTerminal.Name = "rtxtTerminal";
            this.rtxtTerminal.Size = new System.Drawing.Size(875, 203);
            this.rtxtTerminal.TabIndex = 5;
            this.rtxtTerminal.Text = "";
            // 
            // pTerminal
            // 
            this.pTerminal.BackColor = System.Drawing.Color.White;
            this.pTerminal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTerminal.Controls.Add(this.lblTerminalTitle);
            this.pTerminal.Controls.Add(this.btnCloseTerminal);
            this.pTerminal.Controls.Add(this.rtxtTerminal);
            this.pTerminal.Location = new System.Drawing.Point(49, 635);
            this.pTerminal.Name = "pTerminal";
            this.pTerminal.Size = new System.Drawing.Size(881, 233);
            this.pTerminal.TabIndex = 6;
            // 
            // lblTerminalTitle
            // 
            this.lblTerminalTitle.AutoSize = true;
            this.lblTerminalTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerminalTitle.Location = new System.Drawing.Point(3, 4);
            this.lblTerminalTitle.Name = "lblTerminalTitle";
            this.lblTerminalTitle.Size = new System.Drawing.Size(82, 20);
            this.lblTerminalTitle.TabIndex = 7;
            this.lblTerminalTitle.Text = "Terminal";
            // 
            // btnCloseTerminal
            // 
            this.btnCloseTerminal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCloseTerminal.FlatAppearance.BorderSize = 0;
            this.btnCloseTerminal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseTerminal.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseTerminal.Location = new System.Drawing.Point(855, 4);
            this.btnCloseTerminal.Name = "btnCloseTerminal";
            this.btnCloseTerminal.Size = new System.Drawing.Size(19, 20);
            this.btnCloseTerminal.TabIndex = 6;
            this.btnCloseTerminal.Text = "X";
            this.btnCloseTerminal.UseVisualStyleBackColor = false;
            this.btnCloseTerminal.Click += new System.EventHandler(this.btnCloseTerminal_Click);
            // 
            // tsmPaste
            // 
            this.tsmPaste.Name = "tsmPaste";
            this.tsmPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmPaste.Size = new System.Drawing.Size(224, 26);
            this.tsmPaste.Text = "&Paste";
            this.tsmPaste.Click += new System.EventHandler(this.tsmPaste_Click);
            // 
            // tsmCopy
            // 
            this.tsmCopy.Name = "tsmCopy";
            this.tsmCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmCopy.Size = new System.Drawing.Size(224, 26);
            this.tsmCopy.Text = "&Copy";
            this.tsmCopy.Click += new System.EventHandler(this.tsmCopy_Click);
            // 
            // tsmCut
            // 
            this.tsmCut.Name = "tsmCut";
            this.tsmCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmCut.Size = new System.Drawing.Size(224, 26);
            this.tsmCut.Text = "Cu&t";
            this.tsmCut.Click += new System.EventHandler(this.tsmCut_Click);
            // 
            // frmIDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 880);
            this.Controls.Add(this.pTerminal);
            this.Controls.Add(this.rtxtCodeEditor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFileInfo);
            this.Controls.Add(this.msMainMenu);
            this.MainMenuStrip = this.msMainMenu;
            this.Name = "frmIDE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIDE_FormClosing);
            this.Load += new System.EventHandler(this.frmIDE_Load);
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.pTerminal.ResumeLayout(false);
            this.pTerminal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmFile;
        private System.Windows.Forms.ToolStripMenuItem tsmNew;
        private System.Windows.Forms.ToolStripMenuItem tsmOpen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem tsmSave;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.OpenFileDialog ofdIDE;
        private System.Windows.Forms.RichTextBox rtxtCodeEditor;
        private System.Windows.Forms.Button btnFileInfo;
        private System.Windows.Forms.SaveFileDialog sfdIDE;
        private System.Windows.Forms.ComboBox cbOpenedFiles;
        private System.Windows.Forms.Label lblSaveFlag;
        private System.Windows.Forms.ToolStripMenuItem tsmClose;
        private System.Windows.Forms.RichTextBox rtxtTerminal;
        private System.Windows.Forms.Panel pTerminal;
        private System.Windows.Forms.Button btnCloseTerminal;
        private System.Windows.Forms.Label lblTerminalTitle;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmUndo;
        private System.Windows.Forms.ToolStripMenuItem tsmRedo;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmTerminal;
        private System.Windows.Forms.ToolStripMenuItem tsmPaste;
        private System.Windows.Forms.ToolStripMenuItem tsmCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmCut;
    }
}