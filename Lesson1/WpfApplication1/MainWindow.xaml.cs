using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Process myProcess;
        public MainWindow()
        {
            InitializeComponent();
            myProcess = new Process();
            myProcess.StartInfo = new ProcessStartInfo("calc.exe");
           
        }

        private void Start_Click_1(object sender, RoutedEventArgs e)
        {
            myProcess.Start();
        }

        private void Stop_Click_1(object sender, RoutedEventArgs e)
        {
            if (!myProcess.HasExited)
            {
                myProcess.CloseMainWindow();
                myProcess.Close();
            }
            
        }
    }
}
