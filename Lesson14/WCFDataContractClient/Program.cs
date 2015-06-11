using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFDataContractClient.ServiceNS;
//using WCFDataContractClient.ServiceAsyncNS;

namespace WCFDataContractClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDiskInfoClient dc = new MyDiskInfoClient();
            bool ok=true;
            while (ok)
            {
                Console.Write("Enter disk: ");
                string disk = Console.ReadLine();

                if (disk.Length>0&&dc.DiskTotal(disk[0].ToString()) != null)
                {
                    var res = dc.DiskTotal1Async(disk[0].ToString());
                    Console.WriteLine("Free Space:  {0}", res.Result.freeSpace);
                  //  Console.WriteLine("Free Space:  {0}", dc.DiskTotal1(disk[0].ToString()).freeSpace);
                  //  Console.WriteLine("Total space: {0}", dc.DiskTotal1(disk[0].ToString()).totalSpace);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
    }
}
