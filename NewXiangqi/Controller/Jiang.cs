using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    class Jiang 
    {
        public bool jiang(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)
        {
            ProgramCon con = new ProgramCon();
            int i, j, k;
            if (chozenX == X)
            {
                i = chozenY < Y ? chozenY : Y;
                j = chozenY > Y ? chozenY : Y;
                for (k = i + 1; k < j; k++)
                {
                    if (Matrix[X, k].side != Chess.player.blank)
                    {
                        return false;
                    }
                }
            }
            if (Matrix[X, Y].type == Chess.chesstype.jiang && chozenY == Y)
            {
                i = chozenX < X ? chozenX : X;
                j = chozenX > X ? chozenX : X;
                for (k = i + 1; k < j; k++)
                {
                    if (Matrix[k, Y].side != Chess.player.blank)
                    {
                        return false;
                    }
                }
                if (Matrix[chozenX, chozenY].side == Matrix[X, Y].side)
                {
                    return false;
                }
                con.Setmove(X, Y, chozenX, chozenY, Matrix);
                return true;
            }
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
            if ((chozenX / 2 - X / 2) * (chozenX / 2 - X / 2) + (chozenY - Y) * (chozenY - Y) != 1)
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
