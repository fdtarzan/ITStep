using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace wcfConsoleDuplexService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(Dupl));
            sh.Open();

            Console.WriteLine("-----------------");
            Console.ReadLine();
            sh.Close();
        }
    }

    [ServiceContract(CallbackContract=typeof(IClientCallback))]
    public interface IDupl
    {
        [OperationContract(IsOneWay=true)]
        void Call(int numbColl, int interval);

    }
    

    public interface IClientCallback
    {
        [OperationContract(IsOneWay=true)]
        void ReciveTime(string t);
    }

    public class Dupl : IDupl
    {
        public void Call(int numbColl, int interval)
        {
            
            List<int> list = new List<int>();
            list.Add(numbColl);
            list.Add(interval);
            IClientCallback icc = OperationContext.Current.GetCallbackChannel<IClientCallback>();
                icc.ReciveTime(DateTime.Now.ToString());
            /*
            ClientCaller caller = new ClientCaller();
            caller.icc = OperationContext.Current.GetCallbackChannel<IClientCallback>();
            Thread t = new Thread(caller.SendDataToClient);
            t.IsBackground = true;
            t.Start(list);
           */
        }
    }

    public class ClientCaller
    {
        public IClientCallback icc;
        public void SendDataToClient(object obj)
        {
            if(obj is List<int>)
            {
            List<int> list = (List<int>)obj;
            int numbColl=list[0];
            int interval = list[1];
            for (int i = 0; i < numbColl; i++)
            {
                Thread.Sleep(interval);
                try
                {
                    icc.ReciveTime(DateTime.Now.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            }
            
        }
    
    }
}
