using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WCFDataContractService
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
        [OperationContract (Name="DiskTotal1")]
        DiskInfoResult DiskInfoTotal(string disk);
        [OperationContract (Name = "DiskTotal2")]
        DiskInfoResult DiskInfoTotal(string disk, string disk1);

    }
    [DataContract]
    public class DiskInfoResult
    {
        [DataMember]
        public string freeSpace;
        [DataMember]
        public string totalSpace;
    
    }


    public class MyDiskInfo : IMyDiskInfo
    {


        public DiskInfoResult DiskInfoTotal(string disk)
        {
            try
            {
                DiskInfoResult dir = new DiskInfoResult();

                DriveInfo d = new DriveInfo(disk);
                dir.totalSpace=d.TotalSize.ToString();
                dir.freeSpace = d.AvailableFreeSpace.ToString();
                return dir;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DiskInfoResult DiskInfoTotal(string disk, string disk1)
        {
            try
            {
                DiskInfoResult dir = new DiskInfoResult();

                DriveInfo d = new DriveInfo(disk);
                dir.totalSpace = d.TotalSize.ToString();
                dir.freeSpace = d.AvailableFreeSpace.ToString();
                return dir;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
       
    }
}
