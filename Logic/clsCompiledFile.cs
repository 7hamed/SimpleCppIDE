using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCppIDE.Logic
{
    internal class clsCompiledFile
    {
        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                if (value.Contains(".exe"))
                {
                    _filePath = value;
                }
                else
                    throw new ArgumentException("[!] the file path is not contains exe file.");
            }
        }
        public string FileName { get; set; }
        public bool isSuccess { get; set; }

        public string Errors { get; set; }


        public clsCompiledFile(string filePath, string errors)
        {
            FilePath = filePath;
            FileName = GetFileName();
            Errors = errors;
            isSuccess = GetSuccessResult();
        }

        public bool Run()
        {
            if (!File.Exists(FilePath))
                throw new Exception("[!] file path exe is not exist.");

            if (!isSuccess)
                return false;

            ProcessStartInfo psiExe = new ProcessStartInfo();
            psiExe.FileName = FilePath;

            psiExe.UseShellExecute = true;
            psiExe.CreateNoWindow = false;

            using (Process pExe = new Process())
            {
                pExe.StartInfo = psiExe;
                pExe.Start();
            }

            return true;
        }

        private string GetFileName()
        {
            if (_filePath == string.Empty)
                return string.Empty;

            return Path.GetFileName(_filePath);
        }

        private bool GetSuccessResult()
        {
            return Errors == clsGlobal.CompilerBuildSuccessfulString;
        }
    }
}
