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

        private Label[][] Squares = new Label[2][];
        private int RestTime = 15;
        private bool ActionEnabled = false;
        public RivalView()
        {
           // fatherform = father;
            InitializeComponent();
            Squares[0] = new Label[100];
            Squares[1] = new Label[100];
            for (int i = 0; i < Squares[0].Length; i++)
            {
                Squares[0][i] = new Label();
                Squares[0][i].BackColor = Color.LightGray;
                Squares[0][i].Name = "Squares" + i;
                Squares[0][i].Dock = DockStyle.Fill;
                Squares[0][i].TabIndex = 1;
                Squares[0][i].Text = i.ToString();
                Squares[0][i].Margin = new Padding(0);
                Squares[1][i] = new Label();
                Squares[1][i].BackColor = Color.LightGray;
                Squares[1][i].Name = "Squares" + i;
                Squares[1][i].Dock = DockStyle.Fill;
                Squares[1][i].TabIndex = 1;
                Squares[1][i].Text = i.ToString();
                Squares[1][i].Margin = new Padding(0);
                Squares[1][i].MouseDown += new MouseEventHandler(this.MyTable_MouseDown);
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    this.RivalTable.Controls.Add(Squares[0][i * 10 + j], j, i);
                    this.MyTable.Controls.Add(Squares[1][i * 10 + j], j, i);
                }
            }
            
        }
        //GameForm fatherform;
        //更新视图
        public void initView(int turn, int[][] state)
        {
            if (turn == 0) TurnLabel1.Text = "我方";
            else TurnLabel1.Text = "对方";
            for (int i = 0; i < 100; i++)
            {
                //int PlaneType = CellManager.getInstance().CellAifPlane(i);
                int PlaneType = state[i / 10][i % 10];
                if (PlaneType == 0)
                {
                    Squares[0][i].BackColor = Color.LightGray;
                }
                else if (PlaneType == 1)
                {
                    Squares[0][i].BackColor = Color.Violet;
                }
                else if (PlaneType == 2)
                {
                    Squares[0][i].BackColor = Color.DeepSkyBlue;
                }
            }
        }
        //更新视图，turn轮到谁，xy坐标，clr 0未命中 1飞机 2飞机头
        public void updateView(int turn, bool ChangeColor, int posx = 0, int posy = 0, int clr = 0)
        {
            if (turn == 0) TurnLabel1.Text = "我方";
            else TurnLabel1.Text = "对方";
            if (ChangeColor) DrawColor((turn + 1) % 2, posx * 10 + posy, clr);
        }
        public void updateView(int turn, bool ChangeColor, int num = 0, int clr = 0)
        {
            if (turn == 0) TurnLabel1.Text = "我方";
            else TurnLabel1.Text = "对方";
            if (ChangeColor) DrawColor((turn + 1) % 2, num, clr);
        }
        //禁用按钮
        public void DisableButtons()
        {
            PromptButton.Enabled = false;
            ConcedeButton.Enabled = false;
            ActionEnabled = false;
        }
        //启用按钮
        public void EnableButtons()
        {
            PromptButton.Enabled = true;
            ConcedeButton.Enabled = true;
            ActionEnabled = true;
        }

        private void RivalView_Load(object sender, EventArgs e)
        {

        }

        private void RivalView_FormClosed(object sender, FormClosedEventArgs e)
        {
            //fatherform.Close();
        }
        //画颜色
        private void DrawColor(int turn, int id, int clr)
        {
            switch(clr)
            {
                case 0:
                    Squares[turn][id].BackColor = Color.LightBlue;
                    break;
                case 1:
                    Squares[turn][id].BackColor = Color.Yellow;
                    break;
                case 2:
                    Squares[turn][id].BackColor = Color.Red;
                    break;
            }
        }

        private void MyTable_MouseDown(object sender, MouseEventArgs e)
        {
            int id = int.Parse(((Label)sender).Name.Remove(0, 7));
            if (e.Button == MouseButtons.Left && ActionEnabled &&
                Squares[1][id].BackColor == Color.LightGray) 
            {
                CellManager.getInstance().BombPlane(id);

                actionEvent.Set();
            }
        }

        public void SetActionEvent(AutoResetEvent action)
        {
            actionEvent = action;
        }
        //提示按钮
        private void PromptButton_Click(object sender, EventArgs e)
        {

        }
        //认输按钮
        private void ConcedeButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            CellManager.getInstance().BombPlane(-1);
            actionEvent.Set();
        }
    }
}
