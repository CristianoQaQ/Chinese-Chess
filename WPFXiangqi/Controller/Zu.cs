using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    class Zu
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
                if (chozenX < 5 && X - chozenX != 1)
                {
                    return false;
                }
                if (chozenX > 4)
                {
                    if (X == chozenX && Math.Abs(Y - chozenY) != 1)
                    {
                        return false;
                    }
                    if (Y == chozenY && X - chozenX != 1)
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (chozenX > 4 && chozenX - X != 1)
                {
                    return false;
                }
                if (chozenX < 5)
                {
                    if (X == chozenX && Math.Abs(Y - chozenY) != 1)
                    {
                        return false;
                    }
                    if (Y == chozenY && chozenX - X != 1)
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
