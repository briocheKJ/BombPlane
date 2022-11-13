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
            Random random = new Random();
            int i = random.Next(Store.tot);
            int[][] pos = (int[][])Store.store[i].Clone();
            //AI set plane
            return pos;
        }

        public override int TakeAction(int[][] state, bool play)
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

            if (play) Thread.Sleep(1000);

            return act;
        }
    }
}
