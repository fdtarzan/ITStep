using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DZMyDiskInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(MyDiskInfo), new Uri("http://localhost/MyDiskInfo/"));
           // sh.AddServiceEndpoint(typeof(IMyDiskInfo), new WSHttpBinding(), "Ep1");
              
             //  ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
              // behavior.HttpGetEnabled = true;
              // sh.Description.Behaviors.Add(behavior);
              // sh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
            sh.Open();

            Console.WriteLine("-------------------");
            Console.ReadLine();
            sh.Close();
        }

    }

    [ServiceContract]
    public interface IMyDiskInfo
    {
        [OperationContract]
        String FreeSpace(string disk);
        [OperationContract]
        String TotalSpace(string disk);
    }

    public class MyDiskInfo : IMyDiskInfo
    {
       public String FreeSpace(string disk)
        {
            try
            {
                DriveInfo d = new DriveInfo(disk);
                return d.TotalFreeSpace.ToString();
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }
       public String TotalSpace(string disk)
       {
           try
           {
               DriveInfo d = new DriveInfo(disk);
               return d.TotalSize.ToString();
           }
           catch (Exception ex)
           {
               return "Error";
           }
       }
    }
    
   
}
