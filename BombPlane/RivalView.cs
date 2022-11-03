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
        private Label[] Squares;
        public RivalView(GameForm father)
        {
            fatherform = father;
            InitializeComponent();
            Squares = new Label[100];
            for (int i = 0; i < Squares.Length; i++)
            {
                Squares[i] = new Label();
                Squares[i].BackColor = Color.LightGray;
                Squares[i].Name = "Squares" + i;
                Squares[i].Dock = DockStyle.Fill;
                Squares[i].TabIndex = 1;
                Squares[i].Text = i.ToString();
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    this.ViewTable.Controls.Add(Squares[i * 10 + j], j, i);
                }
            }
            
        }
        GameForm fatherform;

        private void RivalView_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
        public void updateView()
        {
            for (int i = 0; i < Squares.Length; i++)
            {
                int PlaneType = CellManager.getInstance().CellAifPlane(i);
                if (PlaneType == 0)
                {
                    Squares[i].BackColor = Color.LightGray;
                }
                else if (PlaneType == 1)
                {
                    Squares[i].BackColor = Color.Violet;
                }
                else if (PlaneType == 2)
                {
                    Squares[i].BackColor = Color.DeepSkyBlue;
                }
            }
        }

        private void RivalView_Load(object sender, EventArgs e)
        {

        }
    }
}
