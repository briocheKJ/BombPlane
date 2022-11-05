using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombPlane
{
    class Game
    {
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
            if (gameMode == 1)
            {
                ConnectToServer();
                //receive game start confirmation
            }
            //wait for connection

            planePos = new int[2][][];

            planePos[0] = player[0].SetPlane(0);
            if (gameMode == 0) //planePos[1] = player[1].SetPlane(1);
                planePos[1] = (int[][])planePos[0].Clone();
            else
            {
                planePos[1] = new int[10][];
                for (int i = 0; i < 10; i++)
                    planePos[1][i] = new int[10];
            }

            Random rand = new Random();
            if (gameMode == 0) turn = rand.Next(2);
            else
            {
                //Message.Recv(); //should receive turn order
            }
            //decide turn order

            CellManager.getInstance().SetTurn(turn);
            UIControl.Invoke(new MethodInvoker(ShowRivalForm));
            rivalForm.initView();

            while (true)
            {
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
                        //send action and receive result
                    }
                    else
                    {
                        //receive action and send result
                    }
                }
                else res = planePos[(turn + 1) % 2][act / 10][act % 10];

                revealed[(turn + 1) % 2][act / 10][act % 10] = true;
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

            //game over screen

            UIControl.Invoke(new MethodInvoker(delegate { rivalForm.Close(); UIControl.Show(); }));
        }

        void ConnectToServer()
        {
            //todo
        }

        void ShowRivalForm()
        {
            rivalForm.Show();
        }

        int act = 0, res = 0;
        AutoResetEvent sync = new AutoResetEvent(false);
        void UpdateLabel()
        {
            rivalForm.updateView(turn, false);
            sync.Set();
        }

        void UpdateColor()
        {
            rivalForm.updateView(turn, true, act / 10, act % 10, res);
            sync.Set();
        }
    }
}
