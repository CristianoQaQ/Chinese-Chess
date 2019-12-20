using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    class Xiang
    {
        public bool xiang(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)
        {
            ProgramCon con = new ProgramCon();
            if (Matrix[chozenX, chozenY].side == Chess.player.blue)
            {
                if (X > 4)
                {
                    return false;
                }
            }
            else
            {
                if (X < 5)
                {
                    return false;
                }
            }
            if ((X - chozenX)  * (X - chozenX)  + (chozenY - Y) * (chozenY - Y) != 8)
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
            con.Setmove(X, Y, chozenX, chozenY, Matrix);
            return true;
        }
    }
}
