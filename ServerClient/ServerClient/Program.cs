using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerClient
{
    class Program
    {
        const int port = 8888; 
        static void Main(string[] args)
        {
            TcpListener tcpListener = null;
            try
            {
                IPAddress address = IPAddress.Parse("127.0.0.1");
                tcpListener = new TcpListener(address,port);
                tcpListener.Start();
                while (true)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    ClientObject clientObject = new ClientObject(client);

                    // создаем новый поток для обслуживания нового клиента
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (tcpListener != null)
                    tcpListener.Stop();
            }
        }

        public class ClientObject
        {
            public TcpClient client;
            public ClientObject(TcpClient tcpClient)
            {
                client = tcpClient;
            }

            public void Process()
            {
                NetworkStream stream = null;
                try
                {
                    stream = client.GetStream();
                    byte[] data = new byte[64]; // буфер для получаемых данных
                        data = Encoding.UTF8.GetBytes("Hello");
                        stream.Write(data, 0, data.Length);
                    while (true)
                    {
                        Console.WriteLine("Server there");
                        // получаем сообщение
                        StringBuilder builder = new StringBuilder();
                        int bytes = 0;
                        do
                        {
                            bytes = stream.Read(data, 0, data.Length);
                            builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
                        }
                        while (stream.DataAvailable);

                        string message = builder.ToString();

                        Console.WriteLine(message);
                        Console.WriteLine("Write sentens");
                        message = Console.ReadLine();

                        // отправляем обратно сообщение в верхнем регистре
                        //    message = message.Substring(message.IndexOf(':') + 1).Trim().ToUpper();
                        data = Encoding.UTF8.GetBytes(message);
                        stream.Write(data, 0, data.Length);
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
}
