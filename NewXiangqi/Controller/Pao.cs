using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    class Pao 
    {
        public bool pao(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)
        {
            ProgramCon con = new ProgramCon();
            int i, j, k,n;
            if (chozenX == X)
            {
                i = chozenY < Y ? chozenY : Y;
                j = chozenY > Y ? chozenY : Y;
                n = 0;
                for (k = i + 1; k < j; k++)
                {
                    if (Matrix[X, k].side != Chess.player.blank)
                    {
                        n++;
                    }
                }
                if (n > 1)
                {
                    return false;
                }
            }
            else if (chozenY == Y)
            {
                i = chozenX < X ? chozenX : X;
                j = chozenX > X ? chozenX : X;
                n = 0;
                for (k = i + 1; k < j; k++)
                {
                    if (Matrix[k, Y].side != Chess.player.blank)
                    {
                        n++;
                    }
                }
                if (n > 1)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            if (n == 0 && Matrix[X, Y].side != Chess.player.blank)
            {
                return false;
            }
            if (n == 1 && Matrix[X, Y].side == Chess.player.blank)
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
