using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace wpfClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TcpClient client = new TcpClient();
        NetworkStream network = null;

        public MainWindow()
        {
            InitializeComponent();
            client.Connect("127.0.0.1", 8888);

            network = client.GetStream();
            byte[] data = new byte[256];
            int bytes = network.Read(data, 0, data.Length);

            txBlock.Text = Encoding.UTF8.GetString(data, 0, bytes);

            Task task = new Task(skreen);
            task.Start();


            this.Closed += closeee;

        }
        private void skreen()
        {
            int u = 0;
            byte[] lng = new byte[4];
            network.Read(lng, 0, lng.Length);
            int leng = BitConverter.ToInt32(lng, 0);
            byte[] da = new byte[leng];
            while (true)
            {
                byte[] dat = new byte[8];
                network.Read(dat, 0, dat.Length);
                if (u * 8 < leng)
                    foreach (var item in dat)
                    {
                        da[u] = item;
                        u++;
                    }
                else
                    for (int i = 0; i < leng - u * 8; i++)
                    {
                        da[u] = dat[i];
                        u++;
                    }


                if (da.Length == leng)
                {
                    File.WriteAllBytes("test.Png", da);

                    Dispatcher.Invoke(() => txBlock.Text = "All DONE!");
                }
            }
        }
        private void closeee(object sender, EventArgs e)
        {
            network.Close();
            client.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string response = "screen";
            byte[] data = Encoding.UTF8.GetBytes(response);
            network.Write(data, 0, data.Length);
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            cartoon.Stretch = Stretch.Fill;
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("test.Png", UriKind.Relative);
            bi3.EndInit();
            cartoon.Source = bi3;
            cartoon.UpdateLayout();
        }
    }
}
