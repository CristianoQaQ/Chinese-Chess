using System;

namespace Model
{
     public class ProgramMod
    {
        static void Main(string[] args)
        {
           // Console.WriteLine("Hello World!");
        }
        public enum player
        {
            blank,
            red,
            blue,
        };//分为红蓝两方
        public enum chesstype
        {
            blank,
            jiang,
            che,
            ma,
            pao,
            xiang,
            zu,
            shi
        };//分为不同的棋子类型
        public enum chessroad
        {
            can,
            cant
        };//可行与不可行
        public struct chess
        {
            public player side;
            public chesstype type;
            public chessroad road;
        };//自定义红蓝方，棋子类型以及可行路径三个属性
        public struct block
        {
            public chess item;
        };//自定义一个结构用以整合为一个棋子
        block[,] Matrix;//为棋子创建一个自定义的数组类型.
        public block[,] resetground()//给每一个棋子类型赋予属性
        {
            Matrix = new block[19, 9];
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Matrix[i, j].item.side = player.blank;
                    Matrix[i, j].item.type = chesstype.blank;
                };
            }
            Matrix[0, 0].item.side = player.blue;
            Matrix[0, 1].item.side = player.blue;
            Matrix[0, 2].item.side = player.blue;
            Matrix[0, 3].item.side = player.blue;
            Matrix[0, 4].item.side = player.blue;
            Matrix[0, 5].item.side = player.blue;
            Matrix[0, 6].item.side = player.blue;
            Matrix[0, 7].item.side = player.blue;
            Matrix[0, 8].item.side = player.blue;
            Matrix[4, 1].item.side = player.blue;
            Matrix[4, 7].item.side = player.blue;
            Matrix[6, 0].item.side = player.blue;
            Matrix[6, 2].item.side = player.blue;
            Matrix[6, 4].item.side = player.blue;
            Matrix[6, 6].item.side = player.blue;
            Matrix[6, 8].item.side = player.blue;
            Matrix[12, 0].item.side = player.red;
            Matrix[12, 2].item.side = player.red;
            Matrix[12, 4].item.side = player.red;
            Matrix[12, 6].item.side = player.red;
            Matrix[12, 8].item.side = player.red;
            Matrix[14, 1].item.side = player.red;
            Matrix[14, 7].item.side = player.red;
            Matrix[18, 0].item.side = player.red;
            Matrix[18, 1].item.side = player.red;
            Matrix[18, 2].item.side = player.red;
            Matrix[18, 3].item.side = player.red;
            Matrix[18, 4].item.side = player.red;
            Matrix[18, 5].item.side = player.red;
            Matrix[18, 6].item.side = player.red;
            Matrix[18, 7].item.side = player.red;
            Matrix[18, 8].item.side = player.red;

            Matrix[0, 0].item.type = chesstype.che;
            Matrix[0, 1].item.type = chesstype.ma;
            Matrix[0, 2].item.type = chesstype.xiang;
            Matrix[0, 3].item.type = chesstype.shi;
            Matrix[0, 4].item.type = chesstype.jiang;
            Matrix[0, 5].item.type = chesstype.shi;
            Matrix[0, 6].item.type = chesstype.xiang;
            Matrix[0, 7].item.type = chesstype.ma;
            Matrix[0, 8].item.type = chesstype.che;
            Matrix[4, 1].item.type = chesstype.pao;
            Matrix[4, 7].item.type = chesstype.pao;
            Matrix[6, 0].item.type = chesstype.zu;
            Matrix[6, 2].item.type = chesstype.zu;
            Matrix[6, 4].item.type = chesstype.zu;
            Matrix[6, 6].item.type = chesstype.zu;
            Matrix[6, 8].item.type = chesstype.zu;
            Matrix[12, 0].item.type = chesstype.zu;
            Matrix[12, 2].item.type = chesstype.zu;
            Matrix[12, 4].item.type = chesstype.zu;
            Matrix[12, 6].item.type = chesstype.zu;
            Matrix[12, 8].item.type = chesstype.zu;
            Matrix[14, 1].item.type = chesstype.pao;
            Matrix[14, 7].item.type = chesstype.pao;
            Matrix[18, 0].item.type = chesstype.che;
            Matrix[18, 1].item.type = chesstype.ma;
            Matrix[18, 2].item.type = chesstype.xiang;
            Matrix[18, 3].item.type = chesstype.shi;
            Matrix[18, 4].item.type = chesstype.jiang;
            Matrix[18, 5].item.type = chesstype.shi;
            Matrix[18, 6].item.type = chesstype.xiang;
            Matrix[18, 7].item.type = chesstype.ma;
            Matrix[18, 8].item.type = chesstype.che;
            return Matrix;
        }
        public string[,] Piece(block[,]Matrix)//把棋子放进棋盘中
        {
            string[,] board = DrawingBoard();
            string[,] layout = board;
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Matrix[i, j].item.side == player.red)
                    {

                        if (Matrix[i, j].item.type == chesstype.che)
                        {
                            layout[i, j] = "車";
                        }
                        else if (Matrix[i, j].item.type == chesstype.ma)
                        {
                            layout[i, j] = "马";
                        }
                        else if (Matrix[i, j].item.type == chesstype.xiang)
                        {
                            layout[i, j] = "象";
                        }
                        else if (Matrix[i, j].item.type == chesstype.shi)
                        {
                            layout[i, j] = "仕";
                        }
                        else if (Matrix[i, j].item.type == chesstype.jiang)
                        {
                            layout[i, j] = "帅";
                        }
                        else if (Matrix[i, j].item.type == chesstype.pao)
                        {
                            layout[i, j] = "炮";
                        }
                        else if (Matrix[i, j].item.type == chesstype.zu)
                        {
                            layout[i, j] = "兵";
                        }

                    }
                    if (Matrix[i, j].item.side == player.blue)
                    {
                        if (Matrix[i, j].item.type == chesstype.che)
                        {
                            layout[i, j] = "车";
                        }
                        else if (Matrix[i, j].item.type == chesstype.ma)
                        {
                            layout[i, j] = "马";
                        }
                        else if (Matrix[i, j].item.type == chesstype.xiang)
                        {
                            layout[i, j] = "相";
                        }
                        else if (Matrix[i, j].item.type == chesstype.shi)
                        {
                            layout[i, j] = "士";
                        }
                        else if (Matrix[i, j].item.type == chesstype.jiang)
                        {
                            layout[i, j] = "将";
                        }
                        else if (Matrix[i, j].item.type == chesstype.pao)
                        {
                            layout[i, j] = "砲";
                        }
                        else if (Matrix[i, j].item.type == chesstype.zu)
                        {
                            layout[i, j] = "卒";
                        }

                    }
                }
            }
            return layout;
        }
        public static string[,] DrawingBoard()//棋盘模型
        {
            string[,] Board = new string[19, 9];
            Console.Clear();
            Board[0, 0] = "┏-";
            Board[18, 0] = "┗-";
            Board[0, 8] = "┓";
            Board[18, 8] = "┛";
            for (int i = 1; i < 18; i++)
            {
                if (i % 2 == 0)
                {
                    Board[i, 0] = "┣-";
                    Board[i, 8] = "┫ ";
                }
                else
                {
                    Board[i, 0] = "┃ ";
                    Board[i, 8] = "┃ ";
                }
            }
            for (int j = 1; j < 8; j++)
            {
                Board[0, j] = "┳-";
                Board[10, j] = "┳-";
                Board[8, j] = "┻-";
                Board[18, j] = "┻-";
            }

            for (int k = 1; k < 8; k++)
            {
                Board[1, k] = "┃ ";
                Board[2, k] = "╋-";
                Board[3, k] = "┃ ";
                Board[4, k] = "╋-";
                Board[5, k] = "┃ ";
                Board[6, k] = "╋-";
                Board[7, k] = "┃ ";
                Board[9, k] = "  ";
                Board[11, k] = "┃ ";
                Board[12, k] = "╋-";
                Board[13, k] = "┃ ";
                Board[14, k] = "╋-";
                Board[15, k] = "┃ ";
                Board[16, k] = "╋-";
                Board[17, k] = "┃ ";
            }
            Board[1, 3] = "┃";
            Board[3, 3] = "┃";
            Board[15, 3] = "┃";
            Board[17, 3] = "┃";
            Board[9, 1] = "楚";
            Board[9, 2] = "河";
            Board[9, 6] = "汉";
            Board[9, 7] = "界";
            Board[1, 4] = "╲┃╱";
            Board[3, 4] = "╱┃╲";
            Board[15, 4] = "╲┃╱";
            Board[17, 4] = "╱┃╲";
            return Board;
        }
       
        
        
        public block [,] road(int chozenX, int chozenY, block [,] Matrix)//棋盘的可行路径
        {
            block[,] trans = new block[19, 9];
            block[,] road = new block[19, 9];
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    road[i, j].item.road = chessroad.cant;
                }
            }
            bool cr ;
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i % 2 == 0)
                    {
                        trans[i, j].item = Matrix[i, j].item;
                        trans[chozenX, chozenY].item = Matrix[chozenX, chozenY].item;
                        cr = movechess(i, j, chozenX, chozenY,Matrix);
                        if (cr == true)
                        {
                            road[i, j].item.road = chessroad.can;
                        }
                        Matrix[i, j].item = trans[i, j].item;
                        Matrix[chozenX, chozenY].item = trans[chozenX, chozenY].item;
                    }
                }
            }
            return road;
        }
        public bool movechess(int X, int Y, int chozenX, int chozenY, block[,] Matrix)//每种类型棋子的移动规则
        {
            int i, j, k, n;
            switch (Matrix[chozenX, chozenY].item.type)
            {
                case chesstype.che:
                    if (chozenX == X)
                    {
                        i = chozenY < Y ? chozenY : Y;//如果chozenY<Y为ture 返回chozenY 否则Y；
                        j = chozenY > Y ? chozenY : Y;
                        for (k = i + 1; k < j; k++)
                        {
                            if (Matrix[X, k].item.side != player.blank)
                            {
                                return false;
                            }
                        }
                    }
                    if (chozenY == Y)
                    {
                        i = chozenX < X ? chozenX : X;
                        j = chozenX > X ? chozenX : X;
                        for (k = i + 1; k < j; k++)
                        {
                            if (Matrix[k, Y].item.side != player.blank)
                            {
                                return false;
                            }
                        }
                    }
                    if (chozenX != X && chozenY != Y)
                    {
                        return false;
                    }
                    if (Matrix[chozenX, chozenY].item.side == Matrix[X, Y].item.side)
                    {
                        return false;
                    }
                    setmove(X, Y, chozenX, chozenY, Matrix);
                    return true;
                case ProgramMod.chesstype.jiang:
                    if (chozenX == X)
                    {
                        i = chozenY < Y ? chozenY : Y;
                        j = chozenY > Y ? chozenY : Y;
                        for (k = i + 1; k < j; k++)
                        {
                            if (Matrix[X, k].item.side != player.blank)
                            {
                                return false;
                            }
                        }
                    }
                    if (Matrix[X, Y].item.type == chesstype.jiang && chozenY == Y)
                    {
                        i = chozenX < X ? chozenX : X;
                        j = chozenX > X ? chozenX : X;
                        for (k = i + 1; k < j; k++)
                        {
                            if (Matrix[k, Y].item.side != player.blank)
                            {
                                return false;
                            }
                        }
                        if (Matrix[chozenX, chozenY].item.side == Matrix[X, Y].item.side)
                        {
                            return false;
                        }
                        setmove(X, Y, chozenX, chozenY, Matrix);
                        return true;
                    }
                    if (Matrix[chozenX, chozenY].item.side == player.blue)
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
                    if (Matrix[chozenX, chozenY].item.side == Matrix[X, Y].item.side)
                    {
                        return false;
                    }
                    setmove(X, Y, chozenX, chozenY, Matrix);
                    return true;
                case ProgramMod.chesstype.ma:
                    if (Math.Abs(chozenX / 2 - X / 2) == 1 && Math.Abs(chozenY - Y) == 2)//Math.Abs 返回指定数的绝对值
                    {
                        if (Matrix[chozenX, chozenY + (Y - chozenY) / Math.Abs(Y - chozenY)].item.side != player.blank)
                        {
                            return false;
                        }
                    }
                    else if (Math.Abs(chozenX / 2 - X / 2) == 2 && Math.Abs(chozenY - Y) == 1)
                    {
                        if (Matrix[chozenX + (X - chozenX) / Math.Abs(X - chozenX) * 2, chozenY].item.side != player.blank)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    if (Matrix[chozenX, chozenY].item.side == Matrix[X, Y].item.side)
                    {
                        return false;
                    }
                    setmove(X, Y, chozenX, chozenY, Matrix);
                    return true;
                case ProgramMod.chesstype.pao:
                    if (chozenX == X)
                    {
                        i = chozenY < Y ? chozenY : Y;
                        j = chozenY > Y ? chozenY : Y;
                        n = 0;
                        for (k = i + 1; k < j; k++)
                        {
                            if (Matrix[X, k].item.side != player.blank)
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
                            if (Matrix[k, Y].item.side != player.blank)
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
                    if (n == 0 && Matrix[X, Y].item.side != player.blank)
                    {
                        return false;
                    }
                    if (n == 1 && Matrix[X, Y].item.side == player.blank)
                    {
                        return false;
                    }
                    if (Matrix[chozenX, chozenY].item.side == Matrix[X, Y].item.side)
                    {
                        return false;
                    }
                    setmove(X, Y, chozenX, chozenY, Matrix);
                    return true;
                case chesstype.shi:
                    if (Matrix[chozenX, chozenY].item.side == player.blue)
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
                    if (Matrix[chozenX, chozenY].item.side == Matrix[X, Y].item.side)
                    {
                        return false;
                    }
                    setmove(X, Y, chozenX, chozenY, Matrix);
                    return true;
                case chesstype.xiang:
                    if (Matrix[chozenX, chozenY].item.side == player.blue)
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
                    if (Matrix[(X + chozenX) / 2, (Y + chozenY) / 2].item.side != player.blank)
                    {
                        return false;
                    }
                    if (Matrix[chozenX, chozenY].item.side == Matrix[X, Y].item.side)
                    {
                        return false;
                    }
                    setmove(X, Y, chozenX, chozenY, Matrix);
                    return true;
                case chesstype.zu:
                    if (X != chozenX && Y != chozenY)
                    {
                        return false;
                    }
                    if (Matrix[chozenX, chozenY].item.side == player.blue)
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
                    if (Matrix[chozenX, chozenY].item.side == Matrix[X, Y].item.side)
                    {
                        return false;
                    }
                    setmove(X, Y, chozenX, chozenY, Matrix);
                    return true;
            }
            return false;
        }
        public void setmove(int X, int Y, int chozenX, int chozenY, block[,] Matrix)//通用的移动规则
        {
            Matrix[X, Y].item = Matrix[chozenX, chozenY].item;
            Matrix[chozenX, chozenY].item.side = player.blank;
            Matrix[chozenX, chozenY].item.type = chesstype.blank;
        }
    }
}
