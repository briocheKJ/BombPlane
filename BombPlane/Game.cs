using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BombPlane
{
    class Game
    {
        private Socket socket;

        private StartForm UIControl;
        private RivalView rivalForm;

        private int gameMode; //0: local, 1: online
        private Player[] player;
        private int[][][] planePos; //position of the planes
        private bool[][][] revealed; //whether or not the tiles are revealed

        private int turn;

        public Game(StartForm UI, RivalView rival, int mode, Player player0, Player player1 = null)
        {
            UIControl = UI;
            rivalForm = rival;
            rivalForm.DisableButtons();

            gameMode = mode;

            player = new Player[2];
            player[0] = player0;
            player[1] = player1;

            revealed = new bool[2][][];
            for (int t = 0; t <= 1; t++)
            {
                revealed[t] = new bool[10][];
                for (int i = 0; i < 10; i++)
                    revealed[t][i] = new bool[10];
            }
        }

        public void Run()
        {
            bool playerReturned = false;
            bool player0Conceded = false;
            bool player1Conceded = false;

            Random rand = new Random();
            if (gameMode == 0) turn = rand.Next(2);
            else
            {
                ConnectToServer();

                waitStr = "等待对方连接服务器...";
                UIControl.Invoke(new MethodInvoker(ShowWaitForm));

                Msg msg = Msg.Receive(socket);

                UIControl.Invoke(new MethodInvoker(CloseWaitForm));

                turn = ((ReadyMsg)msg).proi ? 1 : 0;
            }
            //wait for connection, decide turn order

            planePos = new int[2][][];

            planePos[0] = player[0].SetPlane(0);
            if (planePos[0] == null) playerReturned = true;

            if (gameMode == 0) planePos[1] = player[1].SetPlane(1);
            else
            {
                planePos[1] = new int[10][];
                for (int i = 0; i < 10; i++)
                    planePos[1][i] = new int[10];

                StartMsg start = new StartMsg(!playerReturned);
                start.Send(socket);

                if (playerReturned) waitStr = "等待与服务器断开连接...";
                else waitStr = "等待对方放置飞机...";
                
                UIControl.Invoke(new MethodInvoker(ShowWaitForm));

                Msg msg = Msg.Receive(socket);

                UIControl.Invoke(new MethodInvoker(CloseWaitForm));

                if (((StartMsg)msg).ack == false)
                {
                    if (!playerReturned) waitStr = "对方已断开连接！";
                    else waitStr = "已断开连接！";
                    UIControl.Invoke(new MethodInvoker(ShowWaitForm));
                    Thread.Sleep(2000);
                    UIControl.Invoke(new MethodInvoker(CloseWaitForm));
                    playerReturned = true;
                }
                //Opponent ready
            }

            if (!playerReturned)
            {
                CellManager.getInstance().SetTurn(turn);
                UIControl.Invoke(new MethodInvoker(ShowRivalForm));
                sync.WaitOne();
            }

            while (true)
            {
                if (playerReturned) //Player0 backed out
                {
                    turn = -1;
                    break;
                }

                if (gameMode == 0 || turn == 0)
                {
                    int[][] state = new int[10][];
                    for (int i = 0; i < 10; i++)
                        state[i] = new int[10];

                    for (int i = 0; i < 10; i++)
                        for (int j = 0; j < 10; j++)
                            if (revealed[(turn + 1) % 2][i][j])
                                state[i][j] = planePos[(turn + 1) % 2][i][j];
                            else state[i][j] = -1;

                    CellManager.getInstance().SwitchTurn();
                    UIControl.Invoke(new MethodInvoker(UpdateLabel));
                    sync.WaitOne();
                    
                    act = player[turn].TakeAction(state);
                    if (act == -1) player0Conceded = true;
                }
                else
                {
                    CellManager.getInstance().SwitchTurn();
                    UIControl.Invoke(new MethodInvoker(UpdateLabel));
                    sync.WaitOne();
                }

                if (gameMode == 1)
                {
                    if (turn == 0)
                    {
                        OperationMsg sending;

                        if (!player0Conceded) sending = new OperationMsg(act / 10, act % 10);
                        else sending = new OperationMsg(-1, -1); //Notice opponent that you conceded

                        sending.Send(socket);

                        if (player0Conceded) break;

                        Msg recving = Msg.Receive(socket);
                        res = ((FeedbackMsg)recving).feedback;
                        //send action and receive result
                    }
                    else
                    {
                        Msg recving = Msg.Receive(socket);
                        int opx = ((OperationMsg)recving).opx;
                        int opy = ((OperationMsg)recving).opy;

                        if (opx < 0)
                        {
                            player1Conceded = true;
                            OperationMsg back = new OperationMsg(-2, -2);
                            back.Send(socket); //Shut down associated server thread
                            break;
                        }

                        act = opx * 10 + opy;
                        res = planePos[0][opx][opy];

                        FeedbackMsg sending = new FeedbackMsg(res);
                        sending.Send(socket);
                        //receive action and send result
                    }
                }
                else
                {
                    if (player0Conceded) break;
                    res = planePos[(turn + 1) % 2][act / 10][act % 10];
                }

                revealed[(turn + 1) % 2][act / 10][act % 10] = true;
                planePos[(turn + 1) % 2][act / 10][act % 10] = res;
                UIControl.Invoke(new MethodInvoker(UpdateColor));
                sync.WaitOne();
                //process action and display on UI

                turn = (turn + 1) % 2;

                int cnt = 0;
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                        if (revealed[turn][i][j] && planePos[turn][i][j] == 2) cnt++;
                if (cnt == 3) break;
                //has the game ended?
            }
            //game loop

            if (gameMode == 1 && !player0Conceded && !player1Conceded)
            {
                EndMsg endMsg = new EndMsg();
                endMsg.Send(socket);
            }

            if (!playerReturned) //game ended
            {
                if (player0Conceded) turn = 0;
                if (player1Conceded) turn = 1;

                UIControl.Invoke(new MethodInvoker(delegate
                {
                    GameEndForm gameOverForm = new GameEndForm(turn == 1);
                    gameOverForm.Show();

                    Sleep(2000);

                    gameOverForm.Close();
                    //game over screen

                    rivalForm.Close();
                    UIControl.Show();
                    //back to start screen
                }));
            }
            else //game never started
            {
                UIControl.Invoke(new MethodInvoker(delegate
                {
                    rivalForm.Close();
                    UIControl.Show();
                    //back to start screen
                }));
            }
        }

        void Sleep(int ms)
        {
            AutoResetEvent clock = new AutoResetEvent(false);
            Thread thread = new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(ms);
                clock.Set();
            }));
            thread.Start();
            clock.WaitOne();
        }

        void ConnectToServer()
        {
            //string ip = "49.140.58.108";
            string ip = "127.0.0.1"; //local debugging
            int port = 1111;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            EndPoint point = new IPEndPoint(IPAddress.Parse(ip), port);
            socket.Connect(point);
        }

        void ShowRivalForm()
        {
            rivalForm.Show();
            rivalForm.initView(turn, planePos[0]);
            sync.Set();
        }

        int act = 0, res = 0;
        AutoResetEvent sync = new AutoResetEvent(false);
        void UpdateLabel()
        {
            rivalForm.updateView(turn, false, 0, 0, 0);
            sync.Set();
        }

        void UpdateColor()
        {
            rivalForm.updateView(turn, true, act / 10, act % 10, res);
            sync.Set();
        }

        string waitStr;
        WaitForm waitForm;

        void ShowWaitForm()
        {
            waitForm = new WaitForm(waitStr);
            waitForm.Show();
        }

        void CloseWaitForm()
        {
            waitForm.Close();
        }
    }
}
