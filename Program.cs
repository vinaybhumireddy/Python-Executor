using System;
using System.Diagnostics;
using System.IO;

namespace PythonExecutor
{
    class Program
    {
         static void Main(string[] args)
        {
            string res = ScriptRunner.RunFromCmd(@"Python scripts path", "args");
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
