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
            bool turn;
            int player = 0;
            while (result == true)//创造一个循环
            {
                string[,] Board = move.Piece();
                move.display();
                if (player%2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n");
                    Console.Write("              GAME STAR\n");
                    Console.Write("        Now the player is Red\n");
                    Console.Write("Please  choose the position of the piece:\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\n");
                    Console.Write("              GAME STAR\n");
                    Console.Write("        Now the player is Blue\n");
                    Console.Write("Please  choose the position of the piece:\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                try//检测输入值是否正确
                {
                    Console.Write("ChozenX =");
                    int chozenX = Convert.ToInt32(Console.ReadLine());
                    Console.Write("ChozenY =");
                    int chozenY = Convert.ToInt32(Console.ReadLine());
                    bool checkpiece = move.Checkpiece(chozenX*2,chozenY);
                    if (checkpiece == true)//检测是否有棋子
                    {
                        Console.Write("We get the piece:" + Board[chozenX * 2, chozenY] + "(" + chozenX + "," + chozenY + ").\n");
                        Console.Write("Please  choose the position you want to move:\n");
                        Console.Write("movetoX =");
                        int X = Convert.ToInt32(Console.ReadLine());
                        Console.Write("movetoY =");
                        int Y = Convert.ToInt32(Console.ReadLine());
                        turn = move.Turn(X * 2, Y, chozenX * 2, chozenY);
                        if (turn == false)//检测是否可以移动到这个坐标
                        {
                            Console.Write("You can not move there and enter again please");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("Move success!");
                            Console.ReadLine();
                            player++;
                        }
                        result = move.Result();
                    }
                     else
                    {
                        Console.Write("                 There is no piece\n");
                        Console.ReadLine();
                    }
                }
                catch (Exception)
                {
                    Console.Write("You can not enter this and try again please!");
                    Console.ReadLine();
                }
                //进行棋子的移动
            }
            move.display();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n==========================\n");
            Console.Write("                You Win");
            Console.ReadKey();
        }
    }
}
