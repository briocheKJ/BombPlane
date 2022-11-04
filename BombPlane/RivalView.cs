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
        private Label[] SquaresA;
        private Label[] SquaresB;
        public RivalView(GameForm father)
        {
            fatherform = father;
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
        GameForm fatherform;

        public void updateView()
        {
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
            fatherform.Close();
        }

    }
}
