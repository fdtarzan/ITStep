using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCF_BankService
{
    //контракт службы	
    [ServiceContract (SessionMode=SessionMode.Required)]
    public interface IBankService
    {
        [OperationContract]
        void ToDeposit(double sum);
        [OperationContract]
        double GetBalance();
    }

    //класс службы	
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple, InstanceContextMode=InstanceContextMode.Single)] 
    public class BankService : IBankService
    {
        static int id = 0;		//для нумерации создаваемых счетов
        public double Balance;	//баланс счета

        //создание нового счета
        public BankService()
        {
            ++id;
            Console.WriteLine("Создан счет № " + id.ToString());
        }
        //перевод денег на созданный счет
     //   [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void ToDeposit(double sum)
        {
            Console.WriteLine("Изменение баланса");
            this.Balance += sum;




            double bal = GetBalance();
            //Console.WriteLine("Баланс: {0}", bal);
        }

        //вывод текущего баланса счета
    //   [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public double GetBalance()
        {
            Console.WriteLine("Баланс: {0}", Balance);
            return Balance;
        }

       public double GetBalance2()
       {
        //   OperationContext.Current.SetTransactionComplete();
           return Balance;
       }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(BankService));

            sh.Open();
            Console.WriteLine("Для завершения нажмите<ENTER>\n\n");
            Console.ReadLine();
            sh.Close();
        }
    }
}
