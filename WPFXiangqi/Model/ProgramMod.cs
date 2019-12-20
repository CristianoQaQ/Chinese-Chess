using System;

namespace Model
{
    public class ProgramMod
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
        }
        public Chess[,] Setroad()
        {
            Chess[,] road = new Chess[10, 9];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    road[i, j] = new Chess();
                    road[i, j].road = Chess.chessroad.cant;
                }
            }
            return road;
        }
        public Chess[,] Resetground()//给每一个棋子类型赋予属性
        {
            Chess[,] Matrix = new Chess[10, 9];
            for (int i = 0; i < 10; i++)
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
                Matrix[9, j].side = Chess.player.red;
                if (j == 1 || j == 7)
                {
                    Matrix[2, j].side = Chess.player.blue;
                    Matrix[7, j].side = Chess.player.red;
                }
                else if (j % 2 == 0)
                {
                    Matrix[3, j].side = Chess.player.blue;
                    Matrix[6, j].side = Chess.player.red;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (i == 0 || i == 9)
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
                else if (i == 2 || i == 7)
                {
                    Matrix[i, 1].type = Chess.chesstype.pao;
                    Matrix[i, 7].type = Chess.chesstype.pao;
                }
                else if (i == 3 || i == 6)
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

    }
}
