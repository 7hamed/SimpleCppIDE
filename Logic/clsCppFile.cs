using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCppIDE.Logic
{
    internal class clsCppFile
    {

        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                if (value.Contains(".cpp"))
                {
                    _filePath = value;
                    FileName = GetFileName();
                }
                else
                    throw new ArgumentException("[!] the file path is not cpp file.");
            }
        }

        public string FileName { get; set; }
        public string Content { get; set; }
        public bool isChanged { get; set; }
        public bool isNeedToSave { get; set; }

        public clsCompiledFile CompiledFile { get; set; }

        
        public clsCppFile() // create file
        {
            FileName = null;
            _filePath = null;
            Content = null;
            isChanged = false;
            isNeedToSave = true;
        }

        public clsCppFile(string filePath) // open file
        {
            FilePath = filePath;

            Content = GetContent();
            isChanged = false;
            isNeedToSave = false;
        }

        private string GetFileName()
        {
            if (_filePath == string.Empty)
                return string.Empty;

            return Path.GetFileName(_filePath);
            //return _filePath.Substring(_filePath.LastIndexOf('\\') + 1);
        }

        private string GetContent()
        {
            return File.ReadAllText(FilePath);
        }

        public bool Save()
        {
            if (string.IsNullOrEmpty(FilePath))
                throw new InvalidOperationException("[!] the file path is empty.");

            File.WriteAllText(FilePath, Content);
            isNeedToSave = false;
            return true;
        }

        public void Compile()
        {
            string errors = clsCompiler.Compile(FilePath);
            string exePath = Path.ChangeExtension(FilePath, ".exe");
            CompiledFile = new clsCompiledFile(exePath, errors);
        }

        public string FileInfo()
        {
            string info = "file path : " + FilePath + "\n";
            info += "file name : " + FileName + "\n";
            info += "content : " + (Content.Length == 0 ? "Empty" : "Alot of text") + "\n";
            info += "is changed : " + isChanged.ToString() + "\n";
            info += "is need to save : " + isNeedToSave.ToString() + "\n";

            return info;
        }

    }
}
