using System.Diagnostics;

class CowSay
{
    public static void Call(string content)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                ArgumentList = { "-c", $"cowsay {content}" },
                RedirectStandardOutput = true,
            }
        };

        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        Console.WriteLine(output);
    }
}
