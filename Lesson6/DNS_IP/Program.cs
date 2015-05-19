using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DNS_IP
{
    class Program
    {
        static void Main(string[] args)
        {
           var res= Dns.GetHostAddresses("vk.com");

           foreach (IPAddress el in res)
           {
               Console.WriteLine(el);
           }

           Console.WriteLine(Dns.GetHostEntry("77.123.88.11").HostName);
            
           Console.ReadLine();
        }



    }
}
