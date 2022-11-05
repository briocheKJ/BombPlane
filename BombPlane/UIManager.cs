using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BombPlane
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
        
        private Cell[] CellsA = new Cell[100];
        private Cell[] CellsB = new Cell[100];
        private int[] PlanA = { 0, -1, -2, -2, -2, 0, 0, 0, 0, +1 };
        private int[] PlanB = { 0, 0, 0, -1, +1, -1, -2, +1, +2, 0 };
        private int PlaneNum = 0;
        private int[][] PlaneCenter = new int[3][] { new int[3] { 0, 0, 0 }, new int[3] { 0, 0, 0 }, new int[3] { 0, 0, 0 } };
        private int[][] PlanePosition = new int[10][];
        private int whichturn = 0;
        private int[] bombpos = new int[100];
        private int bombnum = 0;
        private CellManager() { 
            for(int i = 0; i < 10; i++) {
                PlanePosition[i] = new int[10];
            }
        }
        //初始化
        public void initailize()
        {
            PlaneNum = 0;
            for (int i = 0; i < 100; i++)
            {
                CellsA[i] = new Cell();
            }
        }
        private void transform(out int[] npa, out int[] npb, int dir)
        {
            npa = (int[])PlanA.Clone();
            npb = (int[])PlanB.Clone();
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
        }
        //获得当前放置飞机数量
        public int getPlaneNum()
        {
            return PlaneNum;
        }
        //放置飞机
        public void SetPlane(int posi, int posj, int dir)
        {
            PlaneCenter[PlaneNum][0] = posi;
            PlaneCenter[PlaneNum][1] = posj;
            PlaneCenter[PlaneNum][2] = dir;
            PlaneNum++;
        }
        //放的上一个飞机，用于撤销操作
        public int[] LastPlane()
        {
            return PlaneCenter[PlaneNum - 1];
        }
        //撤销一个飞机
        public void RevokeLastPlane()
        {
            PlaneNum--;
            int l = PlaneCenter[PlaneNum][0], r = PlaneCenter[PlaneNum][1];
            int[] npa;
            int[] npb;
            transform(out npa, out npb, PlaneCenter[PlaneNum][2]);
            for (int i = 0; i < 10; i++)
            {
                CellsA[(l + npa[i]) * 10 + (r + npb[i])].ifPlane = 0;
            }
        }
        //判断当前格子是否有飞机
        public int CellAifPlane(int posi, int posj)
        {
            return CellsA[posi * 10 + posj].ifPlane;
        }
        public int CellAifPlane(int num)
        {
            return CellsA[num].ifPlane;
        }
        //判断当前格子是否有飞机（B)
        public int CellBifPlane(int posi, int posj)
        {
            return CellsB[posi * 10 + posj].ifPlane;
        }
        //判断当前位置是否可放飞机
        public bool Planeable(System.Windows.Forms.Label positon, int dir)
        {
            string name = positon.Name;
            int id = int.Parse(name.Remove(0, 7));
            int l = id / 10, r = id % 10;
            int[] npa;
            int[] npb;
            bool flag = true;
            transform(out npa, out npb, dir);
            for (int i = 0; i < 10; i++)
            {
                if (l + npa[i] < 0 || l + npa[i] > 9 || r + npb[i] < 0 || r + npb[i] > 9 || CellsA[(l + npa[i]) * 10 + (r + npb[i])].ifPlane != 0)
                {
                    flag = false;
                }
            }
            return flag;
        }
        //放置飞机（涂颜色）
        public void PlacePlane(System.Windows.Forms.Label positon, int dir)
        {
            string name = positon.Name;
            int id = int.Parse(name.Remove(0, 7));
            int l = id / 10, r = id % 10;
            int[] npa;
            int[] npb;
            transform(out npa, out npb, dir);
            SetPlane(l, r, dir);
            for (int i = 0; i < 10; i++)
            {
                CellsA[(l + npa[i]) * 10 + (r + npb[i])].ifPlane = (i == 9 ? 2 : 1);
            }
        }
        //提交飞机位置
        public int[][] PlaneSubmit()
        {
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    PlanePosition[i][j] = CellsA[i * 10 + j].ifPlane;
                }
            }
            return PlanePosition;
        }
        //开始游戏后确定哪方先行动
        public void SetTurn(int num)
        {
            whichturn = num;
        }
        //得到当前回合归属：1我方-1对方
        public int Turn()
        {
            return whichturn;
        }
        //交换回合
        public void SwitchTurn()
        {
            whichturn = -whichturn;
        }
        //第num次炸飞机
        public void BombPlane(int num)
        {
            bombpos[bombnum] = num;
            bombnum++;
        }
        //最新一次炸飞机的位置
        public int LastBomb()
        {
            return bombpos[bombnum - 1];
        }
    }
}
