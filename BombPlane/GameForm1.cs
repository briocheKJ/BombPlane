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
    public partial class GameForm : Form
    {
        private Label[] Squares;
        //private Form fatherForm;
        private AutoResetEvent autoReset;
        //private RivalView RivalForm;
        private int direct = 0;
        public GameForm(AutoResetEvent autoReset)
        {
            InitializeComponent();
            CellManager.getInstance().initailize();
            //this.fatherForm = fatherForm;
            this.autoReset = autoReset;
            //RivalForm = new RivalView();
            Squares = new Label[100];
            for(int i = 0; i < Squares.Length; i++)
            {
                Squares[i] = new Label();
                Squares[i].BackColor = Color.LightGray;
                Squares[i].Name = "Squares" + i;
                Squares[i].Dock = DockStyle.Fill;
                Squares[i].TabIndex = 1;
                Squares[i].Text = i.ToString();
                Squares[i].MouseMove += new MouseEventHandler(this.CellMouseSelect);
                Squares[i].MouseLeave += new EventHandler(this.CellMouseNotSelect);
                Squares[i].MouseDown += new MouseEventHandler(this.CellMouseDown);
            }
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    this.GameTable.Controls.Add(Squares[i * 10 + j], j, i);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //绘制飞机颜色
        Color before;
        private void DrawColor(Label positon, int dir, Color rgb)
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
            if(rgb == before)
            {
                for(int i = 0; i < 10; i++)
                {
                    if (l + npa[i] >= 0 && l + npa[i] < 10 && r + npb[i] >= 0 && r + npb[i] < 10)
                    {
                        if (CellManager.getInstance().CellAifPlane(l + npa[i], r + npb[i]) == 0)
                        {
                            Squares[(l + npa[i]) * 10 + (r + npb[i])].BackColor = Color.LightGray;
                        }
                        else
                        {
                            Squares[(l + npa[i]) * 10 + (r + npb[i])].BackColor = Color.Violet;
                        }
                    }
                        
                }
            }
            else
            {
                for(int i = 0; i < 10; i++)
                {
                    if (l + npa[i] >= 0 && l + npa[i] < 10 && r + npb[i] >= 0 && r + npb[i] < 10)
                    {
                       Squares[(l + npa[i]) * 10 + (r + npb[i])].BackColor = rgb;
                    }
                }
            }
            
        }

        private void CellMouseSelect(object sender, MouseEventArgs e)
        {
            if(CellManager.getInstance().Planeable((Label)sender, direct))
            {
                DrawColor((Label)sender, direct, Color.GreenYellow);
            }
            else
            {
                DrawColor((Label)sender, direct, Color.Red);
            }
            

        }

        private void CellMouseNotSelect(object sender, EventArgs e)
        {
            DrawColor((Label)sender, direct, before);
            //((Label)sender).BackColor = SystemColors.ActiveCaption;
        }

        private void CellMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                DrawColor((Label)sender, direct, before);
                direct++;
                direct %= 4;
            }
            else
            {
                if(CellManager.getInstance().Planeable((Label)sender, direct) && CellManager.getInstance().getPlaneNum() < 3)
                {
                    DrawColor((Label)sender, direct, Color.Violet);
                    CellManager.getInstance().PlacePlane((Label)sender, direct);
                }
                else
                {
                    MessageBox.Show("不可以放置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //返回按钮
        private void label2_Click_1(object sender, EventArgs e)
        {
            //fatherForm.Show();
            this.Close();
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //RivalForm.Close();
            //fatherForm.Show();
            autoReset.Set();
        }
        //撤销按钮
        private void UndoButton_Click(object sender, EventArgs e)
        {
            if(CellManager.getInstance().getPlaneNum() > 0)
            {
                int[] lp = CellManager.getInstance().LastPlane();
                DrawColor(Squares[lp[0] * 10 + lp[1]], lp[2], Color.LightGray);
                CellManager.getInstance().RevokeLastPlane();
            }
            
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        //完成按钮
        private void FinishButton_Click(object sender, EventArgs e)
        {
            if(CellManager.getInstance().getPlaneNum() < 3)
            {
                MessageBox.Show("需要放3个！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //RivalForm.Show();
                //RivalForm.updateView();
                //this.Hide();

                autoReset.Set();
                this.Close();
            }
            
        }
    }
}
