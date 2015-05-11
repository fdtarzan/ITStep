using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Semaphores
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Semaphore s = new Semaphore(5, 5, "My_SEMAPHORE");
                //s.Release();
                if(s.WaitOne(0))
                {
                
            for (int i = 0; i < 6; ++i)
                ThreadPool.QueueUserWorkItem(SomeMethod, s);
                }   
                else
            {
           
            Console.WriteLine("progra");
                    Console.ReadLine();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
   
           
            }


        static void SomeMethod(object obj)
        {
           
            Semaphore s = obj as Semaphore;
            bool stop = false;

            while (!stop)
            {
                if (s.WaitOne(500))
                {
                    try
                    {
                        Console.WriteLine("Поток {0} блокировку получил", Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(2000);
                    }
                    finally
                    {
                        stop = true;
                        s.Release();
                       
                        Console.WriteLine("Поток {0} блокировку снял", Thread.CurrentThread.ManagedThreadId);
                    }
                }
                else
                    Console.WriteLine("Таймаут для потока {0} истек. Повторное ожидание", Thread.CurrentThread.ManagedThreadId);
            }
        }
    }  
}




