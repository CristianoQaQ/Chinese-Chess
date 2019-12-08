using System;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPiece move = new ChessPiece();//建造一个其他类的对象
            move.resetground();//初始化棋盘和棋子
            bool result = true;
            while (result == true)//创造一个循环
            {
                string[,] Board = move.Piece();
                for (int i = 0; i <= 18; i++)//把棋盘和辅助坐标打印出来
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
                move.movechess(X * 2, Y, chozenX * 2, chozenY);//进行棋子的移动
            }
        }
    }
}
