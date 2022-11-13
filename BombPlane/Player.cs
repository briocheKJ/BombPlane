using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombPlane
{
    abstract class Player
    {
        abstract public int[][] SetPlane(int player);
        abstract public int TakeAction(int[][] state, bool play);
    }

    class RealPlayer : Player
    {
        private AutoResetEvent selectEvent = new AutoResetEvent(false);
        private AutoResetEvent actionEvent = new AutoResetEvent(false);
        private Control UIControl;
        private GameForm gameForm;
        private RivalView rivalForm;

        public RealPlayer(Control UI, RivalView rival)
        {
            gameForm = new GameForm(selectEvent);
            rivalForm = rival;
            UIControl = UI;
        }
        public override int[][] SetPlane(int player)
        {
            Object pos;

            UIControl.Invoke(new MethodInvoker(delegate { gameForm.Show(); }));

            selectEvent.WaitOne();
            //notice UI, wait for return

            UIControl.Invoke(new MethodInvoker(delegate { gameForm.Close(); }));

            if (CellManager.getInstance().PlaneSubmit() == null) return null;

            pos = CellManager.getInstance().PlaneSubmit().Clone();
            return (int[][])pos;
        }

        public override int TakeAction(int[][] state, bool play)
        {
            int act = 0;

            rivalForm.SetActionEvent(actionEvent);

            UIControl.Invoke(new MethodInvoker(delegate { rivalForm.EnableButtons(); }));
            //Display

            actionEvent.WaitOne();
            //notice UI, wait for return

            UIControl.Invoke(new MethodInvoker(delegate { rivalForm.DisableButtons(); }));

            act = CellManager.getInstance().LastBomb();
            return act;
        }
    }

    class AIPlayer_Random : Player
    {
        public override int[][] SetPlane(int player)
        {
            Random random = new Random();
            int i = random.Next(Store.tot);
            int[][] pos = (int[][])Store.store[i].Clone();
            //AI set plane
            return pos;
        }

        public override int TakeAction(int[][] state, bool play)
        {
            Random rand = new Random();
            int act;

            while (true)
            {
                act = rand.Next(100);
                if (state[act / 10][act % 10] == -1) break;
            }

            if (play) Thread.Sleep(1000);

            return act;
        }
    }
}
