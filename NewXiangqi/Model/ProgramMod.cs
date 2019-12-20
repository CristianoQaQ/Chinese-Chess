using System;

namespace Model
{
    public class ProgramMod
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
        }
        public Chess[,] Resetground()//给每一个棋子类型赋予属性
        {
            Chess[,]Matrix = new Chess[19, 9];
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Matrix[i, j] = new Chess();
                    Matrix[i, j].side = Chess.player.blank;
                    Matrix[i, j].type = Chess.chesstype.blank;
                }
            }
            for (int j = 0; j < 9; j++)
            {
                Matrix[0, j].side = Chess.player.blue;
                Matrix[18, j].side = Chess.player.red;
                if (j == 1 || j == 7)
                {
                    Matrix[4, j].side = Chess.player.blue;
                    Matrix[14, j].side = Chess.player.red;
                }
                else if (j % 2 == 0)
                {
                    Matrix[6, j].side = Chess.player.blue;
                    Matrix[12, j].side = Chess.player.red;
                }
            }
            for (int i = 0; i < 19; i++)
            {
                if (i == 0 || i == 18)
                {
                    Matrix[i, 0].type = Chess.chesstype.che;
                    Matrix[i, 1].type = Chess.chesstype.ma;
                    Matrix[i, 2].type = Chess.chesstype.xiang;
                    Matrix[i, 3].type = Chess.chesstype.shi;
                    Matrix[i, 4].type = Chess.chesstype.jiang;
                    Matrix[i, 5].type = Chess.chesstype.shi;
                    Matrix[i, 6].type = Chess.chesstype.xiang;
                    Matrix[i, 7].type = Chess.chesstype.ma;
                    Matrix[i, 8].type = Chess.chesstype.che;
                }
                else if (i == 4 || i == 14)
                {
                    Matrix[i, 1].type = Chess.chesstype.pao;
                    Matrix[i, 7].type = Chess.chesstype.pao;
                }
                else if (i == 6 || i == 12)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (j % 2 == 0)
                        {
                            Matrix[i, j].type = Chess.chesstype.zu;
                        }
                    }
                }
            }
            return Matrix;
        }
        public string[,] Piece(Chess[,] Matrix)//把棋子放进棋盘中
        {
            string[,] layout = DrawingBoard();
            string str;
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    str = layout[i, j];
                    layout[i,j] = Word(Matrix, str, i, j);
                }
            }
            return layout;
        }
        public Chess[,] Setroad()
        {
            Chess [,] road = new Chess[19,9];
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    road[i, j] = new Chess();
                    road[i, j].road = Chess.chessroad.cant;
                }
            }
            return road;
        }
        public string Word(Chess[,] Matrix, string str, int i, int j)
        {
            switch (Matrix[i, j].side)
            {
                case Chess.player.red:
                    switch (Matrix[i, j].type)
                    {
                        case Chess.chesstype.che:
                            str = "車";
                            return str;
                        case Chess.chesstype.ma:
                            str = "马";
                            return str;
                        case Chess.chesstype.xiang:
                            str = "象";
                            return str;
                        case Chess.chesstype.shi:
                            str = "仕";
                            return str;
                        case Chess.chesstype.jiang:
                            str = "帅";
                            return str;
                        case Chess.chesstype.pao:
                            str = "炮";
                            return str;
                        case Chess.chesstype.zu:
                            str = "兵";
                            return str;
                    }
                    return str;
                case Chess.player.blue:
                    switch (Matrix[i, j].type)
                    {
                        case Chess.chesstype.che:
                            str = "车";
                            return str;
                        case Chess.chesstype.ma:
                            str = "马";
                            return str;
                        case Chess.chesstype.xiang:
                            str = "相";
                            return str;
                        case Chess.chesstype.shi:
                            str = "士";
                            return str;
                        case Chess.chesstype.jiang:
                            str = "将";
                            return str;
                        case Chess.chesstype.pao:
                            str = "砲";
                            return str;
                        case Chess.chesstype.zu:
                            str = "卒";
                            return str;
                    }
                    return str;
            }
            return str;
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

            for (int i = 0; i < 18; i++)
            {
                for (int k = 1; k < 8; k++)
                {
                    if (i % 2 == 1)
                    {
                        Board[i, k] = "┃ ";
                        if (i == 9)
                        {
                            Board[i, k] = "  ";
                        }
                    }
                    else
                    {
                        if (i != 8 && i != 10)
                        {
                            Board[i, k] = "╋-";
                        } 
                    }
                }
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
    }
}
