using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BombPlane
{
    public partial class RivalView : Form
    {
        AutoResetEvent actionEvent;

        private Label[] SquaresA;
        private Label[] SquaresB;
        public RivalView()
        {
           // fatherform = father;
            InitializeComponent();
            SquaresA = new Label[100];
            SquaresB = new Label[100];
            for (int i = 0; i < SquaresA.Length; i++)
            {
                SquaresA[i] = new Label();
                SquaresA[i].BackColor = Color.LightGray;
                SquaresA[i].Name = "Squares" + i;
                SquaresA[i].Dock = DockStyle.Fill;
                SquaresA[i].TabIndex = 1;
                SquaresA[i].Text = i.ToString();
                SquaresB[i] = new Label();
                SquaresB[i].BackColor = Color.LightGray;
                SquaresB[i].Name = "Squares" + i;
                SquaresB[i].Dock = DockStyle.Fill;
                SquaresB[i].TabIndex = 1;
                SquaresB[i].Text = i.ToString();
                SquaresB[i].MouseDown += new MouseEventHandler(this.MyTable_MouseDown);
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    this.RivalTable.Controls.Add(SquaresA[i * 10 + j], j, i);
                    this.MyTable.Controls.Add(SquaresB[i * 10 + j], j, i);
                }
            }
            
        }
        //GameForm fatherform;
        //更新视图
        public void updateView()
        {
            if(CellManager.getInstance().Turn() == 1)
            {
                TurnLabel1.Text = "我方";
            }
            else
            {
                TurnLabel1.Text = "对方";
            }
            for (int i = 0; i < SquaresA.Length; i++)
            {
                int PlaneType = CellManager.getInstance().CellAifPlane(i);
                if (PlaneType == 0)
                {
                    SquaresA[i].BackColor = Color.LightGray;
                }
                else if (PlaneType == 1)
                {
                    SquaresA[i].BackColor = Color.Violet;
                }
                else if (PlaneType == 2)
                {
                    SquaresA[i].BackColor = Color.DeepSkyBlue;
                }
            }
        }

        private void RivalView_Load(object sender, EventArgs e)
        {

        }

        private void RivalView_FormClosed(object sender, FormClosedEventArgs e)
        {
            //fatherform.Close();
        }
        
        private void DrawColor(int id, int clr)
        {
            switch(clr)
            {
                case 0:
                    SquaresB[id].BackColor = Color.LightBlue;
                    break;
                case 1:
                    SquaresB[id].BackColor = Color.Yellow;
                    break;
                case 2:
                    SquaresB[id].BackColor = Color.Red;
                    break;
            }
        }

        private void MyTable_MouseDown(object sender, MouseEventArgs e)
        {
            int id = int.Parse(((Label)sender).Name.Remove(0, 7));
            if (e.Button == MouseButtons.Left && CellManager.getInstance().Turn() == 1 &&
                SquaresB[id].BackColor == Color.LightGray) 
            {
                CellManager.getInstance().BombPlane(id);
                //int clr = 1;//得到当前格子是否是飞机格!!
                //DrawColor(id, clr);
                //CellManager.getInstance().SwitchTurn();

                actionEvent.Set();
            }
        }

        public void SetActionEvent(AutoResetEvent action)
        {
            actionEvent = action;
        }
    }
}
