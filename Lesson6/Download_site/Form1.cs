using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Download_site
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // using (WebClient wc = new WebClient())
           // {
           //     wc.Encoding = Encoding.GetEncoding("UTF8");
           //    richTextBox1.Text=wc.DownloadString(new Uri("http://1gb.capsuleer.org/index.php"));
           //
           //    
           // 
           // }

            WebRequest wrec = WebRequest.Create("http://1gb.capsuleer.org/index.php");
            richTextBox1.Text = wrec.Headers.ToString();
            using (WebResponse wresp = wrec.GetResponse())
            {
                //richTextBox2.Text = wresp.Headers.ToString();
                using (Stream s = wresp.GetResponseStream())
                { 

               
                }

            }
            richTextBox1.Text = wrec.Headers.ToString();
           

        }
    }
}
