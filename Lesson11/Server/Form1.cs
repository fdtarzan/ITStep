using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Command("Lock");
        }


        private void Command(string com)
        {
            UdpClient udpClient = new UdpClient();
            udpClient.Connect(IPAddress.Broadcast, 10000);
            byte[] bytes = Encoding.UTF8.GetBytes(com);
            udpClient.Send(bytes, bytes.Length);
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Command("Shutdown");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Command("CancelShutdown");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Command("Ololo");
        }
    }
}
