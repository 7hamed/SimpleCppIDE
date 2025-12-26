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
    public partial class frmCompilerConfig : Form
    {

        public frmCompilerConfig()
        {
            InitializeComponent();
        }

        private void txtPathReset()
        {
            txtPath.Text = "";
            txtPath.BackColor = SystemColors.Window;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            txtPathReset();

            var ans = ofdCompilerConfig.ShowDialog();

            if (ans == DialogResult.OK)
            {
                txtPath.Text = ofdCompilerConfig.FileName;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            txtPathReset();

            string path = clsCompiler.FindGppCompilerPath();

            if (path == null)
            {
                MessageBox.Show("g++ compiler path not found automatically");
                return;
            }

            txtPath.Text = path;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            btnCheck.BackColor = Color.LightYellow;

            if (isValidGppPath(txtPath.Text))
            {
                txtPath.BackColor = Color.LightGreen;
                clsCompiler.SetCppCompilerPathInSettings(txtPath.Text);
            }
            else
            {
                txtPath.BackColor = Color.OrangeRed;
            }

            btnCheck.BackColor = SystemColors.Control;
        }

        private bool isValidGppPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return false;

            try
            {
                ProcessStartInfo psiGpp = new ProcessStartInfo();
                psiGpp.FileName = path;
                psiGpp.Arguments = "--version";

                psiGpp.RedirectStandardOutput = true;
                psiGpp.UseShellExecute = false;
                psiGpp.CreateNoWindow = true;

                using (Process pGpp = Process.Start(psiGpp))
                {
                    string output = pGpp.StandardOutput.ReadLine();
                    pGpp.WaitForExit();

                    return !string.IsNullOrEmpty(output) && output.Contains("g++");
                }

            }
            catch
            {
                return false;
            }
            
        }
    }
}
