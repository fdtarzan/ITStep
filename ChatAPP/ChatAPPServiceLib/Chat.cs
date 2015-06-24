using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatAPPServiceLib
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single,ConcurrencyMode=ConcurrencyMode.Reentrant)]
    class Chat:IChat
    {
        private Dictionary<string, IClientCallback> _onlineUsers=new Dictionary<string,IClientCallback>();
        public void SendMessageToAll(string message, string userName)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                AllMessages am = new AllMessages();
                am.Date = DateTime.Now;
                am.UserName = userName;
                am.Message = message;
                ctx.AllMessages.InsertOnSubmit(am);
                ctx.SubmitChanges();
                foreach (var el in _onlineUsers)
                {
                    try
                    {
                         el.Value.NewMessage(am.Date.Value.ToShortDateString() + " " + am.UserName + ": " + am.Message);
                    }
                    catch (Exception)
                    {
                        Disconect(el.Key);
                    }
                 
                }
            }
        }
        
        public void Connect(string userName)
        {
            _onlineUsers.Add(userName, OperationContext.Current.GetCallbackChannel<IClientCallback>());
            //List<string> users = new List<string>();
            //foreach (var item in _onlineUsers)
            //{
            //    users.Add(item.Key);
            //}
        
            //foreach (var el in _onlineUsers)
            //{
            //    try
            //    {
            //        el.Value.RefreshListOnline(users);
            //    }
            //    catch (Exception)
            //    {
            //        Disconect(el.Key);
            //    }

            //}
        }

        public void Disconect(string userName)
        {
            _onlineUsers.Remove(userName);
        }
    }
}
