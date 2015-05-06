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
        static AppDomain TemperatureDrawer;        //будет хранить объект домена приложения TextDrawer
        static AppDomain DataWindow;    //будет хранить домена приложения TextWindow
        static Assembly TemperatureDrawerAsm;      //будет хранить объект сборки TextDrawer.exe
        static Assembly DataWindowAsm;  //будет хранить объект сборки TextWindow.exe
        static Form TemperatureDrawerWindow;       //будет хранить объект окна TextDrawer
        static Form DataWindowWnd;      //будет хранить объект окна TextWindow
            
   
        [STAThread]
        [LoaderOptimization(LoaderOptimization.MultiDomain)]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            TemperatureDrawer = AppDomain.CreateDomain("TemperatureDrawer");
            DataWindow = AppDomain.CreateDomain("DataWindow");
            /*загружаем сборки с оконными приложениями в соответствующие домены приложений*/
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
             
            (new Thread(new ThreadStart(RunVisualizer))).Start();
            (new Thread(new ThreadStart(RunDrawer))).Start();
        }

        static void RunDrawer()
        {
            /*запускаем окно модально в текущем потоке*/

           
            TemperatureDrawerWindow.ShowDialog();
            
            /*отгружаем домен приложения*/
            Application.Exit();
           
        }
        static void RunVisualizer()
        {
            /*запускаем окно модально в текущем потоке*/
            DataWindowWnd.ShowDialog();
            /*завершаем работу приложения, следствием чего станет закрытие потока*/
            Application.Exit();
        }
    }
}
