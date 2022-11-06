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

            Msg msg = null;
            switch (type)
            {
                case "ReadyMsg":
                    msg = (Msg)(JsonConvert.DeserializeObject<ReadyMsg>(jsonString));
                    break;
                case "OperationMsg":
                    msg = (Msg)(JsonConvert.DeserializeObject<OperationMsg>(jsonString));
                    break;
                case "FeedbackMsg":
                    msg = (Msg)(JsonConvert.DeserializeObject<FeedbackMsg>(jsonString));
                    break;
                case "EndMsg":
                    msg = (Msg)(JsonConvert.DeserializeObject<EndMsg>(jsonString));
                    break;
                default:
                    msg = null;
                    break;
            }

            return msg;
        }
        abstract public void print();
    }
    class ReadyMsg : Msg
    {
        public bool proi; //if true, I first
        public ReadyMsg(bool priority) : base("ReadyMsg")
        {
            this.proi = priority;
        }
        override public void print()
        {
            Console.WriteLine(proi?"I first":"opponent first");
        }
    }

    class OperationMsg : Msg
    {
        public int opx;
        public int opy;
        public OperationMsg(int opx,int opy) : base("OperationMsg")
        {
            this.opx = opx;
            this.opy = opy;
        }
        override public void print()
        {
            Console.WriteLine("operation:({0},{1})",opx,opy);
        }
    }
    class FeedbackMsg : Msg
    {
        public int feedback;
        public FeedbackMsg(int feedback) : base("FeedbackMsg")
        {
            this.feedback = feedback;
        }
        override public void print()
        {
            Console.WriteLine("feedback:{0}",feedback);
        }
    }
    class EndMsg : Msg
    {
        public string text = "GoodBye!!";
        public EndMsg() : base("EndMsg")
        {
        }
        public override void print()
        {
            Console.WriteLine("end:{0}", text);
        }
    }
}
