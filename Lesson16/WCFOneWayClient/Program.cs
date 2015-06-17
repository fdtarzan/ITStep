using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using WCFOneWayClient.ServiceReference1;
using System.Threading;

namespace WCFOneWayClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            MyMathClient m = new MyMathClient();
            sw.Restart();
            int s = m.Add(5, 5);
            Console.WriteLine(sw.ElapsedMilliseconds);
            Thread.Sleep(1000);
            sw.Restart();
            m.Add1(5, 5);
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Stop();


        }
    }
}
