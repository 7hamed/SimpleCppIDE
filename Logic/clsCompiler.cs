using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCppIDE.Logic
{
    internal static class clsCompiler
    {

        static public void Compile(string filePath)
        {

            Process compilation = new Process();

            compilation.StartInfo.FileName = "g++";
            compilation.StartInfo.Arguments = $"{filePath} -o main";


            compilation.Start();
        }

    }
}
