using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombPlane
{
    abstract class Player
    {
        abstract public int[][] SetPlane(int player);
        abstract public int TakeAction(int[][] state);
    }

    class RealPlayer : Player
    {
        private AutoResetEvent selectEvent = new AutoResetEvent(false);
        private AutoResetEvent actionEvent = new AutoResetEvent(false);
        private Control UIControl;
        private GameForm gameForm;
        private RivalView rivalForm;

        public RealPlayer(Control UI, RivalView rival)
        {
            gameForm = new GameForm(selectEvent);
            rivalForm = rival;
            UIControl = UI;
        }
        public override int[][] SetPlane(int player)
        {
            int[][] pos;

            UIControl.Invoke(new MethodInvoker(delegate { gameForm.Show(); }));

            selectEvent.WaitOne();
            //notice UI, wait for return

            UIControl.Invoke(new MethodInvoker(delegate { gameForm.Close(); }));

            pos = (int[][])CellManager.getInstance().PlaneSubmit().Clone();
            return pos;
        }

        public override int TakeAction(int[][] state)
        {
            int act = 0;

            rivalForm.SetActionEvent(actionEvent);
            //Display

            actionEvent.WaitOne();
            //notice UI, wait for return
            act = CellManager.getInstance().LastBomb();
            return act;
        }
    }

    class AIPlayer_Random : Player
    {
        public override int[][] SetPlane(int player)
        {
            int[][] pos = new int[10][];
            for(int i=0; i<10; i++)
                pos[i] = new int[10];
            
            int[] npx = new int[10] {-1, 0, 0, 0, 0, 0, 1, 2, 2, 2};
            int[] npy = new int[10] {0, -2, -1, 0, 1, 2, 0, -1, 0, 1};

            Random rand = new Random();
            bool flag = false;

            for (int i = 0; i < 3; i++)
            {
                int x = 0, y = 0, r = 0;

                flag = false;
                while (!flag)
                {
                    flag = true;
                    x = rand.Next(10);
                    y = rand.Next(10); //position
                    r = rand.Next(4); //direction
                    for (int j = 0; j < 10; j++)
                    {
                        int nx = x + rotate(npx[j], npy[j], r, true);
                        int ny = y + rotate(npx[j], npy[j], r, false);

                        if (nx < 0 || nx >= 10 || ny < 0 || ny >= 10 || pos[nx][ny] != 0)
                        {
                            flag = false;
                            break;
                        }
                    }
                }

                for (int j = 0; j < 10; j++)
                {
                    int nx = x + rotate(npx[j], npy[j], r, true);
                    int ny = y + rotate(npx[j], npy[j], r, false);
                    pos[nx][ny] = (j == 0) ? 2 : 1;
                }

                CellManager.getInstance().PlacePlane(x, y, r);
            }

            //AI set plane
            return pos;
        }

        private int rotate(int x, int y, int r, bool side)
        {
            if (r == 0)
            {
                if (side) return x;
                else return y;
            }
            else if (r == 1)
            {
                if (side) return y;
                else return -x;
            }
            else if (r == 2)
            {
                if (side) return -x;
                else return -y;
            }
            else
            {
                if (side) return -y;
                else return x;
            }
        }
        public override int TakeAction(int[][] state)
        {
            Random rand = new Random();
            int act;

            while (true)
            {
                act = rand.Next(100);
                if (state[act / 10][act % 10] == -1) break;
            }

            Thread.Sleep(1000);

            return act;
        }
    }
}
