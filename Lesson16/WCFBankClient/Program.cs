using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WCFBankClient.ServiceReference1;

namespace WCFBankClient
{
    class Program
    {
        static void Main(string[] args)
        {
            BankServiceClient proxy = new BankServiceClient();
            Console.WriteLine("Укажите сумму депозита:");
            double sum = Convert.ToDouble(Console.ReadLine());
            double result = 0;

            while (sum > 0)
            {
                proxy.ToDeposit(sum);
               // result = proxy.GetBalance();
                Console.WriteLine("Депозит = {0}", result);
                Console.WriteLine("Укажите сумму депозита:");
                sum = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine(proxy.InnerChannel.SessionId);
            }

            Console.WriteLine("Для завершения нажмите<ENTER>\n\n");
            proxy.Close();
            Console.ReadLine();
        }
    }
}
