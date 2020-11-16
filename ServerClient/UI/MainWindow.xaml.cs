using ClientWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClientWorker clientWorker = null;
        ObservableCollection<string> messageFrom = new ObservableCollection<string>();
        NetworkStream stream = null;
        public MainWindow()
        {
            InitializeComponent();
            tbIP.Text = "127.0.0.1";
            tbPort.Text = "8888";
            lbSceen.ItemsSource = messageFrom;
        }
        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            if (tbIP.Text != "" && tbPort.Text != "")
            {
                clientWorker = new ClientWorker(Convert.ToInt32(tbPort.Text), tbIP.Text);
                 stream = clientWorker.Read();
                Refresh_ScreenAsync();
            }
        }
        private void Send_Click(object sender, RoutedEventArgs e)
        {
            clientWorker.Send(tbSend.Text);
            messageFrom.Add(tbSend.Text);
            tbSend.Text = "";
        }

        void Refresh_Screen()
        {
            while(true)
            {
                byte[] data = new byte[64];
                string mess = "";
                int bytes = 0;
                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                 mess =  (Encoding.UTF8.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);
                Dispatcher.Invoke(() => messageFrom.Add(mess));
            }
        }
         void Refresh_ScreenAsync()
        {
            Thread clientThread = new Thread(new ThreadStart(Refresh_Screen));
            clientThread.Start();

        }


        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            //Refresh_ScreenAsync();
            //lbSceen.Items.Add(clientWorker.Read());
        }
    }
}
