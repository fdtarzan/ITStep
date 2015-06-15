using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCFDBClient.ServiceAuthNS;
using Newtonsoft.Json;
namespace WCFDBClient
{
    public partial class Form1 : Form
    {
        private string _token;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            AuthClient a = new AuthClient();
           string s=await a.AutorizeAsync(textBox1.Text,textBox2.Text);
           if (s == "LoginError")
               MessageBox.Show("Login Error");
           else
           {
               
            User u= JsonConvert.DeserializeObject<User>(s);
            _token = u.Token;
           }
            
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            AuthClient a = new AuthClient();
            string s = await a.UserInfoAsync(_token);
            if (s == "Incorrect Token")
            {
                MessageBox.Show("Incorrect Token");
            }
            else
            {
                User u = JsonConvert.DeserializeObject<User>(s);
                if (_token != null)
                {
                    label1.Text = u.FirstName;
                    label2.Text = u.LastName;
                }

            }
        }
    }
    public class User
    {

        public String LastName { set; get; }

        public String FirstName { set; get; }

        public String UserName { set; get; }

        public String UserPassword { set; get; }

        public String Token { set; get; }

        public DateTime ExpirienceDate { set; get; }





    }
}
