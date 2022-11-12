using System;
using System.Windows.Forms;

namespace BombPlane
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();

            Store.Generate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //联机对战按钮
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            RivalView r = new RivalView(this);
            Player p0 = new RealPlayer(this, r);
            Game game = new Game(this, r, 1, p0);

            Thread thread = new Thread(new ThreadStart(game.Play));
            thread.Start();
        }
        //本地对战按钮
        private void button2_Click(object sender, EventArgs e)
        {
            TopPanel.Visible = false;
            LocalPanel.Visible = true;
        }
        //帮助按钮
        private void button3_Click(object sender, EventArgs e)
        {
            Form Helpform = new HelpForm(this);
            this.Hide();
            Helpform.Show();
        }
        //退出按钮
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //人机模式按钮
        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            RivalView r = new RivalView(this);
            Player p0 = new RealPlayer(this, r);
            Player p1 = new AIPlayer_Entropy();
            Game game = new Game(this, r, 0, p0, p1);

            Thread thread = new Thread(new ThreadStart(game.Play));
            thread.Start();
        }
        //看海模式按钮
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();

            RivalView r = new RivalView(this);
            Player p0 = new AIPlayer_Entropy();
            Player p1 = new AIPlayer_Entropy();
            Game game = new Game(this, r, 0, p0, p1);

            Thread thread = new Thread(new ThreadStart(game.Play));
            thread.Start();
        }
        //本地模式返回上级菜单
        private void button6_Click(object sender, EventArgs e)
        {
            LocalPanel.Visible = false;
            TopPanel.Visible = true;
        }
        //AI效果测试
        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();

            AITestForm testForm = new AITestForm(this);
            testForm.Show();
            testForm.BeginTest();
        }
    }
}
