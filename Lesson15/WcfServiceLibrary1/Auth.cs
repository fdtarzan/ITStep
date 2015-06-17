using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Auth : IAuth
    {
        public string Autorize(string user, string pass)
        {
            using (var ctx = new AuthServiceEntities())
            {

                var user1 = from u in ctx.Users
                            where u.UserName == user && u.UserPassword == pass
                            select u;
                if (user1.FirstOrDefault() != null)
                {
                    if (user1.FirstOrDefault().Token != null && user1.FirstOrDefault().ExpirienceDate >= DateTime.Now)
                    {
                        User u = new User();
                        u.Token = user1.FirstOrDefault().Token;
                        return JsonConvert.SerializeObject(u);
                    }
                    if (user1.FirstOrDefault().ExpirienceDate < DateTime.Now || user1.FirstOrDefault().Token == null)
                    {
                        user1.FirstOrDefault().ExpirienceDate = DateTime.Now.AddDays(1);
                        user1.FirstOrDefault().Token = TokenGen(16);
                        ctx.SaveChanges();

                        User u = new User();
                        u.Token = user1.FirstOrDefault().Token;
                        return JsonConvert.SerializeObject(u);

                    }
                }
                return "LoginError";

            }


        }

        public string UserInfo(string token)
        {
            using (var ctx = new AuthServiceEntities())
            {

                var user1 = from u in ctx.Users
                            where u.Token == token
                            select u;
                if (user1.FirstOrDefault() != null)
                {
                    User u = new User();
                    u.LastName = user1.FirstOrDefault().LastName;
                    u.FirstName = user1.FirstOrDefault().FirstName;
                    return JsonConvert.SerializeObject(u);
                }
                return "Incorrect Token";
            }

        }
        private string TokenGen(int length)
        {
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();

        }
    }
}
