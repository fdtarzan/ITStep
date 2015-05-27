using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Json
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          //  webBrowser1.Navigate("https://oauth.vk.com/authorize?client_id=4935014&scope=friends&redirect_uri=https://oauth.vk.com/blank.html&response_type=token&v=5.33&state=SESSION_STATE&display=popup");


            WebRequest request = WebRequest.Create("https://api.vk.com/method/friends.get?user_id=8436362&v=5.33&order=name&fields=city,domain&name_case=nom&access_token=899b4be230864233a0539e64d2d491cf39f4bf539734b8b3d30d40c125c4b48b7f88fc6f3269d3b770419");
            WebResponse response = (HttpWebResponse)request.GetResponse();

            Stream dataStream = response.GetResponseStream();
           
            StreamReader reader = new StreamReader(dataStream);
           
            string responseFromServer = reader.ReadToEnd();
            //richTextBox1.Text = responseFromServer;

            FriendsInfo fid = JsonConvert.DeserializeObject<FriendsInfo>(responseFromServer);
            foreach (var el in fid.response.items)
            {
                if (el.online == 1)
                {
                    listBox1.Items.Add(el.first_name +" "+ el.last_name);
                }
                else
                {
                    listBox2.Items.Add(el.first_name + " " + el.last_name);
                }
                
            
            }

           
            //MessageBox.Show(responseFromServer);



        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.Text = webBrowser1.Url.AbsoluteUri;


          //  899b4be230864233a0539e64d2d491cf39f4bf539734b8b3d30d40c125c4b48b7f88fc6f3269d3b770419
        }
      
    }



    public class City
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class Item
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string domain { get; set; }
        public City city { get; set; }
        public int online { get; set; }
        public string deactivated { get; set; }
        public List<int?> lists { get; set; }
    }

    public class Response
    {
        public int count { get; set; }
        public List<Item> items { get; set; }
    }

    public class FriendsInfo
    {
        public Response response { get; set; }
    }
}
