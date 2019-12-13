using System;
using Controller;
using Model;
using View;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            ProgramCon con = new ProgramCon();
            ProgramMod mod = new ProgramMod();
            ProgramView view = new ProgramView();
            Chess[,] Matrix = mod.Resetground();
            Chess[,] road = mod.Setroad();
            bool result = true;
            bool turn;
            int player = 0;
            while (result == true)
            {
                string[,] Board = mod.Piece(Matrix);
                view.display(Matrix, road);
                view.Star(player);
                try
                {
                    Console.Write("====================================\n");
                    Console.Write("            ChozenX =");
                    int chozenX = Convert.ToInt32(Console.ReadLine());
                    Console.Write("            ChozenY =");
                    int chozenY = Convert.ToInt32(Console.ReadLine());
                    int checkpiece = con.Checkpiece(chozenX * 2, chozenY, Matrix);
                    if (checkpiece == 2)//检测是否有棋子
                    {
                        road = con.Road(chozenX * 2, chozenY, Matrix);
                        view.display(Matrix, road);
                        road = mod.Setroad();
                        view.Check(checkpiece, Board, chozenX, chozenY);
                        Console.Write("            movetoX =");
                        int X = Convert.ToInt32(Console.ReadLine());
                        Console.Write("            movetoY =");
                        int Y = Convert.ToInt32(Console.ReadLine());
                        turn = con.Turn(X * 2, Y, chozenX * 2, chozenY, Matrix);
                        player = view.Move(turn, player);
                        result = con.Result(Matrix);
                    }
                    else if (checkpiece == 0)
                    {
                        view.Check(checkpiece, Board, chozenX, chozenY);
                    }
                    else
                    {
                        view.Check(checkpiece, Board, chozenX, chozenY);
                    }
                }
                catch (Exception)
                {
                    view.Wrong();
                }
            }
            view.display(Matrix, road);
            view.Win(player);
            Console.ReadKey();
        }
    }
}
