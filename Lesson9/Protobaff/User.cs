using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace Protob
{
     [ProtoContract]
    class User
    {
        [ProtoMember (1)]
        public string Name { set; get; }
        [ProtoMember(2)]
        public int Id { set; get; }
        [ProtoMember(3)]
        public DateTime Time { set; get; }
        [ProtoMember(4)]
        public double Doubled { set; get; }
         [ProtoMember(5)]
        public int[] mas { set; get; }


    }
}
