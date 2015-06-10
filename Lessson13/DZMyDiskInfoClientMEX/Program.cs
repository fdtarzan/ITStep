using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZMyDiskInfoClientMEX.DiskInfoNS;

namespace DZMyDiskInfoClientMEX
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDiskInfoClient dc = new MyDiskInfoClient();
            
           bool ok=true;
            while(ok)    
            {
               Console.WriteLine("Enter Disk:");
               string disk = Console.ReadLine();
               if (dc.TotalSpace(disk[0].ToString()) != "Error" && dc.FreeSpace(disk[0].ToString()) != "Error")
                {
                    
                    Console.WriteLine("Free Space: " + dc.FreeSpace(disk[0].ToString()));
                    Console.WriteLine("Total Space: " + dc.TotalSpace(disk[0].ToString()));
                   ok=false;
                }
                else
            {
            Console.WriteLine("Error");
            
            }

            Console.ReadLine();
            }
        


            
        }
    }
}
