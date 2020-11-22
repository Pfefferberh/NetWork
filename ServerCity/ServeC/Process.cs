using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServeC
{

    public class Process
    {
        public TcpClient client;
        public Process(TcpClient tcpClient)
        {
            client = tcpClient;
        }
        public void Pro()
        {
            Dictionary<int, string> Cityes = new Dictionary<int, string>();

            Cityes.Add(1111, "Rivno");
            Cityes.Add(2222, "Zmerenka");
            Cityes.Add(3333, "Sarny");
            Cityes.Add(4444, "Kiev");
            Cityes.Add(5555, "Kostopil");

            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                byte[] data = new byte[64];
                while (true)
                {
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    string message = builder.ToString();
                    foreach (KeyValuePair<int, string> item in Cityes)
                    {
                        if (item.Key == Convert.ToInt32(message))
                        {
                            message = item.Value;
                            data = Encoding.UTF8.GetBytes(message);
                            stream.Write(data, 0, data.Length);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }
    }
}
          
