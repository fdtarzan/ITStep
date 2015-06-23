using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatApp.ServiceAuthNS;

namespace ChatApp
{
    public partial class FormAuth : Form
    {
        public FormAuth()
        {
            InitializeComponent();
            
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            AuthClient ac = new AuthClient();
            if (tbUserName.Text != "" && tbPass.Text != "")
            {
                string res = await ac.AutorizeAsync(tbUserName.Text, ac.CreateMD5(tbPass.Text));
                ac.Close();
                if (res == "LoginError")
                {
                    MessageBox.Show("Login or Password is incorrect");
                }
                else
                {
                    
                    
                    
                    (this.Owner as FormChatClient).Token = res;
                    (this.Owner as FormChatClient).UserName = tbUserName.Text;
                    //fc.Parent = fc;
                    
                    this.Close();
                
                }


            }
            else
            {
                MessageBox.Show("Enter data");
            }
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FormRegister fr = new FormRegister();
            fr.Show();
        }
    }
}
