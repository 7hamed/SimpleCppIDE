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
 *  1. undo , redo , connect with rtxtCodeEditor (in menu strip add Edit)
 *  2. view , the terminal
 *  3. color the keyword of the c++
 * 
 * 
 */
