using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DZMyDiskInfoClientWitoutMEX
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IMyDiskInfo> factory = new ChannelFactory<IMyDiskInfo>(new WSHttpBinding(),
                new EndpointAddress("http://localhost/MyDiskInfo/Ep1"));
            IMyDiskInfo cannel = factory.CreateChannel();

            bool ok = true;
            while (ok)
            {
                Console.WriteLine("Enter Disk:");
                string disk = Console.ReadLine();
                if (cannel.TotalSpace(disk[0].ToString()) != "Error" && cannel.FreeSpace(disk[0].ToString()) != "Error")
                {

                    Console.WriteLine("Free Space: " + cannel.FreeSpace(disk[0].ToString()));
                    Console.WriteLine("Total Space: " + cannel.TotalSpace(disk[0].ToString()));
                    ok = false;
                }
                else
                {
                    Console.WriteLine("Error");

                }

                Console.ReadLine();
            }
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
}
