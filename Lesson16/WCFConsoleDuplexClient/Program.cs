using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFConsoleDuplexClient.ServiceNS;

namespace WCFConsoleDuplexClient
{
    public class CallBackHendler : IDuplCallback
    {
        static InstanceContext site = new InstanceContext(new CallBackHendler());
        public static DuplClient proxy = new DuplClient(site);

    
       public void ReciveTime(string t)
       {
 	    Console.WriteLine(t);
       }
}
    class Program
    {
        
        static void Main(string[] args)
        {
            CallBackHendler.proxy.Call(100, 100);
            Console.ReadLine();
        }
    }
}
