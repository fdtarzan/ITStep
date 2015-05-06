using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataWindow
{
    public partial class Form1 : Form
    {

        Module DrawerModule { get; set; }
        object Drawer;

        public Form1()
        {
            InitializeComponent();
        }
       
        public Form1(Module drawer, object targetWindow)
        {
           
            DrawerModule = drawer;
            Drawer = targetWindow;
            InitializeComponent();
            ComboInitial();
       

 
        }
        private void ComboInitial()
        {
            for (int i = 1; i < 32; i++)
            {
                comboBox.Items.Add(i);
            }
        }



        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (textBox.Text != null && comboBox.SelectedItem!=null)
            {
                DrawerModule.GetType("TemperatureDrawer.Form1").GetMethod("SetTemp").Invoke(Drawer, new object[] { this.comboBox.SelectedItem.ToString(), this.textBox.Text });
            }
        }






    }
}
