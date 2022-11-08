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
        //static string ip = "49.140.58.108";
        static string ip = "127.0.0.1"; //local debugging
        static int port = 1111;
        public static void Main(string[] args)
        {
            Console.WriteLine("server starting.....");
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            EndPoint point = new IPEndPoint(IPAddress.Parse(ip), port);
            server.Bind(point);
            server.Listen(100);
            while(true)
            {
                Socket socket1 = server.Accept();
                Console.WriteLine("a client connected.....");

                Socket socket2 = server.Accept();
                Console.WriteLine("a client connected.....");

                Random random = new Random();
                int turn = random.Next(2);
                Console.WriteLine("decide turn: player {0} first", turn);
                (new ReadyMsg(turn == 1)).Send(socket1);
                (new ReadyMsg(turn == 0)).Send(socket2);

                StartMsg start1 = (StartMsg)Msg.Receive(socket1);
                StartMsg start2 = (StartMsg)Msg.Receive(socket2);
                
                start1.Send(socket2);
                start2.Send(socket1);

                if (!start1.ack || !start2.ack) continue;

                Transmitor trans1 = new Transmitor(socket1, socket2);
                Transmitor trans2 = new Transmitor(socket2, socket1);

                Thread thread1 = new Thread(trans1.Runner);
                Thread thread2 = new Thread(trans2.Runner);

                thread1.Start();
                thread2.Start();
            }
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
                Msg msg=Msg.Receive(socket2);
                if(msg==null)
                {
                    Console.WriteLine("null error");
                    break;
                }
                msg.print();
                if (msg.msgType == "OperationMsg")
                {
                    int type = ((OperationMsg)msg).opx;
                    if (type == -1)
                    {
                        Console.WriteLine("one player conceded and disconnected");
                        msg.Send(socket1);
                        break;
                    }
                    if (type == -2)
                    {
                        Console.WriteLine("another player disconnected");
                        break;
                    }
                }
                if (msg.msgType == "EndMsg")
                {
                    Console.WriteLine("game ended. player disconnected.");
                    break;
                }
                msg.Send(socket1);
                Console.WriteLine("transmit successfully!");
            }
            Console.WriteLine("server thread closed");
            socket2.Close(); //only close receiving socket
        }
    }
    
}
