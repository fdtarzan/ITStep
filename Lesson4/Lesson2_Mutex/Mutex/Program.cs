using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mutexes
{
    class MutexSyncClass
    {
        static void Main(string[] args)
        {
            Mutex m = new Mutex(true, "SYNC_MUTEX");
            m.WaitOne();

            Console.ReadLine();
            Console.WriteLine("Синхронизация мютексом:");
            Counter c = new Counter();

            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i] = new Thread(c.UpdateFields);
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; ++i)
                threads[i].Join();

            Console.WriteLine("Count: {0}\n\n", c.Count);
           

        }

        class Counter
        {
            int count;
           
           

            public int Count
            {
                get { return count; }
            }

            public void UpdateFields()
            {
                for (int i = 0; i < 1000000; ++i)
                {
                    //m.WaitOne();
                    
                        ++count;
                    
                   //m.ReleaseMutex();
                }
            }
        }

    }
}
