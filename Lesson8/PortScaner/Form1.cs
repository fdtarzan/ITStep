using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortScaner
{
    public partial class Form1 : Form
    {
        Thread ttcp,tudp;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ttcp = new Thread(PortScanTCP);
            ttcp.IsBackground = true;
            ttcp.Start();
            tudp = new Thread(PortScanUDP);
            tudp.IsBackground = true;
            tudp.Start();
        }
        public void PortScanTCP()
        {
            for (int i = 10000; i <65000; i++)
            {
                
                    TcpClient tc = new TcpClient();
                    try
                    {
                        tc.Connect("", i);
                       
                        this.Invoke((MethodInvoker)(() => listBox1.Items.Add(i)));
                        tc.Close();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    this.Invoke((MethodInvoker)(() =>listBox2.Items.Add(i))); 
                   
                }
                 
           }
        
        }
        public void PortScanUDP()
        {
            for (int i = 1; i < 65000; i++)
            {
                try
                {
                    UdpClient tc = new UdpClient("localhost", i);
                    tc.Connect("localhost", i);
                    this.Invoke((MethodInvoker)(() => listBox3.Items.Add(i)));

                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)(() => listBox4.Items.Add(i)));

                }

            }

        }
    }
}
