using System;
using Model;

namespace View
{
     public class ProgramView
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
        }
        ProgramMod mod = new ProgramMod();
        public void display(ProgramMod.block[,] Matrix)
        {
            string[,] Board = mod.Piece(Matrix);
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
                    if (Matrix[i, j].item.side == ProgramMod.player.blue)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(Board[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (Matrix[i, j].item.side == ProgramMod.player.red)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Board[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    else { Console.Write(Board[i, j]); }
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
        //打印可走的路径
        public void printfroad(int chozenX, int chozenY, ProgramMod.block[,] Matrix)
        {
            ProgramMod.block[,] road = mod.road( chozenX, chozenY,Matrix);
            string[,] Board = mod.Piece(Matrix);

            for (int i = 0; i <= 18; i++)
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
                    if (Matrix[i, j].item.side == ProgramMod.player.blue)
                    {
                        if (road[i, j].item.road == ProgramMod.chessroad.can)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(Board[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            road[i, j].item.road = ProgramMod.chessroad.cant;
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
                    else if (Matrix[i, j].item.side == ProgramMod.player.red)
                    {
                        if (road[i, j].item.road == ProgramMod.chessroad.can)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(Board[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            road[i, j].item.road = ProgramMod.chessroad.cant;
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
                        if (road[i, j].item.road == ProgramMod.chessroad.can)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(Board[i, j]);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            road[i, j].item.road = ProgramMod.chessroad.cant;
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
