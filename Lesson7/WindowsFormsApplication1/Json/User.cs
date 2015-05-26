using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Json
{
    class User
    {
        
        public int Int { set; get; }
        [JsonProperty("ololol")]
        public string Str { set; get; }
        public int[] Intmas { set; get; }
      //  public double dbl { set; get; }
        public DateTime DT {  set; get; }
        public User USS { set; get; }

       
    }
    public class USSS
    {
        public int Int { get; set; }
        public string Str { get; set; }
        public List<int> Intmas { get; set; }
        public double dbl { get; set; }
        public string DT { get; set; }
        public object USS { get; set; }
    }

    public class RootObject
    {
        public int Int { get; set; }
        [JsonProperty("ololol")]
        public string Str { get; set; }
        public List<int> Intmas { get; set; }
        public double dbl { get; set; }
        public string DT { get; set; }
        public USSS USS { get; set; }
    }
}
