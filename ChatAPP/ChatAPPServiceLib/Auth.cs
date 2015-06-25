
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;

namespace ChatAPPServiceLib
{
       public class Auth : IAuth
    {
        public string Autorize(string user, string pass)
        {
            using (var ctx = new DataClasses1DataContext())
            {

                var user1 = from u in ctx.Users
                            where u.UserName == user && u.UserPasswordHash == pass
                            select u;
                if (user1.FirstOrDefault() != null)
                {
                    if (user1.FirstOrDefault().Token != null && user1.FirstOrDefault().ExpirienceDate >= DateTime.Now)
                    {
                        user1.FirstOrDefault().ExpirienceDate = DateTime.Now.AddDays(1);
                        ctx.SubmitChanges();
                        return user1.FirstOrDefault().Token;
                    }
                    if (user1.FirstOrDefault().ExpirienceDate < DateTime.Now || user1.FirstOrDefault().Token == null)
                    {
                        user1.FirstOrDefault().ExpirienceDate = DateTime.Now.AddDays(1);
                        user1.FirstOrDefault().Token = TokenGen(16);
                        ctx.SubmitChanges();
                        return user1.FirstOrDefault().Token;
                    }
                }
                return "LoginError";
            }
        }
        public string Register(string user, string pass, string firstName, string lastName)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var user1 = from u in ctx.Users
                            where u.UserName == user
                            select u;
                if (user1.FirstOrDefault() != null)
                {
                    return "Login Exist";
                }
                else
                {
                    Users u = new Users();
                    u.FirstName = firstName;
                    u.LastName = lastName;
                    u.UserPasswordHash = CreateMD5(pass);
                    u.UserName = user;
                    ctx.Users.InsertOnSubmit(u);
                    ctx.SubmitChanges();
                    return "Good";
                }

            }
        
        
        }
        public string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public string TokenGen(int length)
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




//Create database ChatAPP
//go

//use ChatAPP
//go

//drop table Users

//create table Users
//(
//LastName nvarchar (256) 
//,FirstName nvarchar (256) 
//,UserName nvarchar (256) primary key
//,UserPasswordHash nvarchar (256) 
//,Token nvarchar (256)
//,ExpirienceDate DateTime
//)

//create table AllMessages
//(Id int identity primary key
//,Date DateTime
//,UserName nvarchar (256) references Users(UserName)
//,Message  nvarchar (2048)
//)

//create table PrivateMessages
//(Id int identity primary key
//,Date DateTime
//,UserNameFrom nvarchar (256) references Users(UserName)
//,UserNameTo nvarchar (256) references Users(UserName)
//,Message  nvarchar (2048)
//,IsSend Bit default 0 
//)