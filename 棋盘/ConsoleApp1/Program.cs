﻿using System;
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
            Board[0, 0] = "车";
            Board[0, 1] = "马";
            Board[0, 2] = "象";
            Board[0, 3] = "士";
            Board[0, 4] = "将";
            Board[0, 5] = "士";
            Board[0, 6] = "象";
            Board[0, 7] = "马";
            Board[0, 8] = "车";
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
