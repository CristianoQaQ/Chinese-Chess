using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    class Shi : ProgramCon
    {
        public bool shi(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)
        {
            if (Matrix[chozenX, chozenY].side == Chess.player.blue)
            {
                if (Y < 3 || Y > 5 || X > 4)
                {
                    return false;
                }
            }
            else
            {
                if (Y < 3 || Y > 5 || X < 14)
                {
                    return false;
                }
            }
            if (Math.Abs(X - chozenX) != 2 || Math.Abs(chozenY - Y) != 1)
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
