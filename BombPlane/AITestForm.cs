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
    public partial class AITestForm : Form
    {
        private StartForm fatherForm;

        private int test_cases = 100;
        private int test_progress = 0;
        private int wins = 0;
        private double sum_step = 0;
        private double expect_step = 0;
        private int max_step = 0;
        public AITestForm(StartForm fatherForm)
        {
            this.fatherForm = fatherForm;
            InitializeComponent();
        }

        public void BeginTest()
        {
            Thread thread = new Thread(new ThreadStart(Test));
            thread.Start();
        }

        private void Test()
        {
            Player player0 = new AIPlayer_Entropy();
            Player player1 = new AIPlayer_Random();

            for (int i = 0; i < test_cases; i++)
            {
                RivalView r = new RivalView(fatherForm);
                Game game = new Game(fatherForm, r, 0, player0, player1);
                game.SetTest(this);

                Thread thread = new Thread(new ThreadStart(game.Test));
                thread.Start();
                thread.Join();
            }

            this.Invoke(new MethodInvoker(() =>
            {
                ReturnBtn.Enabled = true;
            }));
        }

        public void Update(int win, int step)
        {
            test_progress++;
            wins += win;
            sum_step += step;
            expect_step = sum_step / (double)(test_progress);
            if (step > max_step) max_step = step;

            this.Invoke(new MethodInvoker(() =>
            {
                TestProgressLbl.Text = "已进行局数：" + test_progress + "/" + test_cases;
                WinLbl.Text = "我方获胜次数：" + wins + "/" + test_progress;
                ExpectStepLbl.Text = "期望步数：" + expect_step;
                MaxStepLbl.Text = "最大步数：" + max_step;
            }));
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            fatherForm.Show();
        }
    }
}
