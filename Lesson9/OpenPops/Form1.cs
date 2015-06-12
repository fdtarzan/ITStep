using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPop;
using OpenPop.Pop3;

namespace OpenPops
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using (Pop3Client p = new Pop3Client())
            {
                p.Connect("pop3.ukr.net", 110, false);
                p.Authenticate("", "*");
                int messageCount = p.GetMessageCount();
                for (int i = messageCount; i > 0; i--)
                {
                    listBox1.Items.Add(p.GetMessage(i).Headers.Subject); 
                }
              //webBrowser1.DocumentText = p.GetMessage(0).Headers;
            
            }

            
        }
    }
}
