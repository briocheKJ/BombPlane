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
        public override int[][] SetPlane(int player)
        {
            int[][] pos;
            //notice UI, wait for return
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
