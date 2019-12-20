using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    class Shi
    {
        public bool shi(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)
        {
            ProgramCon con = new ProgramCon();
            if (Matrix[chozenX, chozenY].side == Chess.player.blue)
            {
                if (Y < 3 || Y > 5 || X > 2)
                {
                    return false;
                }
            }
            else
            {
                if (Y < 3 || Y > 5 || X < 7)
                {
                    return false;
                }
            }
            if (Math.Abs(X - chozenX) != 1 || Math.Abs(chozenY - Y) != 1)
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
