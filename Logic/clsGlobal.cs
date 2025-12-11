using System;
using System.Collections.Generic;
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
                                                  "    cout << \"Hello World\" << endl;\n\n" +
                                                  "    return 0;\n" +
                                                  "}";


    }
}
