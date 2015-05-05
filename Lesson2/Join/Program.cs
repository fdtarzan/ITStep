using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Join
{
    class Program
    {
        static double mainsum, threadSum, sum;
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Medhod);
            t1.IsBackground=true;
            t1.Start();
            //t1.Join();
            
            for (int i = 0; i < 100; i++)
            {
                mainsum += (i + 1);
            }

            sum = mainsum + threadSum;
            Console.WriteLine("sum " + sum);


        }

        static void Medhod()
        {
            for (int i = 0; i < 10000; i++)
            {
                threadSum += (i + 1);
                Thread.Sleep(1);
            }
        }
    }

}
