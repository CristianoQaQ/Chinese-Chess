using System;
using Model;
using View;
namespace Controller
{
    abstract class ProgramCon
    {
        public static int turn = 0;
        public static int Checkpiece(int chozenX, int chozenY, Chess[,] Matrix)//检测选中的是否棋子
        {
            if (Matrix[chozenX, chozenY].type == Chess.chesstype.blank)
            {
                return 0;
            }
            else if (turn == 0)
            {
                if (Matrix[chozenX, chozenY].side != Chess.player.red)
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
                if (Matrix[chozenX, chozenY].side != Chess.player.blue)
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
        public static bool Turn(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)//在己方回合中不能选择对方棋子
        {
            if (turn == 0)
            {
                if (Matrix[chozenX, chozenY].side != Chess.player.red)
                {
                    return false;
                }
                else
                {
                    bool check = movechess(X, Y, chozenX, chozenY, Matrix);
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
                if (Matrix[chozenX, chozenY].side != Chess.player.blue)
                {
                    return false;
                }
                else
                {
                    bool check = movechess(X, Y, chozenX, chozenY, Matrix);
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
        public static bool Result(Chess[,] Matrix)//判断游戏是否结束
        {
            int n = 0;
            bool result = true;
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Matrix[i, j].type == Chess.chesstype.jiang)
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
        public static bool movechess(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)//每种类型棋子的移动规则
        {
            Che che = new Che();
            Ma ma = new Ma();
            Xiang xiang = new Xiang();
            Shi shi = new Shi();
            Jiang jiang = new Jiang();
            Pao pao = new Pao();
            Zu zu = new Zu();
            bool re;
            switch (Matrix[chozenX, chozenY].type)
            {
                case Chess.chesstype.che:
                    re = che.che(X,Y,chozenX,chozenY,Matrix);
                    return re;
                case Chess.chesstype.ma:
                    re = ma.ma(X, Y, chozenX, chozenY, Matrix);
                    return re;
                case Chess.chesstype.xiang:
                    re = xiang.xiang(X, Y, chozenX, chozenY, Matrix);
                    return re;
                case Chess.chesstype.shi:
                    re = shi.shi(X, Y, chozenX, chozenY, Matrix);
                    return re;
                case Chess.chesstype.jiang:
                    re = jiang.jiang(X, Y, chozenX, chozenY, Matrix);
                    return re;
                case Chess.chesstype.pao:
                    re = pao.pao(X, Y, chozenX, chozenY, Matrix);
                    return re;
                case Chess.chesstype.zu:
                    re = zu.zu(X, Y, chozenX, chozenY, Matrix);
                    return re;
            }
            return false;
        }
        public void Setmove(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)//通用的移动规则
        {
            Matrix[X, Y].side = Matrix[chozenX, chozenY].side;
            Matrix[X, Y].type = Matrix[chozenX, chozenY].type;
            Matrix[chozenX, chozenY].side = Chess.player.blank;
            Matrix[chozenX, chozenY].type = Chess.chesstype.blank;
        }
        public static Chess[,] Road(int chozenX, int chozenY, Chess[,] Matrix)
        {
            ProgramMod mod = new ProgramMod();
            Chess[,] road = mod.Setroad();
            Chess[,] trans = new Chess[19,9];
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    trans[i, j] = new Chess();
                }
            }
            bool cr;
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i % 2 == 0)
                    {
                        trans[i, j].side = Matrix[i, j].side;
                        trans[i, j].type = Matrix[i, j].type;
                        trans[chozenX, chozenY].side = Matrix[chozenX, chozenY].side;
                        trans[chozenX, chozenY].type = Matrix[chozenX, chozenY].type;
                        cr = movechess(i, j, chozenX, chozenY, Matrix);
                        if (cr == true)
                        {
                            road[i, j].road = Chess.chessroad.can;
                        }
                        Matrix[i, j].side = trans[i, j].side;
                        Matrix[i, j].type = trans[i, j].type;
                        Matrix[chozenX, chozenY].side = trans[chozenX, chozenY].side;
                        Matrix[chozenX, chozenY].type = trans[chozenX, chozenY].type;
                    }
                }
            }
            return road;
        }
        public static void Process(Chess[,] Matrix,Chess[,]road)//整个流程的调用
        {
            ProgramMod mod = new ProgramMod();
            ProgramView view = new ProgramView();
            bool result = true;
            bool turn;
            int player = 0;
            while (result == true)
            {
                string[,] Board = mod.Piece(Matrix);
                view.display(Matrix,road);
                view.Star(player);
                try
                {
                    Console.Write("====================================\n");
                    Console.Write("            ChozenX =");
                    int chozenX = Convert.ToInt32(Console.ReadLine());
                    Console.Write("            ChozenY =");
                    int chozenY = Convert.ToInt32(Console.ReadLine());
                    int checkpiece = Checkpiece(chozenX * 2, chozenY, Matrix);
                    if (checkpiece == 2)//检测是否有棋子
                    {
                        road = Road(chozenX*2, chozenY, Matrix);
                        view.display(Matrix, road);
                        road = mod.Setroad();
                        view.Check(checkpiece,Board,chozenX,chozenY);
                        Console.Write("            movetoX =");
                        int X = Convert.ToInt32(Console.ReadLine());
                        Console.Write("            movetoY =");
                        int Y = Convert.ToInt32(Console.ReadLine());
                        turn = Turn(X * 2, Y, chozenX * 2, chozenY, Matrix);
                        player = view.Move(turn, player);
                        result = Result(Matrix);
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
            view.display(Matrix,road);
            view.Win(player);
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            ProgramMod mod = new ProgramMod();
            Chess [,] Matrix = mod.Resetground();
            Chess[,] road = mod.Setroad();
            Process(Matrix,road);
        }
    }
}
