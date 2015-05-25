using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    [ProtoContract]
    public class Message
    {
        [ProtoMember(1)]
        public string Msg { get; set; }
        [ProtoMember(2)]
        public DateTime DateOfMsg { get; set; }
        [ProtoMember(3)]
        public string UserClient { get; set; }

        public Message() { }
    }
}
