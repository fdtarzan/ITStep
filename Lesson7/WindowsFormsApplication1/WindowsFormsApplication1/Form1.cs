using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Clear();

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tbServer.Text);
                request.Credentials = new NetworkCredential(tbLogin.Text, tbPass.Text);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                richTextBox1.Text += reader.ReadToEnd();
                reader.Close();
                responseStream.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tbServer.Text + textBox1.Text);
            request.Credentials = new NetworkCredential(tbLogin.Text, tbPass.Text);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.UseBinary = true;
            request.UsePassive = false;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            using (Stream responseStream = response.GetResponseStream())
            {
                using(FileStream writer = new FileStream(textBox1.Text, FileMode.Create))
                {

                    long length = response.ContentLength;
                    int bufferSize = 1024;
                    int readCount;
                    byte[] buffer = new byte[1024];

                    readCount = responseStream.Read(buffer, 0, bufferSize);
                    while (readCount > 0)
                    {
                        writer.Write(buffer, 0, readCount);
                        readCount = responseStream.Read(buffer, 0, bufferSize);
                    }
                }
            }
        }
    }
}
