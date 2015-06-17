using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WCFConsoleService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(MyMath));
            sh.Open();
            Console.WriteLine("--------------");
            Console.ReadLine();
            sh.Close();

        }
    }
    [ServiceContract]
    public interface IMyMath
    {
        [OperationContract]
        int Add(int a, int b);
        [OperationContract(IsOneWay = true)]
        void Add1(int a, int b);
    }

    public class MyMath : IMyMath
    {
        public int Add(int a, int b)
        {
            Thread.Sleep(1000);
            MyLog((a + b).ToString());
            return a + b;
        }
    

        public void Add1(int a, int b)
        {
            Thread.Sleep(1000);
            MyLog((a + b).ToString());
        }
        private void MyLog(string msg)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter("d:\\11\\svclog.txt", true);
                msg += "\t\t";
                msg += DateTime.Now.ToLongTimeString();
                sw.WriteLine(msg);
            }
            catch (Exception ex)
            {
                StreamWriter error = new StreamWriter("d:\\11\\errors.txt", true);
                error.WriteLine(ex.Message);
                error.Close();
            }
            finally
            {
                sw.Close();
            }
        }
}
}
