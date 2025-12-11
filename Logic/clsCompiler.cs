using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCppIDE.Logic
{
    internal static class clsCompiler
    {

        static public string Compile(string sourceFilePath)
        {
            string exeFilePath = Path.ChangeExtension(sourceFilePath, ".exe");

            ProcessStartInfo psiGpp = new ProcessStartInfo();
            psiGpp.FileName = clsGlobal.CompilerGppPath;
            psiGpp.Arguments = $"\"{sourceFilePath}\" -o \"{exeFilePath}\"";

            psiGpp.UseShellExecute = false; // Required to redirect output
            psiGpp.CreateNoWindow = true;   // Don't show the black popup window
            psiGpp.RedirectStandardOutput = true; // Capture normal messages
            psiGpp.RedirectStandardError = true;  // Capture error messages (IMPORTANT for G++)

            using (Process pGpp = new Process())
            {
                pGpp.StartInfo = psiGpp;
                pGpp.Start();

                string errors = pGpp.StandardError.ReadToEnd();
                string outputs = pGpp.StandardOutput.ReadToEnd();

                pGpp.WaitForExit();

                if (!string.IsNullOrEmpty(errors))
                {
                    return errors;
                }

                return clsGlobal.CompilerBuildSuccessfulString;
            }
        }

    }
}
