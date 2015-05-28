using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace HTMLAgility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument hd = hw.Load("http://kino.rovno.ua/ua/archive/");
            HtmlNodeCollection node = hd.DocumentNode.SelectNodes("//*[@id='page-content']/blockquote");
           




        }
    }
}
