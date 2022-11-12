using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombPlane
{
    class AIPlayer_Entropy: Player
    {
        int[][][] store = Store.store;
        bool[] vis = new bool[70000];
        int tot = Store.tot;
        
        public override int[][] SetPlane(int player)
        {
            int[][] pos = new int[10][];
            for (int i = 0; i < 10; i++)
                pos[i] = new int[10];

            int[] npx = new int[10] { -1, 0, 0, 0, 0, 0, 1, 2, 2, 2 };
            int[] npy = new int[10] { 0, -2, -1, 0, 1, 2, 0, -1, 0, 1 };

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
            int act = -3,cnt=0,res=0;
            double mm=-1;
            for (int j = 0; j < tot; j++) vis[j] = false;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < tot; j++)
                {
                    if (state[i / 10][i % 10] != -1 && store[j][i / 10][i % 10] != state[i / 10][i % 10])
                        vis[j] = true;
                }
            }
            for (int j = 0; j < tot; j++)
                if (vis[j]) cnt++;
                else res = j;
            if(cnt==tot-1)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (state[i / 10][i % 10] == -1 && store[res][i / 10][i % 10] == 2)
                        return i;
                }
                return -2;
            }
            double[] entropy = new double[100];
            for (int i=0;i<100;i++)
            {
                if (state[i / 10][i % 10] != -1) continue;
                double blank=0, aim_head=0, aim_body=0,sum=0;
                for(int j=0;j<tot;j++)
                {
                    if (vis[j]) continue;
                    sum++;
                    if(store[j][i/10][i%10]==0)blank++;
                    if (store[j][i / 10][i % 10] == 1) aim_body++;
                    if (store[j][i / 10][i % 10] == 2) aim_head++;
                }
                entropy[i] = 0;
                if (blank != 0) entropy[i] += -blank / sum * Math.Log(blank / sum);
                if (aim_head != 0) entropy[i] += aim_head / sum * (1.0 - Math.Log(aim_head / sum));
                if(aim_body!=0)entropy[i]+= -aim_body / sum * Math.Log(aim_body / sum);
                if (entropy[i] > mm)
                { 
                    mm = entropy[i];
                    act = i;
                }
            }
            Thread.Sleep(1000);

            return act;
        }
    }
}
