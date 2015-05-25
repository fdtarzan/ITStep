using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
        Server ser1;
        Client client1;

        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ser1 = new Server(ipServer.Text, portServer.Text);
            ser1.onGet += AppendLineToChatBox;
            ser1.BeginListen();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //client1 = new Client(ipClient.Text, portClient.Text);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            client1 = new Client(ipClient.Text, portClient.Text);
            client1.Send(msgTB.Text);
            chatTB.AppendText(msgTB.Text + "\n");
            chatTB.ScrollToEnd();
            msgTB.Text = "";
        }
        public void AppendLineToChatBox(string message)
        {
            //To ensure we can successfully append to the text box from any thread
            //we need to wrap the append within an invoke action.
            chatTB.Dispatcher.BeginInvoke(new Action<string>((messageToAdd) =>
            {
                chatTB.AppendText(messageToAdd + "\n");
                chatTB.ScrollToEnd();
            }), new object[] { message });
        }
    }

  
}
