using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace MailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                sc.Credentials = new NetworkCredential("fdtarzan", "Alo3bnvm*");
                sc.EnableSsl = true;
                MailMessage mm = new MailMessage();
                mm.From = new MailAddress("tarzan@ukrwest.net");
                mm.To.Add(new MailAddress("fdtarzan@gmail.com"));
                mm.Subject = "hello";
                mm.Body = "test";
                

                sc.Send(mm);

                Console.WriteLine("ssssss");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
