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
    public partial class HelpForm : Form
    {
        public HelpForm(Form fatherForm)
        {
            InitializeComponent();
            this.fatherForm = fatherForm;
        }

        private void HelpPage_Load(object sender, EventArgs e)
        {

        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            fatherForm.Show();
        }
        Form fatherForm;

        private void HelpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            fatherForm.Show();
        }
    }
}
