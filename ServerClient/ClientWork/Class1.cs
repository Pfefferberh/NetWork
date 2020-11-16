using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientWork
{
    public class ClientWorker
    {
        int port;
        string server;
        TcpClient client = null;
        NetworkStream stream = null;
        public ClientWorker(int port, string server)
        {
            this.port = port;
            this.server = server;
            try
            {
                client = new TcpClient();
                client.Connect(server, port);
                stream = client.GetStream();
            }
            catch (SocketException e)
            {
                MessageBox.Show($"SocketException: {e}");
                stream.Close();
                client.Close();
            }
        }
        public void Send(string response)
        {
            try
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(response);
                stream.Write(data, 0, data.Length);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Exception: {e}");
                stream.Close();
                client.Close();
            }
        }
        public NetworkStream Read()
        {
            
                //try
                //{

                //    StringBuilder read = new StringBuilder();
                //    byte[] data = new byte[256];
                //    do
                //    {
                //        int bytes = stream.Read(data, 0, data.Length);
                //        read.Append(Encoding.UTF8.GetString(data, 0, bytes));
                //    }
                //    while (stream.DataAvailable);
                //    return read.ToString();
                //}
                //catch (Exception e)
                //{
                //    MessageBox.Show($"Exception: {e}");
                //    stream.Close();
                //    client.Close();
                //}
                return stream;
            
        }
    }
}
