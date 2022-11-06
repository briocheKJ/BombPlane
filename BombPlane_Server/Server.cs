using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BombPlane
{
    class Server
    {
        static string ip = "127.0.0.1";
        static int port = 1111;
        public static void Main(string[] args)
        {
            Console.WriteLine("服务器启动.....");
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            EndPoint point = new IPEndPoint(IPAddress.Parse(ip), port);
            server.Bind(point);
            server.Listen(100);

            Socket socket1 = server.Accept();
            Console.WriteLine("a client connect.....");

            Socket socket2 = server.Accept();
            Console.WriteLine("a client connect.....");

            (new ReadyMsg()).Send(socket1);
            (new ReadyMsg()).Send(socket2);

            Transmitor trans1 = new Transmitor(socket1, socket2);
            Transmitor trans2 = new Transmitor(socket2, socket1);

            Thread thread1 = new Thread(trans1.Runner);
            Thread thread2 = new Thread(trans2.Runner);

            thread1.Start();
            thread2.Start();
        }
    }
    class Transmitor
    {
        public Socket socket1;
        public Socket socket2;
        public Transmitor(Socket socket1, Socket socket2)
        {
            this.socket1 = socket1;
            this.socket2 = socket2;
        }
        public void Runner()
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                int len = socket1.Receive(bytes);
                string content = Encoding.UTF8.GetString(bytes, 0, len);
                socket1.Send(Encoding.UTF8.GetBytes(content));
            }
        }
    }
    
}
