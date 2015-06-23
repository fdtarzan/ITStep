using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChatAPPServiceLib
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IAuth
    {
        [OperationContract]
        string Autorize(string user, string pass);
        [OperationContract]
        string Register(string user, string pass, string firstName, string lastName);
        [OperationContract]
        string CreateMD5(string input);



      
    }

    // Используйте контракт данных, как показано на следующем примере, чтобы добавить сложные типы к сервисным операциям.
    // В проект можно добавлять XSD-файлы. После построения проекта вы можете напрямую использовать в нем определенные типы данных с пространством имен "ChatAPPServiceLib.ContractType".

    public class User
    {
        public String LastName { set; get; }
        public String FirstName { set; get; }
        public String UserName { set; get; }
        public String Token { set; get; }
        public DateTime ExpirienceDate { set; get; }
    }
}
