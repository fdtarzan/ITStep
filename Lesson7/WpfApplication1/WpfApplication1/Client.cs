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
    public class Client
    {
       
        IPAddress ipAdr;
        IPEndPoint iPEnd;
        Socket sSender;
        int offset;
        byte[] datasend;
        public Client(string ip, string port)
        {
            ipAdr = IPAddress.Parse(ip);
           // iPEnd = new IPEndPoint(ipAdr, Convert.ToInt32(port));
            // sSender = new Socket(ipAdr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            iPEnd = new IPEndPoint(ipAdr, Convert.ToInt32(port));
            sSender = new Socket(ipAdr.AddressFamily, SocketType.Dgram, ProtocolType.Udp);

        }

        public void Send(string data)
        {
            try
            {
                offset = 0;
                datasend = Encoding.UTF8.GetBytes(data);
                sSender.BeginConnect(iPEnd, new AsyncCallback(OnConnect), sSender);  
            }
            catch (Exception ex)
            { }
        }

        private void OnConnect(IAsyncResult obj)
        {
            Socket client = (Socket)obj.AsyncState;

            client.EndConnect(obj);

            client.BeginSend(datasend, offset, Math.Min(datasend.Length - offset, 1024), SocketFlags.None, new AsyncCallback(OnSend), client);
        }                                                   // поступово поислаэмо і перевірямо чи різниця всіх мінус тих що , вже відіслані більша 1024
        // якщо ні то візьмемо хвостик 

        private void OnSend(IAsyncResult obj)
        {
            Socket sok = (Socket)obj.AsyncState;
            int byteSend = sok.EndSend(obj); 
            offset += byteSend;
            if (offset < datasend.Length)
            {
                sok.BeginSend(datasend, offset, Math.Min(datasend.Length - offset, 1024), SocketFlags.None, new AsyncCallback(OnSend), sok);
            }
            else
            {
                sok.Shutdown(SocketShutdown.Both);
                sok.Close();

            }
        }
    }
}
