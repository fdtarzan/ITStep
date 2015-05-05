using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        static int c1, c2;
        static void Main(string[] args)
        {
            
            //while (true)
            //{
                Thread myThread = new Thread(new ThreadStart(Method1));
                myThread.Priority = ThreadPriority.Highest;
                myThread.Start();
                Thread myThread1 = new Thread(new ThreadStart(Method2));
                myThread1.Priority = ThreadPriority.Lowest;
                myThread1.Start();
                
           //     for (int i = 1; i > 0; i++)
           //     {
           //         Console.WriteLine("hello in thread");
           //         Thread.Sleep(1);
           //     }
           //// }
             
        }
        static void Method()
        {
            for (int i = 1; i > 0; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1);
                
            }
    	}
                  static void Method1()
                    {
                        for (int i = 1; i > 0; i++)
                        {
                            Console.WriteLine("thread1");
                            c1++;
                            Console.Title = "c1 " + c1 + "c2 " + c2;
                        }
                  }
    
                  static void Method2()
        {
            for (int i = 1; i > 0; i++)
            {
                Console.WriteLine("thread2");
                c2++;
                Console.Title = "c1 " + c1 + "c2 " + c2;
            }
                
            }
    	 
	}
        }
 

