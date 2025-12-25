using System;
using System.Collections.Generic;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmIDE());
        }
    }
}

/*
 *  1. undo , redo , connect with rtxtCodeEditor (in menu strip add Edit) [X]
 *  2. view , the terminal [X]
 *  3. color the keyword of the c++ [X]
 *  4. add icons to make it more buity
 *  5. if opened files exist not open same file again
 *  6. when write { or ( automaticly adding } ) ]....
 *  7. do Undo, Redo from scratch
 *  8. make window for setting like -> searching g++ compiler path
 */
