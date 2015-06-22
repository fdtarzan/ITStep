using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


namespace WCFConsole1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(MyMath));
            sh.AddServiceEndpoint(typeof(IMyMath), new WSHttpBinding(), "http://localhost/MyMath/Ep1");
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
        [OperationContract]
        decimal Division(int a, int b);

    }
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class MyMath : IMyMath
    {
        public int Add(int a, int b)
        {
            return a + b;
        }


        public decimal Division(int a, int b)
        {
            return a / b;
        }
    }

}
