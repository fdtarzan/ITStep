using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatApp.ServiceChatNS;
using System.ServiceModel;

namespace ChatApp
{
    public partial class FormChatClient : Form, IChatCallback
    {
        static InstanceContext site = new InstanceContext(new FormChatClient());
        public static ChatClient clientProxy = new ChatClient(site);

        public void NewMessage(string t)
        {
            lbChat.Items.Add(t);
            this.Text = t;
            //MessageBox.Show(t);
        }

        public void NewPrivateMessage(string t)
        {
            throw new NotImplementedException();
        }
     
        public string Token { set; get; }
        public string UserName { set; get; }
        public FormChatClient()
        {
            InitializeComponent();
        }
        private void FormChatClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            clientProxy.Disconect(Token);
            Application.Exit();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {

            await clientProxy.SendMessageToAllAsync(tbMessage.Text, UserName);
        }

        private void FormChatClient_Load(object sender, EventArgs e)
        {
            //clientProxy.Connect(Token);
            FormAuth fa = new FormAuth();
            this.Hide();
            fa.Show(this);
        }


        public void RefreshListOnline(List<string> list)
        {
           // lbUsers.Items.Clear();
           // foreach (var item in list)
           // {
           //     lbUsers.Items.Add(item);
           // }
        }
    }
    
}
