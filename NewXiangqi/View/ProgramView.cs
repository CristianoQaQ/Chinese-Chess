using System;
using Model;
using Controller;

namespace View
{
    public class ProgramView
    {
        static void Main(string[] args)
        {
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
        Model.ProgramMod mod = new ProgramMod();
        public void Star(int star)
        {
            if (star % 2 == 0)
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
        }
        public int Move(bool turn, int player)
        {
            if (turn == false)//检测是否可以移动到这个坐标
            {
                Console.Write("You can not move there and enter again please");
                Console.ReadLine();
            }
            else
            {
                Console.Write("           Move success!");
                Console.ReadLine();
                player++;
            }
            return player;
        }
        public void Check(int checkpiece,string [,]Board,int chozenX, int chozenY)
        {
            if (checkpiece == 2)
            {
                Console.Write("\n        We get the piece:" + Board[chozenX * 2, chozenY] + "(" + chozenX + "," + chozenY + ").\n");
                Console.Write("Please  choose the position you want to move:\n");
                Console.Write("====================================\n");
            }
            else if (checkpiece == 0)
            {
                Console.Write("       There is no piece.\n");
                Console.ReadLine();
            }
            else
            {
                Console.Write("       You can not choose it.\n");
                Console.ReadLine();
            }
        }
        public void Wrong()
        {
            Console.Write("You can not enter this and try again please!");
            Console.ReadLine();
        }
        public void Win(int win)
        {
            if (win % 2 == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n     ==========================\n");
                Console.Write("               Red Win");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\n      ==========================\n");
                Console.Write("               Blue Win");
            }
        }
        public void display(Chess [,]Matrix,Chess [,] road)
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
                    if (Matrix[i, j].side == Chess.player.blue)
                    {
                        if (road[i, j].road == Chess.chessroad.can)
                        {
                            Colorgreen(Board, i, j);
                            road[i, j].road = Chess.chessroad.cant;
                        }
                        else
                        {
                            Coloryellow(Matrix ,Board, i, j);
                        }
                    }
                    else if (Matrix[i, j].side == Chess.player.red)
                    {
                        if (road[i, j].road == Chess.chessroad.can)
                        {
                            Colorgreen(Board, i, j);
                            road[i, j].road = Chess.chessroad.cant;
                        }
                        else
                        {
                            Coloryellow(Matrix,Board, i, j);
                        }
                    }
                    else
                    {
                        if (road[i, j].road == Chess.chessroad.can)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(Board[i, j]);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            road[i, j].road = Chess.chessroad.cant;
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
        public void Colorgreen(string[,] Board,int i ,int j)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(Board[i, j]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
        }
        public void Coloryellow(Chess[,] Matrix,string[,] Board, int i, int j)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            if (Matrix[i, j].side == Chess.player.red)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (Matrix[i, j].side == Chess.player.blue)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.Write(Board[i, j]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
        }
    }
}
