using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlowPlanes
{
    internal class Cell
    {
        //ifBomb判断是否被炸
        private bool ifbomb = false;
        //ifplane 0:未放 1:普通部位 2:飞机头
        private int ifplane = 0;
        public bool ifBomb
        {
            get { return ifbomb; }
            set { ifbomb = value; }
        }
        public int ifPlane 
        {
            get { return ifplane; }
            set { ifplane = value; }
        }

    }
    internal class CellManager
    {
        private static CellManager instance = new CellManager();
        public static CellManager getInstance()
        {
            return instance;
        }
        private CellManager() { }
        private Cell[] CellsA = new Cell[100];
        private Cell[] CellsB = new Cell[100];
        private int[] PlanA = { 0, -1, -2, -2, -2, 0, 0, 0, 0, +1 };
        private int[] PlanB = { 0, 0, 0, -1, +1, -1, -2, +1, +2, 0 };
        public void initailize()
        {
            for(int i = 0; i < 100; i++)
            {
                CellsA[i] = new Cell();
            }
        }
        public int CellifPlane(int posi, int posj)
        {
            return CellsA[posi * 10 + posj].ifPlane;
        }
        public bool Planeable(System.Windows.Forms.Label positon, int dir)
        {
            string name = positon.Name;
            int id = int.Parse(name.Remove(0, 7));
            int l = id / 10, r = id % 10;
            int[] npa = { 0, -1, -2, -2, -2, 0, 0, 0, 0, +1 };
            int[] npb = { 0, 0, 0, -1, +1, -1, -2, +1, +2, 0 };
            bool flag = true;
            for (int i = 0; i < dir; i++)
            {
                int tmp;
                for(int j = 0; j < 10; j++)
                {
                    tmp = npa[j];
                    npa[j] = npb[j];
                    npb[j] = -tmp;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (l + npa[i] < 0 || l + npa[i] > 9 || r + npb[i] < 0 || r + npb[i] > 9 || CellsA[(l + npa[i]) * 10 + (r + npb[i])].ifPlane != 0)
                {
                    flag = false;
                }
            }
            return flag;
        }
        public void PlacePlane(System.Windows.Forms.Label positon, int dir)
        {
            string name = positon.Name;
            int id = int.Parse(name.Remove(0, 7));
            int l = id / 10, r = id % 10;
            int[] npa = { 0, -1, -2, -2, -2, 0, 0, 0, 0, +1 };
            int[] npb = { 0, 0, 0, -1, +1, -1, -2, +1, +2, 0 };
            for (int i = 0; i < dir; i++)
            {
                int tmp;
                for (int j = 0; j < 10; j++)
                {
                    tmp = npa[j];
                    npa[j] = npb[j];
                    npb[j] = -tmp;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                CellsA[(l + npa[i]) * 10 + (r + npb[i])].ifPlane = (i == 0 ? 2 : 1);
            }
        }
    }
}
