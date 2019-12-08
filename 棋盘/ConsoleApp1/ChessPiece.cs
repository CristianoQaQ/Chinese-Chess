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
        struct chess
        {
            public player side;
            public chesstype type;
        };//自定义红蓝方和棋子类型两个结构
        struct block
        {
            public chess item;
        };//自定义一个结构用以整合为一个棋子
        block[,] Matrix;//为棋子创建一个自定义的数组类型。
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
        public bool movechess(int X, int Y,int chozenX, int chozenY)//每种类型棋子的移动规则（未完成）
        {
            int i, j, k, n = 0;
            switch (Matrix[chozenX, chozenY].item.type)
            {
                case chesstype.che:
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
                }
            }


            return layout;
        }
    }
}