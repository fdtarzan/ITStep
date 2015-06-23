using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatAPPServiceLib
{
    [ServiceContract(CallbackContract = typeof(IClientCallback))]
    public interface IChat
    {
         [OperationContract]
         void SendMessageToAll(string message, string userName);
         [OperationContract]
         void Connect(string userName);
         [OperationContract]
         void Disconect(string userName);

    }
     public interface IClientCallback
     {
         [OperationContract(IsOneWay = true)]
         void NewMessage(string t);
         [OperationContract(IsOneWay = true)]
         void NewPrivateMessage(string t);
         [OperationContract(IsOneWay = true)]
         void RefreshListOnline(List<string> list);
     }
}
