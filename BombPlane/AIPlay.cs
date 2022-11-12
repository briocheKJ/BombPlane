using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombPlane
{
    internal class AIPlay
    {
        int[][] nowmap = new int[10][];
        int[][] Prob = new int[10][];
        private int[] PlanA = { 0, -1, -2, -2, -2, 0, 0, 0, 0, +1 };
        private int[] PlanB = { 0, 0, 0, -1, +1, -1, -2, +1, +2, 0 };
        AIPlay()
        {
            for(int i = 0; i < 10; i++)
            {
                nowmap[i] = new int[10];
                Prob[i] = new int[10] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            }
        }
        void getmap(int[][] tmpmap)
        {
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    nowmap[i][j] = tmpmap[i][j];
                    Prob[i][j] = 0;
                }
            }
        }
        int setbomb()
        {
            for( int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if(nowmap[i][j] == 1)
                    {
                        for(int k = 0; k < 10; k++)
                        {
                            if()
                        }
                    }
                }
            }
        }
    }
}
