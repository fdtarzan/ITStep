
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nemiro.OAuth;
using Nemiro.OAuth.Clients;
using Nemiro.OAuth.LoginForms;
using System.Net;
using System.IO;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();

          //  var login = new DropboxLogin("g2xotvosgnbbom1", "klagjvlvst04qg3");
          //  login.Owner = this;
          //  login.ShowDialog();

//          if (login.IsSuccessfully)
  //           {
    //             AccessToken token = login.AccessToken;
            //    https://api.dropbox.com/1/account/info?access_token=ZVdlNH24xiEAAAAAAAAFwqj6_WnJk5iTo1n6fFrBA2oFDD1AqPZnaEZ26OhwEmjH
        //     }

            WebRequest wr = WebRequest.Create("https://api.dropbox.com/1/account/info?access_token=ZVdlNH24xiEAAAAAAAAFwqj6_WnJk5iTo1n6fFrBA2oFDD1AqPZnaEZ26OhwEmjH");
            WebResponse resp = wr.GetResponse();
            Stream data = resp.GetResponseStream();
            using (StreamReader reader = new StreamReader(data))
            {
                richTextBox1.Text = reader.ReadToEnd();
            }

        }
    }
}
