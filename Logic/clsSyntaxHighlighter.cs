using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCppIDE.Logic
{
    internal class clsSyntaxHighlighter
    {
        private readonly string keywords = @"\b(" +
            // Data Types
            "int|float|double|char|bool|void|long|short|signed|unsigned|auto|size_t|" +
            "wchar_t|char16_t|char32_t|uint8_t|uint16_t|uint32_t|int8_t|int16_t|int32_t|" +

            // Control Flow
            "if|else|for|while|do|switch|case|default|break|continue|return|goto|" +
            "try|catch|throw|finally|" +

            // OOP & Classes
            "class|struct|enum|union|public|private|protected|virtual|override|friend|" +
            "this|new|delete|namespace|using|template|typename|explicit|inline|static|" +
            "const|volatile|extern|mutable|nullptr|true|false|" +

            // Modern C++ & Advanced
            "constexpr|consteval|constinit|decltype|noexcept|thread_local|alignas|alignof|" +
            "static_assert|static_cast|dynamic_cast|reinterpret_cast|const_cast|typeid|" +
            "operator|concept|requires" +
            @")\b";

        private readonly string preprocessor = @"#\s*(include|define|undef|ifdef|ifndef|if|else|elif|endif|pragma)\b";
        private readonly string comments = @"//.*|/\*[\s\S]*?\*/";
        private readonly string strings = @""".*?""";

        public void Highlight(RichTextBox rtxt)
        {
            int originalIndex = rtxt.SelectionStart;
            int originalLength = rtxt.SelectionLength;

            // DISABLE REDRAW: Stop the screen from flickering
            LockControlUpdate(rtxt, true);

            rtxt.Select(0, rtxt.Text.Length);
            rtxt.SelectionColor = clsGlobal.NormalSyntaxColor;

            ApplyColor(rtxt, keywords, clsGlobal.KeywordsSyntaxColor, 0, rtxt.Text.Length);
            ApplyColor(rtxt, comments, clsGlobal.CommnetsSyntaxColor, 0, rtxt.Text.Length);
            ApplyColor(rtxt, strings, clsGlobal.StringsSyntaxColor, 0, rtxt.Text.Length);
            ApplyColor(rtxt, preprocessor, clsGlobal.PreprocessorSyntaxColor, 0, rtxt.Text.Length);

            rtxt.Select(originalIndex, originalLength);
            rtxt.SelectionColor = clsGlobal.NormalSyntaxColor;
            
            // RE-ENABLE REDRAW: Stop the screen from flickering
            LockControlUpdate(rtxt, false);
        }

        public void HighlightCurrentLine(RichTextBox rtxt)
        {
            if (rtxt.Text.Length <= 0)
                return;

            int originalIndex = rtxt.SelectionStart;
            int originalLength = rtxt.SelectionLength;

            // DISABLE REDRAW: Stop the screen from flickering
            LockControlUpdate(rtxt, true);

            int lineNumber = rtxt.GetLineFromCharIndex(originalIndex);
            int startLineIndex = rtxt.GetFirstCharIndexFromLine(lineNumber);
            int lineLength = rtxt.Lines[lineNumber].Length;

            rtxt.Select(startLineIndex, lineLength);
            rtxt.SelectionColor = clsGlobal.NormalSyntaxColor;

            ApplyColor(rtxt, keywords, clsGlobal.KeywordsSyntaxColor, startLineIndex, lineLength);
            ApplyColor(rtxt, comments, clsGlobal.CommnetsSyntaxColor, startLineIndex, lineLength);
            ApplyColor(rtxt, strings, clsGlobal.StringsSyntaxColor, startLineIndex, lineLength);
            ApplyColor(rtxt, preprocessor, clsGlobal.PreprocessorSyntaxColor, startLineIndex, lineLength);

            rtxt.Select(originalIndex, originalLength);
            //rtxt.SelectionColor = clsGlobal.NormalSyntaxColor;
            
            // RE-ENABLE REDRAW: Stop the screen from flickering
            LockControlUpdate(rtxt, false);
        }

        private void ApplyColor(RichTextBox rtxt, string pattern, Color color, int startIndex, int length)
        {
            string text = rtxt.Text.Substring(startIndex, length);

            foreach (Match match in Regex.Matches(text, pattern))
            {
                rtxt.Select(match.Index + startIndex, match.Length);
                rtxt.SelectionColor = color;
            }
        }


        // Add this to stop the 'flashing' white screen when coloring
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private void LockControlUpdate(Control control, bool lockUpdate)
        {
            const int WM_SETREDRAW = 0x0b;
            SendMessage(control.Handle, WM_SETREDRAW, (IntPtr)(lockUpdate ? 0 : 1), IntPtr.Zero);
            if (!lockUpdate) control.Refresh();
        }

        // These are "addresses" for specific Windows commands
        private const int WM_USER = 0x0400;
        private const int EM_SETUNDOLIMIT = WM_USER + 82;
    }
}
