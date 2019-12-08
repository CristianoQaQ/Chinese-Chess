using System;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPiece move = new ChessPiece();
            move.resetground();
            bool result = true;
            while (result == true)
            {
                string[,] Board = move.Piece();
                for (int i = 0; i <= 18; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write(i / 2 + "   ");
                    }
                    else { Console.Write("    "); }
                    for (int j = 0; j < 9; j++)
                    {
                        Console.Write(Board[i, j]);
                    }
                    Console.Write("\n");
                }
                Console.Write("X/Y  ");
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(j + " ");
                }
                Console.Write("\n");
                Console.Write("Please  choose the position of the piece:\n");
                Console.Write("ChozenX =");
                int chozenX = Convert.ToInt32(Console.ReadLine());
                Console.Write("ChozenY =");
                int chozenY = Convert.ToInt32(Console.ReadLine());
                Console.Write("We get the piece:"+Board[chozenX,chozenY]+"(" + chozenX + "," + chozenY + ").\n");
                Console.Write("Please  choose the position you want to move:\n");
                Console.Write("X =");
                int X = Convert.ToInt32(Console.ReadLine());
                Console.Write("Y =");
                int Y = Convert.ToInt32(Console.ReadLine());
                move.movechess(X * 2, Y, chozenX * 2, chozenY);
            }
        }
    }
}
