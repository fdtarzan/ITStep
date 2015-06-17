using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    [ServiceContract]
    public interface IAuth
    {
        [OperationContract]
        string Autorize(string user, string pass);
        [OperationContract]
        string UserInfo(string token);
    }

    [DataContract]
    public class User
    {
        [DataMember]
        public string ss;
        [DataMember]
        public String LastName { set; get; }
        [DataMember]
        public String FirstName { set; get; }
        [DataMember]
        public String UserName { set; get; }
        [DataMember]
        public String UserPassword { set; get; }
        [DataMember]
        public String Token { set; get; }
        [DataMember]
        public DateTime ExpirienceDate { set; get; }
    }
}
