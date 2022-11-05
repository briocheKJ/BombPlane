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
    public partial class ConnectForm : Form
    {
        int process = 1;
        int bufftime = 10;
        public ConnectForm()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Math.Sqrt(process) <= 10)
            {
                progressBar1.Value = (int)(Math.Sqrt(process) * 10);
                process++;
            }
            else if(bufftime > 0)
            {
                bufftime--;
            }
            else
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}
