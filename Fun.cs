using System.Diagnostics;

// Can't think of another name
namespace Fun;

class CowSay
{
    public static void Call(string content)
    {
        // Creates a new process in the OS
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                // Gets file. Most likely takes an executable. /bin/bash is an executable.
                FileName = "/bin/bash", // NOTE: some machines may not have bash
                ArgumentList = { "-c", $"cowsay {content}" },
                // Stdout gets redirected to our program instead of being displayed in the terminal
                RedirectStandardOutput = true,
            }
        };

        process.Start();
        string output = process.StandardOutput.ReadToEnd();

        // Wait for exit because we need to get all output first before proceeding w/ the rest of the program.
        process.WaitForExit();

        Console.WriteLine(output);
    }
}
