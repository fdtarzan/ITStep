﻿using System;
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
    public class ChatCallbackHandler : IChatCallback
    {
        static InstanceContext site = new InstanceContext(new ChatCallbackHandler());
        public static ChatClient clientProxy = new ChatClient(site);
        
        public delegate void MethodContainer(string t);
        public delegate void MethodContainer_list(List<string> t);
        public static event MethodContainer onNewMessage;
        public static event MethodContainer_list onRefreshListOnline;

        public void NewMessage(string t)
        {
                       onNewMessage(t);
        
        }


        public void NewPrivateMessage(string t)
        {
            throw new NotImplementedException();
        }

        public void RefreshListOnline(List<string> list)
        {
            onRefreshListOnline(list);
        }
    }

    public partial class FormChatClient : Form
    {
        ChatCallbackHandler cch;
        public string Token { set; get; }
        public string UserName { set; get; }
        
        public FormChatClient()
        {
            InitializeComponent();
            cch = new ChatCallbackHandler();
            ChatCallbackHandler.onNewMessage += (t) => { lbChat.Items.Add(t); };
            ChatCallbackHandler.onRefreshListOnline += (t) => {
               // lbUsers.Items.Clear();
                lbUsers.DataSource = t;
                
            };
        }
        private async void FormChatClient_FormClosed(object sender, FormClosedEventArgs e)
        {

          await  ChatCallbackHandler.clientProxy.DisconectAsync(UserName);
            Application.Exit();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {

            await ChatCallbackHandler.clientProxy.SendMessageToAllAsync(tbMessage.Text, UserName);
        }

        private void FormChatClient_Load(object sender, EventArgs e)
        {

            //clientProxy.Connect(Token);
            FormAuth fa = new FormAuth();
            this.Enabled=false;
            fa.Show(this);
            
        }

        
        public  async void Connect()
        {
            await ChatCallbackHandler.clientProxy.ConnectAsync(UserName);
        }
        public void onRefreshListOnline(List<string> list)
        {
            lbUsers.Items.Clear();
            lbUsers.DataSource = list;
            foreach (var item in list)
            {
               MessageBox.Show(item); 
            }
          
       
        }
    }
    
}
