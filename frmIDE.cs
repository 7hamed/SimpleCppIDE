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

        private int _prevOpenedFileIndex;


        public frmIDE()
        {
            InitializeComponent();
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            _SaveFile();

            clsCompiler.Compile("test.cpp");

        }


        private void UpdateSaveFlag(bool isChanged)
        {
            if (_currentFile == null)
            {
                lblSaveFlag.Text = "";
                return;
            }

            
            if (isChanged)
            {
                lblSaveFlag.Text = "Not Save";
                lblSaveFlag.ForeColor = Color.Red;
            }
            else
            {
                lblSaveFlag.Text = "Saved";
                lblSaveFlag.ForeColor = Color.Green;
            }
        }
        

        private void _SaveFile()
        {
            string pathFile = @"Test.cpp";

            File.WriteAllText(pathFile, rtxtCodeEditor.Text);

            MessageBox.Show("save file is done");
        }

        private void SaveCurrentFile()
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
                //MessageBox.Show("File Saved Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UpdateOpenedFileList();
                UpdateSaveFlag(_currentFile.isChanged);

                return;
            }
        }

        private void tsmSave_Click(object sender, EventArgs e)
        {
            SaveCurrentFile();

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
            if (_currentFile != null && _currentFile.isChanged)
            {
                var result = MessageBox.Show("before open a file.\nplease save the file...", _currentFile.FileName, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                    SaveCurrentFile();
                else
                    return;
            }
            
            var ans = ofdIDE.ShowDialog();

            if (ans == DialogResult.OK)
            {
                

                var openedFile = new clsCppFile(ofdIDE.FileName);

                AddToOpendFileList(openedFile);

                SetCurrentFile(openedFile);

                UpdateSaveFlag(_currentFile.isChanged);

                SetCodeEditorEnabledByCurrentFile();
            }
        }

        private void SetCodeEditorEnabledByCurrentFile()
        {
            if (_currentFile == null)
                rtxtCodeEditor.Enabled = false;
            else
                rtxtCodeEditor.Enabled = true;
        }

        private void frmIDE_Load(object sender, EventArgs e)
        {
            SetCodeEditorEnabledByCurrentFile();

            UpdateSaveFlag(false);
        }

        private void btnFileInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_currentFile.FileInfo());
        }

        private void rtxtCodeEditor_TextChanged(object sender, EventArgs e)
        {
            if (_currentFile != null)
            {
                _currentFile.isChanged = true;
                UpdateSaveFlag(_currentFile.isChanged);
            }
        }

        private void tsmNew_Click(object sender, EventArgs e)
        {
            var newFile = new clsCppFile();

            newFile.FileName = "new_file";
            newFile.Content = "new cpp file";

            AddToOpendFileList(newFile);

            SetCurrentFile(newFile);

            UpdateSaveFlag(_currentFile.isChanged);

            SetCodeEditorEnabledByCurrentFile();
        }

        private void OpenCurrentFileOnEditor()
        {
            if (_currentFile == null)
            {
                rtxtCodeEditor.Text = "";
                UpdateSaveFlag(false);
            }
            else
            {
                rtxtCodeEditor.Text = _currentFile.Content;
                _currentFile.isChanged = false;
                UpdateSaveFlag(_currentFile.isChanged);
            }


        }


        private void UpdateOpenedFileList()
        {
            _prevOpenedFileIndex = cbOpenedFiles.SelectedIndex;
            cbOpenedFiles.Items.Clear();

            foreach (var file in _openedFiles)
            {
                cbOpenedFiles.Items.Add(file.FileName);
            }

            cbOpenedFiles.SelectedIndex = _prevOpenedFileIndex;
        }

        private void AddToOpendFileList(clsCppFile file)
        {
            _openedFiles.Add(file);

            UpdateOpenedFileList();
        }

        private void SetCurrentFile(clsCppFile file)
        {
            if (file == null)
            {
                _currentFile = null;
                cbOpenedFiles.SelectedIndex = -1;
                SetCodeEditorEnabledByCurrentFile();
                OpenCurrentFileOnEditor();

                return;
            }
            
            _currentFile = file;
            cbOpenedFiles.SelectedIndex = _openedFiles.IndexOf(file);

            OpenCurrentFileOnEditor();
            SetCodeEditorEnabledByCurrentFile();
        }

        private void cbOpenedFiles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_prevOpenedFileIndex == cbOpenedFiles.SelectedIndex)
                return;

            if (_currentFile.isChanged)
            {
                var ans = MessageBox.Show("before change the file.\nplease save the file...", _currentFile.FileName, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (ans == DialogResult.OK)
                    SaveCurrentFile();
                else
                {
                    cbOpenedFiles.SelectedIndex = _prevOpenedFileIndex;
                    return;
                }
            }

            SetCurrentFile(_openedFiles[cbOpenedFiles.SelectedIndex]);
        }

        private void cbOpenedFiles_DropDown(object sender, EventArgs e)
        {
            if (cbOpenedFiles.Items.Count > 0)
                _prevOpenedFileIndex = cbOpenedFiles.SelectedIndex;
        }

        private void cbOpenedFiles_KeyDown(object sender, KeyEventArgs e) // keyboard not affect at all
        {
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void CloseCurrentFile()
        {
            if (_currentFile == null)
            {
                MessageBox.Show("there is no exist file, cant close perform");
                return;
            }
            
            if (_currentFile.isChanged)
            {
                var ans = MessageBox.Show("before close the file.\nplease save the file...", _currentFile.FileName, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (ans == DialogResult.OK)
                    SaveCurrentFile();
                else
                    return;
            }

            int currentIndex = _openedFiles.IndexOf(_currentFile);
            _openedFiles.RemoveAt(currentIndex);

            if (_openedFiles.Count == 0)
            {
                SetCurrentFile(null);
            }
            else
            {
                int newIndex = (currentIndex - 1 < 0 ? currentIndex : currentIndex - 1);
                SetCurrentFile(_openedFiles[newIndex]);
            }

            UpdateOpenedFileList();
        }

        private void tsmClose_Click(object sender, EventArgs e)
        {
            CloseCurrentFile();
        }

        private void frmIDE_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_currentFile != null && _currentFile.isChanged)
            {
                var ans = MessageBox.Show("before close the IDE.\nplease save the file...", _currentFile.FileName, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (ans == DialogResult.OK)
                    SaveCurrentFile();
                else
                {
                    e.Cancel = true;
                    return;
                }
            }
            
        }
    }
}
