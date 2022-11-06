using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BombPlane
{
    abstract class Msg
    {
        public string msgType { get; }

        public Msg() { }
        public Msg(string msgType) { this.msgType = msgType; }
        public byte[] getHead()
        {
            return Encoding.UTF8.GetBytes(msgType);
        }
        public void Send(Socket socket)
        {
            socket.Send(Encoding.UTF8.GetBytes(this.msgType));
            socket.Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this)));
        }
        static public Msg Receive(Socket socket)
        {
            byte[] bytes = new byte[1024];
            int len = socket.Receive(bytes);
            string type = Encoding.UTF8.GetString(bytes, 0, len);
            len = socket.Receive(bytes);
            string jsonString = Encoding.UTF8.GetString(bytes, 0, len);
            if (type == "ReadyMsg")
            {
                Msg msg = (Msg)(JsonConvert.DeserializeObject<ReadyMsg>(jsonString));
                return msg;
            }
            return null;
        }
    }
    class ReadyMsg : Msg
    {
        String text = "ack";
        public ReadyMsg() : base("ReadyMsg")
        {
        }
        public void print()
        {
            Console.WriteLine(text);
        }
    }
}
