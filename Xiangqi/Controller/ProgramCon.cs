using System;
using Model;
using View;

namespace Controller
{
    class ProgramCon
    {
        public int turn = 0;
        public bool Turn(int X, int Y, int chozenX, int chozenY,ProgramMod.block[,] Matrix)//在己方回合中不能选择对方棋子
        {
            ProgramMod mod = new ProgramMod();
            if (turn == 0)
            {
                if (Matrix[chozenX, chozenY].item.side !=ProgramMod.player.red)
                {
                    return false;
                }
                else
                {
                    bool check = mod.movechess(X, Y, chozenX, chozenY, Matrix);
                    if (check == true)
                    {
                        turn = 1;
                        return true;
                    }
                    else return false;
                }
            }
            else if (turn == 1)
            {
                if (Matrix[chozenX, chozenY].item.side != ProgramMod.player.blue)
                {
                    return false;
                }
                else
                {
                    bool check = mod.movechess(X, Y, chozenX, chozenY, Matrix);
                    if (check == true)
                    {
                        turn = 0;
                        return true;
                    }
                    else return false;
                }
            }
            else return false;
        }
        public bool Result(ProgramMod.block[,] Matrix)//判断游戏是否结束
        {
            int n = 0;
            bool result = true;
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Matrix[i, j].item.type == ProgramMod.chesstype.jiang)
                    {
                        n++;
                    }
                }
            }
            if (n == 2)
            {
                return result;
            }
            else
            {
                result = false;
                return result;
            }
        }
        public int Checkpiece(int chozenX, int chozenY, ProgramMod.block[,] Matrix)//检测选中的是否棋子
        {
            if (Matrix[chozenX, chozenY].item.type == ProgramMod.chesstype.blank)
            {
                return 0;
            }
            else if (turn == 0)
            {
                if (Matrix[chozenX, chozenY].item.side != ProgramMod.player.red)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else if (turn == 1)
            {
                if (Matrix[chozenX, chozenY].item.side != ProgramMod.player.blue)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            return 0;
        }
        public void process(ProgramMod.block[,] Matrix)//整个流程的调用
        {
            ProgramCon con = new ProgramCon();
            ProgramMod mod = new ProgramMod();
            ProgramView view = new ProgramView();
            bool result = true;
            bool turn;
            int player = 0;
            while (result == true)
            {
                string[,] Board = mod.Piece(Matrix);
                view.display(Matrix);
                if (player % 2 == 0)
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
                        view.printfroad(chozenX * 2, chozenY, Matrix);
                        Console.Write("\n        We get the piece:" + Board[chozenX * 2, chozenY] + "(" + chozenX + "," + chozenY + ").\n");
                        Console.Write("Please  choose the position you want to move:\n");
                        Console.Write("====================================\n");
                        Console.Write("            movetoX =");
                        int X = Convert.ToInt32(Console.ReadLine());
                        Console.Write("            movetoY =");
                        int Y = Convert.ToInt32(Console.ReadLine());
                        turn = con.Turn(X * 2, Y, chozenX * 2, chozenY, Matrix);
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
                        result = con.Result(Matrix);
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
                catch (Exception)
                {
                    Console.Write("You can not enter this and try again please!");
                    Console.ReadLine();
                }
            }
            view.display(Matrix);
            if (player % 2 == 1)
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
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            ProgramCon con = new ProgramCon();
            ProgramMod mod = new ProgramMod();
            ProgramMod.block[,]Matrix = mod.resetground();
            con.process(Matrix);
        }
    }
}
