using System;
using Model;

namespace Controller
{
    public class ProgramCon
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
        }
        ProgramMod mod = new ProgramMod();
        public void Trans(Chess[,] Input, Chess[,] Output)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Input[i, j].side = Output[i, j].side;
                    Input[i, j].type = Output[i, j].type;
                }
            }
        }
        public bool Result(Chess[,] Matrix)//判断游戏是否结束
        {
            int n = 0;
            bool result = true;
            for (int i = 0; i < 10; i++)
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
        public Chess[,] GetRoad(int chozenX, int chozenY, Chess[,] Matrix)
        {
            Chess[,] road = mod.Setroad();
            Chess[,] trans = new Chess[10, 9];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    trans[i, j] = new Chess();
                }
            }
            bool cr;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
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
            return road;
        }

        public bool movechess(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)//每种类型棋子的移动规则
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
                    re = che.che(X, Y, chozenX, chozenY, Matrix);
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
        public bool Checkmate(int player, int r, int c, Chess[,] Matrix, Chess[,] Save, Chess[,] Resultsave,Chess[,]Road, bool check )
        {
            int rsave = 0, csave = 0;
            bool result = true;
            bool Wholeloop = true;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (player % 2 == 1 && Matrix[i, j].side == Chess.player.blue && check == false && Wholeloop == true
                        && Save[r, c].type == Chess.chesstype.jiang && Save[r, c].side == Chess.player.blue)
                    {
                        Trans(Resultsave, Matrix);
                        for (int k = 0; k < 10; k++)
                        {
                            for (int l = 0; l < 9; l++)
                            {
                                if (Wholeloop == true)
                                {
                                    bool move = movechess(k, l, i, j, Matrix);
                                    if (move == true)
                                    {
                                        if (Resultsave[i, j].type == Chess.chesstype.jiang)
                                        {
                                            rsave = r;
                                            csave = c;
                                            r = k;
                                            c = l;
                                        }
                                        bool loop = true;
                                        for (int a = 0; a < 10; a++)
                                        {
                                            for (int b = 0; b < 9; b++)
                                            {
                                                if (Matrix[a, b].side == Chess.player.red)
                                                {
                                                    Road = GetRoad(a, b, Matrix);
                                                    if (Road[r, c].road == Chess.chessroad.can && loop == true)
                                                    {
                                                        result = false;
                                                        loop = false;
                                                    }
                                                    else if (Road[r, c].road == Chess.chessroad.cant && loop == true)
                                                    {
                                                        result = true;
                                                    }
                                                    Road = mod.Setroad();
                                                }
                                            }
                                        }
                                        if (Resultsave[i, j].type == Chess.chesstype.jiang)
                                        {
                                            r = rsave;
                                            c = csave;
                                        }
                                        if (result == true)
                                        {
                                            Wholeloop = false;
                                        }
                                    }
                                }
                                Trans(Matrix, Resultsave);
                            }
                        }
                    }
                    else if (player % 2 == 0 && Matrix[i, j].side == Chess.player.red && check == false && Wholeloop == true
                        && Save[r, c].type == Chess.chesstype.jiang && Save[r, c].side == Chess.player.red)
                    {
                        Trans(Resultsave, Matrix);
                        for (int k = 0; k < 10; k++)
                        {
                            for (int l = 0; l < 9; l++)
                            {
                                if (Wholeloop == true)
                                {
                                    bool move = movechess(k, l, i, j, Matrix);
                                    if (move == true)
                                    {
                                        if (Resultsave[i, j].type == Chess.chesstype.jiang)
                                        {
                                            rsave = r;
                                            csave = c;
                                            r = k;
                                            c = l;
                                        }
                                        bool loop = true;
                                        for (int a = 0; a < 10; a++)
                                        {
                                            for (int b = 0; b < 9; b++)
                                            {
                                                if (Matrix[a, b].side == Chess.player.blue)
                                                {
                                                    Road = GetRoad(a, b, Matrix);
                                                    if (Road[r, c].road == Chess.chessroad.can && loop == true)
                                                    {
                                                        result = false;
                                                        loop = false;
                                                    }
                                                    else if (Road[r, c].road == Chess.chessroad.cant && loop == true)
                                                    {
                                                        result = true;
                                                    }
                                                    Road = mod.Setroad();
                                                }
                                            }
                                        }
                                        if (Resultsave[i, j].type == Chess.chesstype.jiang)
                                        {
                                            r = rsave;
                                            c = csave;
                                        }
                                        if (result == true)
                                        {
                                            Wholeloop = false;
                                        }
                                    }
                                }
                                Trans(Matrix, Resultsave);
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}


