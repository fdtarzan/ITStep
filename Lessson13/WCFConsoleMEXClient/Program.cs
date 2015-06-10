using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFConsoleMEXClient.MymathNS;

namespace WCFConsoleMEXClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMathClient a = new MyMathClient();
            int result = a.Add(40, 40);
            Console.WriteLine("result: {0}", result);
            Console.WriteLine("Для завершения нажмите <ENTER>\n");
            Console.ReadLine();
            a.Close();
           
        }
    }
}
