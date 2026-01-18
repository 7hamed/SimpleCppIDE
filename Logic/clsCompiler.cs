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

        static public string GppCompilerPathInSettings = clsGlobal.SettingsCompilerPathFile;

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


        static public string FindGppCompilerPath()
        {
            // search in windows enviroment paths
            string pathEnv = Environment.GetEnvironmentVariable("PATH");
            if (pathEnv != null)
            {
                foreach (string path in pathEnv.Split(';'))
                {
                    string fullPath = Path.Combine(path, "g++.exe");

                    if (File.Exists(fullPath))
                        return fullPath;
                }
            }


            return null;
        }


        static public bool isGppCompilerPathExistInSettings()
        {
            string gppPath = File.ReadAllText(GppCompilerPathInSettings);

            return !string.IsNullOrEmpty(gppPath);
        }

        static public string GetGppCompilerPathFromSettings()
        {
            if (GppCompilerPathInSettings != null)
                return File.ReadAllText(GppCompilerPathInSettings);

            return null;
        }

        static public void SetCppCompilerPathInSettings(string gppPath)
        {
            if (GppCompilerPathInSettings != null)
            {
                File.WriteAllText(GppCompilerPathInSettings, gppPath);
                clsGlobal.CompilerGppPath = gppPath;
            }
        }

    }
}
