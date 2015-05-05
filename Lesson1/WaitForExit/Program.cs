using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaitForExit
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Process myPr = new Process();
            myPr.StartInfo.FileName="notepad.exe";
            myPr.Start();
            Console.WriteLine("Process start "+myPr.ProcessName);
            myPr.WaitForExit();
            Console.WriteLine("Process ends with reason "+myPr.ExitCode);
            Console.WriteLine("Current process has name "+Process.GetCurrentProcess().ProcessName);


        }
    }
}
