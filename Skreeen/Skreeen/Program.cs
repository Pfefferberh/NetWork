using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Skreeen
{
    class Program
    {
        static IPAddress pAddress = IPAddress.Parse("127.0.0.1");
        static int port = 8888;
        static TcpListener server = new TcpListener(pAddress, port);
        static TcpClient client = null;
        static NetworkStream networkStream = null;
        static void Main(string[] args)
        {
            server.Start();
            try
            {

                while (true)
                {
                    Console.WriteLine("Ожидание подключений... ");
                    client = server.AcceptTcpClient();

                    Console.WriteLine("Подключен клиент. Выполнение запроса...");

                    networkStream = client.GetStream();

                    string response = "Hello";
                    byte[] data = Encoding.UTF8.GetBytes(response);

                    networkStream.Write(data, 0, data.Length);

                    int bytes = networkStream.Read(data, 0, data.Length);
                    string temp = Encoding.UTF8.GetString(data, 0, bytes);
                    Console.WriteLine(temp);

                    Bitmap screen = new Bitmap(1000, 1000);
                    using (Graphics g = Graphics.FromImage(screen))
                    {
                        g.CopyFromScreen(5, 5, 00, 0, screen.Size);
                        screen.Save("test.Png", ImageFormat.Png);
                    }
                    Image image = Image.FromFile("test.Png");
                    byte[] xByte = File.ReadAllBytes("test.Png"); 

                    byte[] lng = BitConverter.GetBytes(xByte.Length);
                    networkStream.Write(lng, 0, lng.Length);
                    int umova = xByte.Length / 8;
                    for (int i = 0; i < umova; i++)
                    {
                        if (i == 0)
                            networkStream.Write(xByte, i, 8);
                        else
                            networkStream.Write(xByte, i * 8, 8);
                    }
                    networkStream.Write(xByte, 8 * umova, xByte.Length - 8 * umova);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                networkStream.Close();
                client.Close();
                if (server != null)
                    server.Stop();
            }
        }
    }
}
