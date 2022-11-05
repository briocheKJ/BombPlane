using BombPlane.Properties;
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
    public partial class GameEndForm : Form
    {
        public GameEndForm(bool vic)
        {
            InitializeComponent();
            if(vic == false)
            {
                this.BackgroundImage = ((System.Drawing.Image)Resources.Defeat);
                this.Width = 450;
            }
            
        }
        private void GameEndForm_Load(object sender, EventArgs e)
        {

        }
    }
}
