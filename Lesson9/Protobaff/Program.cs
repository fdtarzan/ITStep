using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ProtoBuf;
using System.IO;
using Newtonsoft.Json;


namespace Protob
{
    class Program
    {
        static void Main(string[] args)
        {


            ProtoTest(1000);
            ProtoTest(2000);
            ProtoTest(3000);
            ProtoTest(4000);
            JsonTest(1000);
            JsonTest(2000);
            JsonTest(3000);
            JsonTest(4000);

        }
        private static void ProtoTest(int iter)
        {
            User u1 = new User();
            User u2 = new User();
            u1.Id=111;
            u1.Name="ddd";
            u1.Time=DateTime.Now;
            u1.Doubled=1.0;
            u1.mas = new int[] { 1, 2, 3, 5, 4 };
            var sw = new Stopwatch();
           
                using (var file = File.Create("test"))
                {
                    sw.Restart();
                    for (int i = 0; i < iter; i++)
                    {
                    file.Position = 0;
                    Serializer.Serialize(file, u1);
                    file.Position = 0;
                    u2 = Serializer.Deserialize<User>(file);
                    }
                    sw.Stop();
                    Console.WriteLine("Protobaff: "+sw.ElapsedMilliseconds);

            }
         
       
        }
        private static void JsonTest(int iter)
        {
            User u1 = new User();
            User u2 = new User();
            u1.Id = 111;
            u1.Name = "ddd";
            u1.Time = DateTime.Now;
            u1.Doubled = 1.0;
            u1.mas = new int[] { 1, 2, 3, 5, 4 };
            var sw = new Stopwatch();
            
                sw.Restart();
                for (int i = 0; i < iter; i++)
                {

                    string str = JsonConvert.SerializeObject(u1);
                    u2 = JsonConvert.DeserializeObject<User>(str);
                    

                }
                    sw.Stop();

               
             Console.WriteLine("Json: "+sw.ElapsedMilliseconds);
            }

        }

    }

