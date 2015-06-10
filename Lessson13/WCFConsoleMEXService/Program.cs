using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WCFConsoleMEXService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(MyMath),new Uri("http://localhost/MyMath/"));
               sh.AddServiceEndpoint(typeof(IMyMath), new WSHttpBinding(), "Ep1");
              
               ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
               behavior.HttpGetEnabled = true;
               sh.Description.Behaviors.Add(behavior);
               sh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
            sh.Open();

            Console.WriteLine("-------------------");
            Console.ReadLine();
            sh.Close();
        }

    }

    [ServiceContract]
    public interface IMyMath
    {
        [OperationContract]
        int Add(int a, int b);
    }

    public class MyMath : IMyMath
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
