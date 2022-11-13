using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombPlane
{
    static class HintSystem
    {
        private static bool[] vis = new bool[100];

        //计算当前状态下，一块机身所属飞机机头的所有可能位置
        public static List<int> CalcHint(int act, int[][] state)
        {
            List<int> result = new List<int>();
            vis = new bool[100];
            for(int i=0; i<Store.tot; i++)
            {
                bool flag = true; //match
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                        if (state[x][y] != -1 && state[x][y] != Store.store[i][x][y])
                        {
                            flag = false;
                            break;
                        }
                    if (!flag) break;
                }

                if (!flag) continue;

                for (int j = 0; j < 3; j++)
                    CheckInPlane(Store.store_code[i][j], act);
            }

            for(int i=0; i<100; i++)
                if (vis[i]) result.Add(i);

            return result;
        }

        private static void CheckInPlane(int plane_code, int act)
        {
            int r = plane_code / 100;
            int x = (plane_code % 100) / 10;
            int y = plane_code % 10;
            int[] npx = new int[10] { -1, 0, 0, 0, 0, 0, 1, 2, 2, 2 };
            int[] npy = new int[10] { 0, -2, -1, 0, 1, 2, 0, -1, 0, 1 };

            bool flag = false;
            for(int i=1; i<10; i++) //排除机头
            {
                int nx = x + rotate(npx[i], npy[i], r, true);
                int ny = y + rotate(npx[i], npy[i], r, false);
                if (act / 10 == nx && act % 10 == ny) flag = true;
            }

            if (flag)
            {
                int nx = x + rotate(npx[0], npy[0], r, true);
                int ny = y + rotate(npx[0], npy[0], r, false);
                vis[nx * 10 + ny] = true;
                //机头位置加入list
            }
        }

        private static int rotate(int x, int y, int r, bool side)
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
    }
}
