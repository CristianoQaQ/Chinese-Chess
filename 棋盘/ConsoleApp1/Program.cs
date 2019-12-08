using System;
namespace ConsoleApp1
{
    class Program
    {
        /*enum player
        {
            blank,
            red,
            blue,
        };
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
        };
        struct chess
        {
            public player side;
            public chesstype type;
        };*/
        
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");
            /*int x, y;
            string x1, y1;
            int colup = 0, coldown = 0;
            int rowleft = 0, rowright = 0;
            int m;
            int dialeftup = 0, dialeftdown = 0, diarightup = 0,
                diarightdown = 0;
            int judgement;*/

            
            string[,] Board = ChessBoard.DrawingBoard();
            Board[0, 0] = Board[0, 8] = "車";
            Board[0, 1] = Board[0, 7] = "马";
            Board[0, 2] = Board[0, 6] = "象";
            Board[0, 3] = Board[0, 5] = "士";
            Board[0, 4] = "将";
            Board[4, 1] = Board[4, 7] = "砲";
            Board[6, 0] = Board[6, 2] = Board[6, 4] = Board[6, 6] = Board[6, 8] = "卒";
            Board[14, 1] = Board[14, 7] = "炮";
            Board[18, 0] = Board[18, 8] = "车";
            Board[18, 1] = Board[18, 7] = "马";
            Board[18, 2] = Board[18, 6] = "相";
            Board[18, 3] = Board[18, 5] = "仕";
            Board[18, 4] = "帅";
            Board[12, 0] = Board[12, 2] = Board[12, 4] = Board[12, 6] = Board[12, 8] = "兵";

            for (int i = 0; i <= 18; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Console.Write(Board[i, j]);
                    }
                    Console.Write("\n");
                }

            Console.ReadKey();
        }
    }
}
