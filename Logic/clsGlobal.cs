using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCppIDE.Logic
{
    internal static class clsGlobal
    {

        static public string CompilerGppPath = @"C:\MinGW\bin\g++.exe";
        static public string CompilerBuildSuccessfulString = "Build Successful !";

        static public string DefaultFileContent = "#include <iostream>\n\n" +
                                                  "using namespace std;\n\n" +
                                                  "int main()\n" +
                                                  "{\n" +
                                                  "\tcout << \"Hello World\" << endl;\n\n" +
                                                  "\treturn 0;\n" +
                                                  "}";


        static public Color NormalSyntaxColor = Color.Black;
        static public Color KeywordsSyntaxColor = Color.Blue;
        static public Color StringsSyntaxColor = Color.SandyBrown;
        static public Color CommnetsSyntaxColor = Color.LimeGreen;
        static public Color PreprocessorSyntaxColor = Color.DimGray;


    }
}
