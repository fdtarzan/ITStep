using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest
{
    class Program
    {
        static  void Main(string[] args)
        {
            Console.WriteLine("Start   " + Thread.CurrentThread.ManagedThreadId);
            var res = TestAsync();
            Console.WriteLine("Main After TestAsync   " + Thread.CurrentThread.ManagedThreadId);
            
            Console.WriteLine(res.Result[0].ToString() + "   " + Thread.CurrentThread.ManagedThreadId);
        }

        static async Task<List<int>> TestAsync()
        {
            Console.WriteLine("TestAsync before Test  " + Thread.CurrentThread.ManagedThreadId);
            var r = await Task.Run(()=>test());
            await Task.Delay(2000);
            Console.WriteLine("TestAsync After Delay  " + Thread.CurrentThread.ManagedThreadId);
            var c = await Task.Run(() => test());
            Console.WriteLine("TestAsync After Test2  " + Thread.CurrentThread.ManagedThreadId);
          
            return r;
           
        }

        static List<int> test()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Test  " + Thread.CurrentThread.ManagedThreadId);
            return new List<int>() { 1, 2, 3 };
            
        }
    }
}
