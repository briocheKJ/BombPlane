using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BombPlane
{
    public partial class WaitForm : Form
    {
        public WaitForm(string str)
        {
            InitializeComponent();
            this.WaitText.Text = str;
        }
    }
}
