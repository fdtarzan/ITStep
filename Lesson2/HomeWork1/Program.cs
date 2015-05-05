using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 10; i++)
			{
			 list.Add(i+" thread");
			}
            ParameterizedThreadStart ts = new ParameterizedThreadStart(Method);
            Thread t1 = new Thread(ts);
            t1.Start(list);
            
        }
        static void Method(Object a)
        {
        foreach (var el in (a as List<string>))
        {
            Console.WriteLine(el);

        }
    
   
    
    }
    }
}
