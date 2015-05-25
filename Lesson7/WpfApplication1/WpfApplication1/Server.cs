using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{

    
    public class Server
    {
        
        IPAddress ipAdr;
        IPEndPoint iPEnd;
        Socket slistner;
        public delegate void MethodContainer(string message);
        public event MethodContainer onGet;

        
        byte[] buffer = new byte[1024]; /// буфер для зчитування
        /// 


        public Server(string ip, string port)
        {
            ipAdr = IPAddress.Parse(ip);
          //  iPEnd = new IPEndPoint(ipAdr, Convert.ToInt32(port));
          // slistner = new Socket(ipAdr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            iPEnd = new IPEndPoint(ipAdr, Convert.ToInt32(port));
            slistner = new Socket(ipAdr.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
        }

        public void BeginListen()
        {
            try
            {
                slistner.Bind(iPEnd);
               // slistner.Listen(10);
               
                slistner.BeginAccept(new AsyncCallback(OnAccept), slistner); //для асинхроного зєднання використовуємо делегат ,який дозволить перевести 
                //на новий сокет
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void OnAccept(IAsyncResult obj)
        {
            Socket oldsocket = obj.AsyncState as Socket;
            Socket slisynerRedir = oldsocket.EndAccept(obj);
            oldsocket.BeginAccept(new AsyncCallback(OnAccept), oldsocket); // переприсфоїв сокет 


            // починаємо зчитування
            slisynerRedir.BeginReceive(buffer, 0, 1024, 0, new AsyncCallback(onRecieve), slisynerRedir);

        }
        public void onRecieve(IAsyncResult obj)
        {
            //считує інформацію байтамми
            Socket recsocket = obj.AsyncState as Socket;
            int byteRec = recsocket.EndReceive(obj);

            if (byteRec > 0)
            {
                string content = Encoding.UTF8.GetString(buffer, 0, byteRec);
                onGet(content);
                
               
                if (content.IndexOf("<EOF>") > 0)
                {
                    recsocket.Shutdown(SocketShutdown.Both);
                    recsocket.Close();
                }
                else
                {
                    recsocket.BeginReceive(buffer, 0, 1024, 0, new AsyncCallback(onRecieve), recsocket);
                }
            }
            

        }

    }
}
