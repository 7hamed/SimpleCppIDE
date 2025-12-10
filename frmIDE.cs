using SimpleCppIDE.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCppIDE
{
    public partial class frmIDE : Form
    {

        private List<clsCppFile> _openedFiles = new List<clsCppFile>();
        private clsCppFile _currentFile;

        private bool _isFileChanged = false;

        public frmIDE()
        {
            InitializeComponent();
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            _SaveFile();

            clsCompiler.Compile("test.cpp");

            

        }



        

        private void _SaveFile()
        {
            string pathFile = @"Test.cpp";

            File.WriteAllText(pathFile, rtxtCodeEditor.Text);

            MessageBox.Show("save file is done");
        }

        private void tsmSave_Click(object sender, EventArgs e)
        {
            if (_currentFile == null)
            {
                MessageBox.Show("there is no file exist to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (_currentFile.FilePath == null) // for new file
            {
                var ans = sfdIDE.ShowDialog();

                if (ans == DialogResult.OK)
                {
                    _currentFile.FilePath = sfdIDE.FileName;
                }
            }

            _currentFile.Content = rtxtCodeEditor.Text;
            if (_currentFile.Save())
            {
                MessageBox.Show("File Saved Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (File.Exists("main.exe"))
            {

                Process main = new Process();
                main.StartInfo.FileName = "main.exe";

                main.Start();
            }
            else
            {
                MessageBox.Show("the main file not exist");
            }
        }

        private void tsmOpen_Click(object sender, EventArgs e)
        {
            var ans = ofdIDE.ShowDialog();

            if (ans == DialogResult.OK)
            {
                _currentFile = new clsCppFile(ofdIDE.FileName);
                _openedFiles.Add(_currentFile);

                OpenCurrentFile();
            }
        }

        private void frmIDE_Load(object sender, EventArgs e)
        {
            
        }

        private void btnFileInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_currentFile.FileInfo());
        }

        private void rtxtCodeEditor_TextChanged(object sender, EventArgs e)
        {
            _currentFile.isChanged = true;
        }

        private void tsmNew_Click(object sender, EventArgs e)
        {
            _currentFile = new clsCppFile();
            _openedFiles.Add(_currentFile);

            _currentFile.FileName = "new_file";
            _currentFile.Content = "";

            OpenCurrentFile();
        }

        private void OpenCurrentFile()
        {
            rtxtCodeEditor.Text = _currentFile.Content;
            _currentFile.isChanged = false;


        }


        private void UpdateOpenedFileList()
        {

        }
    }
}
