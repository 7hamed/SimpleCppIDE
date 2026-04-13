# SimpleCppIDE

A lightweight, accessible, and user-friendly Integrated Development Environment (IDE) tailored specifically for writing, compiling, and running C++ code.
## Tech Stack

- **Language:** C#
- **Framework:** .NET Framework 4.7.2
- **UI:** Windows Forms (WinForms)
- **Compiler integration:** `g++` (MinGW)

## Project Structure

The project cleanly separates UI from internal business logic:
- `Logic/` - Contains the core mechanics including file state management (`clsCppFile.cs`), the compiler wrapper (`clsCompiler.cs`), and the syntax coloring engine (`clsSyntaxHighlighter.cs`).
- `frmIDE.cs` - The main editor interface containing the UI controls, tabs, and integrated terminal.
- `frmCompilerConfig.cs` - A sub-dialog for manually pointing the IDE to the local `g++` executable if it lacks environment mapping.

## How It Works

SimpleCppIDE follows a layered architecture to decouple the visual interface from underlying operations:
1. **Editing & Syntax Highlighting:** As you interact with `frmIDE.cs`, the UI events trigger the business logic (`clsSyntaxHighlighter`). This layer uses fast Regex pattern-matching on the current line to colorize C++ keywords, brackets, and strings. Logic handles auto-completion and block indentation.
2. **Compiling:** The UI passes a target command to the `clsCompiler` engine. The IDE spawns a background process (`System.Diagnostics.Process`) invoking your native `g++` compiler against the actively managed file. 
3. **Execution & Feedback:** Standard output and compiler errors are captured synchronously from the process and written directly into the embedded IDE terminal pane. If successful, the compiled binary is executed.

