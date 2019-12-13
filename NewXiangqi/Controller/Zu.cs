using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    class Zu : ProgramCon
    {
        public bool zu(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)
        {
            ProgramCon con = new ProgramCon();
            if (X != chozenX && Y != chozenY)
            {
                return false;
            }
            if (Matrix[chozenX, chozenY].side == Chess.player.blue)
            {
                if (chozenX < 10 && X - chozenX != 2)
                {
                    return false;
                }
                if (chozenX > 8)
                {
                    if (X == chozenX && Math.Abs(Y - chozenY) != 1)
                    {
                        return false;
                    }
                    if (Y == chozenY && X - chozenX != 2)
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (chozenX > 8 && chozenX - X != 2)
                {
                    return false;
                }
                if (chozenX < 10)
                {
                    if (X == chozenX && Math.Abs(Y - chozenY) != 1)
                    {
                        return false;
                    }
                    if (Y == chozenY && chozenX - X != 2)
                    {
                        return false;
                    }
                }
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
