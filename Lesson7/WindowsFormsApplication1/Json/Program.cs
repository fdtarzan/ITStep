using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Json
{
    class Program
    {
        static void Main(string[] args)
        {
            User us2 = new User();
            int[] intmas1 = new int[5] { 1, 2, 3, 4, 5 };
            us2.Int = 10;
            us2.Str = "test";
            us2.Intmas = intmas1;
           // us2.dbl = 12.1551;
            us2.DT = DateTime.Now;
            
            
            User us1 = new User();
            int[] intmas = new int[5] { 1, 2, 3, 4, 5 };
            us1.Int = 10;
            us1.Str = "test";
            us1.Intmas = intmas;
           // us1.dbl = 12.1551;
            us1.DT = DateTime.Now;
            us1.USS = us2;

            Console.WriteLine(JsonConvert.SerializeObject(us1));

            RootObject obj = JsonConvert.DeserializeObject<RootObject>(JsonConvert.SerializeObject(us1));

            Console.WriteLine(obj.Str);
        }
    }
}
