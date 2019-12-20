using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    class Ma
    {
        public bool ma(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)
        {
            ProgramCon con = new ProgramCon();
            if (Math.Abs(chozenX  - X ) == 1 && Math.Abs(chozenY - Y) == 2)//Math.Abs 返回指定数的绝对值
            {
                if (Matrix[chozenX, chozenY + (Y - chozenY) / Math.Abs(Y - chozenY)].side != Chess.player.blank)
                {
                    return false;
                }
            }
            else if (Math.Abs(chozenX  - X ) == 2 && Math.Abs(chozenY - Y) == 1)
            {
                if (Matrix[chozenX + (X - chozenX) / Math.Abs(X - chozenX) , chozenY].side != Chess.player.blank)
                {
                    return false;
                }
            }
            else
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
