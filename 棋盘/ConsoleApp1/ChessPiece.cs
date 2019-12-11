using System;
using System.Collections.Generic;
using System.Text;
namespace ConsoleApp1
{
    class ChessPiece
    {
        //枚举，给各个类型赋值。
        enum player
        {
            blank,
            red,
            blue,
        };//分为红蓝两方
        enum chesstype
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
        enum chessroad
        {
            can,
            cant
        };
        struct chess
        {
            public player side;
            public chesstype type;
            public chessroad road;
        };//自定义红蓝方和棋子类型两个结构
        struct block
        {
            public chess item;
        };//自定义一个结构用以整合为一个棋子
        block[,] Matrix;//为棋子创建一个自定义的数组类型.
        public void resetground()//给每一个棋子类型赋予属性
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
        }
        public int turn = 0;
        public bool Turn(int X, int Y, int chozenX, int chozenY)//在己方回合中不能选择对方棋子
        {
            if (turn == 0)
            {
                if (Matrix[chozenX, chozenY].item.side != player.red)
                {
                    return false;
                }
                else
                {
                    bool check = movechess(X, Y, chozenX, chozenY);
                    if (check == true)
                    {
                        turn = 1;
                        return true;
                    }
                    else return false;
                }
            }
            else if (turn == 1)
            {
                if (Matrix[chozenX, chozenY].item.side != player.blue)
                {
                    return false;
                }
                else
                {
                    bool check = movechess(X, Y, chozenX, chozenY);
                    if (check == true)
                    {
                        turn = 0;
                        return true;
                    }
                    else return false;
                }
            }
            else return false;
        }
        public bool movechess(int X, int Y,int chozenX, int chozenY)//每种类型棋子的移动规则
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
                    if(chozenX != X&& chozenY != Y)
                    {
                        return false;
                    }
                    if (Matrix[chozenX, chozenY].item.side ==  Matrix[X, Y].item.side )
                    {
                        return false;
                    }
                    setmove(X, Y, chozenX, chozenY);
                    return true;
                case chesstype.jiang:
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
                    if (Matrix[X,Y].item.type == chesstype.jiang && chozenY == Y)
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
                        setmove(X, Y, chozenX, chozenY);
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
                    if ((chozenX/2 - X/2) * (chozenX/2 - X/2) + (chozenY - Y) * (chozenY - Y) != 1)
                    {
                        return false;
                    }
                    if (Matrix[chozenX, chozenY].item.side == Matrix[X, Y].item.side)
                    {
                        return false;
                    }
                    setmove(X, Y, chozenX, chozenY);
                    return true;
                case chesstype.ma:
                    if (Math.Abs(chozenX / 2 - X / 2) == 1 && Math.Abs(chozenY - Y) == 2)//Math.Abs 返回指定数的绝对值
                    {
                        if (Matrix[chozenX, chozenY + (Y - chozenY) / Math.Abs(Y - chozenY)].item.side != player.blank)
                        {
                            return false;
                        }
                    }
                    else if (Math.Abs(chozenX / 2 - X / 2) == 2 && Math.Abs(chozenY - Y) == 1)
                    {
                        if (Matrix[chozenX + (X  - chozenX ) / Math.Abs(X  - chozenX )*2, chozenY].item.side != player.blank)
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
                    setmove(X, Y, chozenX, chozenY);
                    return true;
                case chesstype.pao:
                    if (chozenX == X)
                    {
                        i = chozenY < Y ? chozenY : Y;
                        j = chozenY > Y ? chozenY : Y;
                        n = 0;
                        for (k = i + 1; k < j; k++)
                        {
                            if (Matrix[X,k].item.side != player.blank)
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
                            if (Matrix[k,Y].item.side != player.blank)
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
                    if (n == 0 && Matrix[X,Y].item.side != player.blank)
                    {
                        return false;
                    }
                    if (n == 1 && Matrix[X,Y].item.side == player.blank)
                    {
                        return false;
                    }
                    if (Matrix[chozenX, chozenY].item.side == Matrix[X, Y].item.side)
                    {
                        return false;
                    }
                    setmove(X, Y, chozenX, chozenY);
                    return true;
                case chesstype.shi:
                    if (Matrix[chozenX,chozenY].item.side == player.blue)
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
                    setmove(X, Y, chozenX, chozenY);
                    return true;
                case chesstype.xiang:
                    if (Matrix[chozenX,chozenY].item.side == player.blue)
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
                    if ((X - chozenX)/2 * (X - chozenX)/2 + (chozenY - Y) * (chozenY - Y) != 8)
                    {
                        return false;
                    }
                    if (Matrix[(X + chozenX) / 2,(Y + chozenY) / 2].item.side != player.blank)
                    {
                        return false;
                    }
                    if (Matrix[chozenX, chozenY].item.side == Matrix[X, Y].item.side)
                    {
                        return false;
                    }
                    setmove(X, Y, chozenX, chozenY);
                    return true;
                case chesstype.zu:
                    if (X != chozenX && Y != chozenY)
                    {
                        return false;
                    }
                    if (Matrix[chozenX,chozenY].item.side == player.blue)
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
                    setmove(X, Y, chozenX, chozenY);
                    return true;
            }
            return false;
        }
        public void setmove(int X, int Y, int chozenX, int chozenY)//通用的移动规则
        {
            Matrix[X, Y].item = Matrix[chozenX, chozenY].item;
            Matrix[chozenX, chozenY].item.side = player.blank;
            Matrix[chozenX, chozenY].item.type = chesstype.blank;
        }
        public bool Result()//胜利条件
        {
            int n = 0;
            bool result = true;
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Matrix[i, j].item.type == chesstype.jiang)
                    {
                        n++;
                    }
                }
            }
            if (n == 2)
            {
                return result;
            }
            else
            {
                result = false;
                return  result;
            }
        }
        public string[,] Piece()//把棋子放进棋盘中
        {
            string[,] board = ChessBoard.DrawingBoard();
            string [,]layout = board;
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if(Matrix[i,j].item.side == player.red)
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
                        else if(Matrix[i, j].item.type == chesstype.zu)
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
        public int Checkpiece(int chozenX, int chozenY)//检测选中的是否棋子
        {
            if (Matrix[chozenX, chozenY].item.type == chesstype.blank)
            {
                return 0;
            }
            else if(turn == 0)
                {
                if (Matrix[chozenX, chozenY].item.side != player.red)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
                }
            else if (turn == 1)
            {
                if (Matrix[chozenX, chozenY].item.side != player.blue)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            return 0;
        }
        public void display()
        {
            string[,] Board = Piece();

            for (int i = 0; i <= 18; i++)//把棋盘和辅助坐标打印出来
            {
                Console.BackgroundColor = ConsoleColor.Black;
                if (i % 2 == 0)
                {
                    Console.Write("    " + i / 2 + "    ");
                }
                else
                {
                    Console.Write("         ");

                }
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                for (int j = 0; j < 9; j++)
                {
                    if(Matrix[i,j].item.side == player.blue)
                    {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(Board[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (Matrix[i, j].item.side == player.red)
                    { 
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(Board[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    else {Console.Write(Board[i, j]);}
                }
                Console.Write("\n");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("    X/Y   ");
            for (int j = 0; j < 9; j++)
            {
                Console.Write(j + " ");
            }
        }
        //============================================================================
        block[,] trans;
        block[,] road;
        public void setroad()
        {
            road = new block[19, 9];
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    road[i, j].item.road = chessroad.cant;
                }
            }
        }
        public void printfroad(int chozenX, int chozenY)
        {
            trans = new block[19, 9];
            setroad();
            bool cr ;
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i % 2 == 0)
                    {
                        trans[i, j].item = Matrix[i, j].item;
                        trans[chozenX, chozenY].item = Matrix[chozenX, chozenY].item;
                        cr = movechess(i, j, chozenX, chozenY);
                        if (cr == true)
                        { 
                            road[i, j].item.road = chessroad.can;
                        }
                        Matrix[i, j].item = trans[i, j].item;
                        Matrix[chozenX, chozenY].item = trans[chozenX, chozenY].item;
                    }
                }
            }
            Console.ReadLine();
            string[,] Board = Piece();

            for (int i = 0; i <= 18; i++)//把棋盘和辅助坐标打印出来
            {
                Console.BackgroundColor = ConsoleColor.Black;
                if (i % 2 == 0)
                {
                    Console.Write("    " + i / 2 + "    ");
                }
                else
                {
                    Console.Write("         ");

                }
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                for (int j = 0; j < 9; j++)
                {
                    if (Matrix[i, j].item.side == player.blue)
                    {
                        if (road[i, j].item.road == chessroad.can)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(Board[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            road[i, j].item.road = chessroad.cant;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(Board[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                        }
                    }
                    else if (Matrix[i, j].item.side == player.red)
                    {
                        if (road[i, j].item.road == chessroad.can)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(Board[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            road[i, j].item.road = chessroad.cant;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(Board[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                        }
                    }
                    else
                    {
                        if (road[i, j].item.road == chessroad.can)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(Board[i, j]);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            road[i, j].item.road = chessroad.cant;
                        }
                        else
                        {
                            Console.Write(Board[i, j]);
                        }
                    }
                }
                Console.Write("\n");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("    X/Y   ");
            for (int j = 0; j < 9; j++)
            {
                Console.Write(j + " ");
            }
        }
    }
}