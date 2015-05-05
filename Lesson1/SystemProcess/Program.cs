using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] proc = Process.GetProcesses();
            Console.WriteLine("{0,-28} {1,-10}", "Process Name", "UID");
                foreach (var p in proc)
                {
                    try
                    {
                       
                        Console.WriteLine("{0,-28} {1,-10}", p.ProcessName, p.Id);
                        if (p.ProcessName != "SystemProcess" && p.Id !=1000)
                        {
                            p.Kill();
                        }
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                    }
                }
            
        }
    }
}
