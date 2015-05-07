using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace AddDomain
{
    class Program
    {
        static AppDomain TemperatureDrawer;        
        static AppDomain DataWindow;   
        static Assembly TemperatureDrawerAsm;      
        static Assembly DataWindowAsm;
        static Form TemperatureDrawerWindow;      
        static Form DataWindowWnd;     
            
   
        [STAThread]
        [LoaderOptimization(LoaderOptimization.MultiDomain)]
        static void Main(string[] args)
        {
           
            Application.EnableVisualStyles();
            TemperatureDrawer = AppDomain.CreateDomain("TemperatureDrawer");
            DataWindow = AppDomain.CreateDomain("DataWindow");
            TemperatureDrawerAsm = TemperatureDrawer.Load(AssemblyName.GetAssemblyName("TemperatureDrawer.exe"));
            DataWindowAsm = TemperatureDrawer.Load(AssemblyName.GetAssemblyName("DataWindow.exe"));

             TemperatureDrawerWindow = Activator.CreateInstance(TemperatureDrawerAsm.GetType("TemperatureDrawer.Form1")) as Form;
            
             DataWindowWnd = Activator.CreateInstance(
             DataWindowAsm.GetType("DataWindow.Form1"),
             new object[]
                 {
                     TemperatureDrawerAsm.GetModule("TemperatureDrawer.exe"),
                     TemperatureDrawerWindow
                 }) as Form;
             
            (new Thread(new ThreadStart(RunSetter))).Start();
            (new Thread(new ThreadStart(RunDrawer))).Start();
        }

        static void RunDrawer()
        {
           TemperatureDrawerWindow.ShowDialog();
           Application.Exit();
        }
        static void RunSetter()
        {
            DataWindowWnd.ShowDialog();
            Application.Exit();
        }
    }
}
