using System;
using System.Windows.Forms;

namespace BlowPlanes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form Helpform = new HelpForm(this);
            this.Hide();
            Helpform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Gameform = new GameForm(this);
            this.Hide();
            Gameform.Show();
        }
    }
}
