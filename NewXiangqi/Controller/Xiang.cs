using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    class Xiang : ProgramCon
    {
        public bool xiang(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)
        {
            if (Matrix[chozenX, chozenY].side ==Chess.player.blue)
            {
                if (X > 8)
                {
                    return false;
                }
            }
            else
            {
                if (X < 10)
                {
                    return false;
                }
            }
            if ((X - chozenX) / 2 * (X - chozenX) / 2 + (chozenY - Y) * (chozenY - Y) != 8)
            {
                return false;
            }
            if (Matrix[(X + chozenX) / 2, (Y + chozenY) / 2].side != Chess.player.blank)
            {
                return false;
            }
            if (Matrix[chozenX, chozenY].side == Matrix[X, Y].side)
            {
                return false;
            }
            Setmove(X, Y, chozenX, chozenY, Matrix);
            return true;
        }
    }
}
