using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ChessBoard
    {
        //棋盘模型的建造
        public static string[,] DrawingBoard()
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
                    Board[i, 8] = "┫";
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
    }
}
