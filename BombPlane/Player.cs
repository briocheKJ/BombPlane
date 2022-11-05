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
        abstract public int TakeAction(int[][] state);
    }

    class RealPlayer : Player
    {
        private AutoResetEvent selectEvent = new AutoResetEvent(false);
        private Control UIControl;
        private GameForm gameForm;

        public RealPlayer(Control UI)
        {
            gameForm = new GameForm(selectEvent);
            UIControl = UI;
        }
        public override int[][] SetPlane(int player)
        {
            int[][] pos;

            UIControl.Invoke(new MethodInvoker(delegate { gameForm.Show(); }));

            selectEvent.WaitOne();
            //notice UI, wait for return

            pos = (int[][])CellManager.getInstance().PlaneSubmit().Clone();
            return pos;
        }

        public override int TakeAction(int[][] state)
        {
            int act = 0;
            //notice UI, wait for return
            return act;
        }
    }

    class AIPlayer_Random : Player
    {
        public override int[][] SetPlane(int player)
        {
            int[][] pos;
            //AI set plane
            pos = (int[][])CellManager.getInstance().PlaneSubmit().Clone();
            return pos;
        }
        public override int TakeAction(int[][] state)
        {
            Random rand = new Random();
            int act;

            while (true)
            {
                act = rand.Next(100);
                if (state[act / 10][act % 10] == -1) break;
            }

            return act;
        }
    }
}
