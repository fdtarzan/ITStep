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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnReg_Click(object sender, EventArgs e)
        {
            AuthClient ac = new AuthClient();
            if (tbUserName.Text != "" && tbPass.Text != "" && tbFN.Text != "" && tbLN.Text != "")
            {
                string res = await ac.RegisterAsync(tbUserName.Text, tbPass.Text, tbFN.Text, tbLN.Text);
                if (res == "Good")
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login Exist");
                }
            }
            else
            {
                MessageBox.Show("not all fields");
            
            }
            ac.Close();
           
        }
    }
}
