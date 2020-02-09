using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Security;
using System.Text;

namespace PythonExecutor
{
    public class ScriptRunner
    {
        //args separated by spaces
        public static string RunFromCmd(string rCodeFilePath, string args)
        {
            string file = rCodeFilePath;
            string result = string.Empty;

            try
            {
                SecureString securePwd = new NetworkCredential("", "password").SecurePassword;
                var info = new ProcessStartInfo(@"Python program Path")
                {
                    Arguments = rCodeFilePath,
                    RedirectStandardInput = false,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    RedirectStandardError=true,
                    CreateNoWindow = true,
                };

                using (var proc = new Process())
                {
                   
                    proc.StartInfo = info;
                    proc.Start();
                    proc.WaitForExit();
                    Console.WriteLine(proc.ExitCode);
                    if (proc.ExitCode == 0)
                    {
                        result = proc.StandardOutput.ReadToEnd();
                    }
                    else
                    {
                        result = proc.StandardError.ReadToEnd();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("R Script failed: " + result, ex);
            }
        }
       
    }

}
