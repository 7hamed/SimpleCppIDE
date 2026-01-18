using SimpleCppIDE.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCppIDE
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CheckInitialFiles();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmIDE());
        }

        static void CheckInitialFiles()
        {
            string GppCompilerPath = clsGlobal.SettingsCompilerPathFile;

            string dir = Path.GetDirectoryName(GppCompilerPath);

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            
            if (!File.Exists(GppCompilerPath))
            {
                File.WriteAllText(GppCompilerPath, string.Empty);
            }
        }
    }
}

/*
 *  1. undo , redo , connect with rtxtCodeEditor (in menu strip add Edit) [X]
 *  2. view , the terminal [X]
 *  3. color the keyword of the c++ [X]
 *  5. if opened files exist not open same file again  [X]
 *  6. when write { or ( automaticly adding } ) ].... [X]
 *  7. do Undo, Redo from scratch [X]
 *  8. make window for setting like -> searching g++ compiler path [X]
 *  10. when i in line (one tab) when i press enter, the new line start with one tab also [X]
 *  12. all size screen work [X]
 *  4. add icons to make it more buity [X]
 *  
 *  11. This works well, but there is one "luxury" feature in C++ IDEs you might want to consider: The "Open Block" Indentation. When a user types { and then presses Enter, the next line usually gets the previous tabs plus one extra tab.
 *  9. UI light dark with just switch button
 */
