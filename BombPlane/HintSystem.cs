using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombPlane
{
    static class HintSystem
    {
        //计算当前状态下，一块机身所属飞机机头的所有可能位置
        public static List<int> CalcHint(int act, int[][] state)
        {
            List<int> result = new List<int>();
            bool[] vis = new bool[100];
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
                    if (InPlane(Store.store_code[i][j], act))
                        vis[Store.store_code[i][j] % 100] = true;
            }

            for(int i=0; i<100; i++)
                if (vis[i]) result.Add(i);

            return result;
        }

        private static bool InPlane(int plane_code, int act)
        {
            int r = plane_code / 100;
            int x = (plane_code % 100) / 10;
            int y = plane_code % 10;
            int[] npx = new int[10] { -1, 0, 0, 0, 0, 0, 1, 2, 2, 2 };
            int[] npy = new int[10] { 0, -2, -1, 0, 1, 2, 0, -1, 0, 1 };

            for(int i=0; i<10; i++)
            {
                int nx = x + rotate(npx[i], npy[i], r, true);
                int ny = y + rotate(npx[i], npy[i], r, false);
                if (act / 10 == nx && act % 10 == ny) return true;
            }
            return false;
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
