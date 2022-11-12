using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombPlane
{
    static class Store
    {
        public static int[][][] store = new int[70000][][];
        static int[][] pos;
        public static int tot = 0;

        private static void dfs(int k, int cnt)
        {
            if (k == 3)
            {
                pos = new int[10][];
                for (int i = 0; i < 10; i++)
                    pos[i] = new int[10];
            }
            if (k == 0)
            {
                store[tot] = new int[10][];
                for (int j = 0; j < 10; j++)
                    store[tot][j] = new int[10];
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                        store[tot][i][j] = pos[i][j];
                ++tot;
                return;
            }

            int[] npx = new int[10] { -1, 0, 0, 0, 0, 0, 1, 2, 2, 2 };
            int[] npy = new int[10] { 0, -2, -1, 0, 1, 2, 0, -1, 0, 1 };

            Random rand = new Random();
            bool flag = false;
            int x = 0, y = 0, r = 0;
            flag = false;
            while (true)
            {
                if (cnt == 400) return;
                flag = true;
                int t = cnt;
                r = t % 4; t = t / 4;
                x = t % 10; t /= 10;
                y = t % 10;
                cnt++;
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
                if (flag == false) continue;
                for (int j = 0; j < 10; j++)
                {
                    int nx = x + rotate(npx[j], npy[j], r, true);
                    int ny = y + rotate(npx[j], npy[j], r, false);
                    pos[nx][ny] = (j == 0) ? 2 : 1;
                }
                dfs(k - 1, cnt);
                for (int j = 0; j < 10; j++)
                {
                    int nx = x + rotate(npx[j], npy[j], r, true);
                    int ny = y + rotate(npx[j], npy[j], r, false);
                    pos[nx][ny] = 0;
                }
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

        public static void Generate()
        {
            dfs(3,0);
        }
    }
}
