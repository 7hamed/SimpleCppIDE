using SimpleCppIDE.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

            pTerminal.Visible = false;
            setSizeCodeEditorFull();
            
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            rtxtCodeEditor.Focus();

            if (_currentFile == null)
            {
                MessageBox.Show("there is no file open.");
                return;
            }

            CompileStartStyle();
            CompileCurrentFile();
            CompileEndStyle();

            PrintResultInTerminal();
            PopUpTerminal();
            
        }

        private void PrintResultInTerminal()
        {
            if (_currentFile.CompiledFile.isSuccess)
            {
                rtxtTerminal.Text = _currentFile.CompiledFile.Errors;
            }
            else
            {
                rtxtTerminal.Text = _currentFile.CompiledFile.Errors;
            }
        }

        private void CompileStartStyle()
        {
            btnCompile.BackColor = Color.Yellow;
            btnCompile.Text = "Compiling";
            btnCompile.Font = new Font(btnCompile.Font.FontFamily, btnCompile.Font.Size, FontStyle.Bold); // make the font bold
            btnCompile.Refresh();
        }

        private void CompileEndStyle()
        {
            btnCompile.BackColor = SystemColors.Control;
            btnCompile.Text = "Compile";
            btnCompile.Font = new Font(btnCompile.Font, btnCompile.Font.Style & ~FontStyle.Bold); // remove font bold
            btnCompile.Refresh();
        }

        private void setSizeCodeEditorMid()
        {
            rtxtCodeEditor.Size = new Size(881, 507);
        }

        private void setSizeCodeEditorFull()
        {
            rtxtCodeEditor.Size = new Size(881, 746);
        }

        private void PopUpTerminal()
        {
            setSizeCodeEditorMid();
            pTerminal.Visible = true;
        }

        private void btnCloseTerminal_Click(object sender, EventArgs e)
        {
            rtxtCodeEditor.Focus();

            pTerminal.Visible = false;
            setSizeCodeEditorFull();
        }

        private bool CompileCurrentFile()
        {
            if (_currentFile.isNeedToSave)
                SaveCurrentFile();

            _currentFile.Compile();

            return _currentFile.CompiledFile.isSuccess;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            rtxtCodeEditor.Focus();

            if (_currentFile == null)
            {
                MessageBox.Show("there is no file open.");
                return;
            }

            if (_currentFile.CompiledFile == null)
            {
                var ans = MessageBox.Show("exe file not exist.\nDo you want to compile it ?", _currentFile.FileName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (ans == DialogResult.OK)
                {
                    btnCompile.PerformClick();
                }
                else
                    return;
            }

            if (_currentFile.CompiledFile.isSuccess)
            {
                _currentFile.CompiledFile.Run();
            }
            // else if pupup not exist, ...

        }


        private void UpdateSaveFlag(bool isNeedToSave)
        {
            if (_currentFile == null)
            {
                lblSaveFlag.Text = "";
                return;
            }

            
            if (isNeedToSave)
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
                else
                    return;
            }

            if (_currentFile.isChanged)
                SaveTextToCurrentContent();

            if (_currentFile.Save())
            {
                UpdateOpenedFileList();
                UpdateSaveFlag(_currentFile.isNeedToSave);

                return;
            }
        }

        private void SaveTextToCurrentContent()
        {
            if (_currentFile == null)
                return;

            _currentFile.Content = rtxtCodeEditor.Text;
            _currentFile.isChanged = false;
            _currentFile.isNeedToSave = true;
        }

        private void tsmSave_Click(object sender, EventArgs e)
        {
            SaveCurrentFile();

        }

        private void tsmOpen_Click(object sender, EventArgs e)
        {
            if(_currentFile != null && _currentFile.isChanged)
                SaveTextToCurrentContent();
            
            var ans = ofdIDE.ShowDialog();

            if (ans == DialogResult.OK)
            {
                var openedFile = new clsCppFile(ofdIDE.FileName);

                AddToOpendFileList(openedFile);

                SetCurrentFile(openedFile);

                UpdateSaveFlag(_currentFile.isNeedToSave);

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
                _currentFile.isNeedToSave = true;
                UpdateSaveFlag(_currentFile.isNeedToSave);
            }
        }

        private void tsmNew_Click(object sender, EventArgs e)
        {
            var newFile = new clsCppFile();

            newFile.FileName = "Untitled_" + _openedFiles.Count.ToString();
            newFile.Content = clsGlobal.DefaultFileContent;

            AddToOpendFileList(newFile);

            if(_currentFile != null && _currentFile.isChanged)
                SaveTextToCurrentContent();

            SetCurrentFile(newFile);

            UpdateSaveFlag(_currentFile.isNeedToSave);

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
                rtxtCodeEditor.TextChanged -= rtxtCodeEditor_TextChanged;
                rtxtCodeEditor.Text = _currentFile.Content;
                rtxtCodeEditor.TextChanged += rtxtCodeEditor_TextChanged;

                UpdateSaveFlag(_currentFile.isNeedToSave);
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
                SaveTextToCurrentContent();

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
                SaveTextToCurrentContent();
            
            if (_currentFile.isNeedToSave)
            {
                var ans = MessageBox.Show("before close the file.\nplease save the file...", _currentFile.FileName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                if (ans == DialogResult.Yes)
                {
                    SaveCurrentFile();
                    if (_currentFile.FilePath == null) return; // if save canceled
                }
                
                if(ans == DialogResult.Cancel)
                    return;

                // no : close the file and dont save
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

            List<clsCppFile> notSavedFiles = new List<clsCppFile>();
            string namesOfNotSavedFiles = "";

            for (int i = 0; i < _openedFiles.Count; i++)
            {
                if (_openedFiles[i].isNeedToSave)
                {
                    notSavedFiles.Add(_openedFiles[i]);
                    namesOfNotSavedFiles += _openedFiles[i].FileName + "\n";
                }
            }

            if (notSavedFiles.Count == 0)
                return;

            var ans = MessageBox.Show($"{namesOfNotSavedFiles}\nYou have unsaved changes.\nDo you want to save these files before exiting?",
                "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);

            if (ans == DialogResult.No) // dont save, just exit
                return;

            if (ans == DialogResult.Cancel) // dont exit
            {
                e.Cancel = true;
                return;
            }

            if (ans == DialogResult.Yes) // save and exit
            {
                foreach (clsCppFile file in notSavedFiles)
                {
                    if (file.FilePath == null) // new file
                    {
                        ans = sfdIDE.ShowDialog();

                        if (ans == DialogResult.OK)
                        {
                            file.FilePath = sfdIDE.FileName;
                        }
                        else
                        {
                            e.Cancel = true;
                            return;
                        }
                    }

                    file.Save();
                }
            }
            
        }

        
    }
}
