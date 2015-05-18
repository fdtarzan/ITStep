using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GCTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            object ob = new object();
            Timer t = new Timer(new TimerCallback(Print),ob,1000,1000);
            t.Change(500, 500);
            Console.ReadLine();
        }
        static void Print(Object s)
        {
           
                Console.WriteLine("dddd");
                GC.Collect();

           
        }
    }
}
