using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace WCFConsoleServiceDB
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(Auth), new Uri("http://localhost:10000/Auth/"));
            sh.Open();
          
            Console.WriteLine("-------------------");
            Console.ReadLine();
            sh.Close();

          


        }

    }
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

    public class Auth : IAuth
    {
        public string Autorize(string user, string pass)
        {
            using (var ctx = new AuthServiceEntities())
            {

                var user1 = from u in ctx.Users
                            where u.UserName == user && u.UserPassword==pass
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






//create database AuthService

//use AuthService
//go

//drop table Users

//create table Users
//(
 
//LastName nvarchar (256) not NULL
//,FirstName nvarchar (256) not NULL
//,UserName nvarchar (256) not NULL primary key
//,UserPassword nvarchar (256) not NULL
//,Token nvarchar (256)
//,ExpirienceDate DateTime
//)

//insert into Users (LastName, FirstName, UserName, UserPassword) values
//('Bob','Marly','Marly','123')
//,('Jon', 'Dou', 'Jon', '123')

//select * from users