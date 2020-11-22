using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;

namespace ServerCity
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int port = 8888;
        TcpClient client = new TcpClient();
        NetworkStream stream = null;
        const int size = 512;
        public MainWindow()
        {
            InitializeComponent();
            client.Connect("127.0.0.1", port);
            stream = client.GetStream();
            Thread t1 = new Thread(ResiveData);
            t1.Start();
        }

        void ResiveData()
        {
            byte[] data = new byte[64];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = stream.Read(data, 0, data.Length);
                builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);

            string message = builder.ToString();
            Dispatcher.Invoke(() => lbCity.Content = message);

        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            stream = client.GetStream();
            string msg = tbIndex.Text;
            stream.Write(Encoding.UTF8.GetBytes(msg), 0, msg.Length);

            byte[] responce = new byte[size];
            int count = 0;
            do
            {
                count = stream.Read(responce, 0, responce.Length);
            } while (stream.DataAvailable);
            Title = "Received: {0}" + Encoding.UTF8.GetString(responce, 0, count);

        }
    }
}
