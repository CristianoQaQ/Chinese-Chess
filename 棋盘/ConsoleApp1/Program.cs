using System;
namespace ConsoleApp1
{
    class Program
    {
        enum player
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
        };
        private static string[,] layout()
        {
            string[,] qipan = new string[19, 9];
            Console.Clear();
            qipan[0, 0] = "┏-";
            qipan[18, 0] = "┗-";
            qipan[0, 8] = "┓";
            qipan[18, 8] = "┛";
            for (int i = 1; i < 18; i++)
            {
                if (i % 2 == 0)
                {
                    qipan[i, 0] = "┣-";
                    qipan[i, 8] = "┫";
                }
                else
                {
                    qipan[i, 0] = "┃ ";
                    qipan[i, 8] = "┃ ";
                }
            }
            for (int j = 1; j < 8; j++)
            {
                qipan[0, j] = "┳-";
                qipan[10, j] = "┳-";
                qipan[8, j] = "┻-";
                qipan[18, j] = "┻-";
            }

            for (int j = 1; j < 8; j++)
            {
                qipan[1, j] = "┃ ";
                qipan[2, j] = "╋-";
                qipan[3, j] = "┃ ";
                qipan[4, j] = "╋-";
                qipan[5, j] = "┃ ";
                qipan[6, j] = "╋-";
                qipan[7, j] = "┃ ";
                qipan[9, j] = "  ";
                qipan[11, j] = "┃ ";
                qipan[12, j] = "╋-";
                qipan[13, j] = "┃ ";
                qipan[14, j] = "╋-";
                qipan[15, j] = "┃ ";
                qipan[16, j] = "╋-";
                qipan[17, j] = "┃ ";
            }
            qipan[1, 3] = "┃";
            qipan[3, 3] = "┃";
            qipan[15, 3] = "┃";
            qipan[17, 3] = "┃";
            qipan[9, 1] = "楚";
            qipan[9, 2] = "河";
            qipan[9, 6] = "汉";
            qipan[9, 7] = "界";
            qipan[1, 4] = "╲┃╱";
            qipan[3, 4] = "╱┃╲";
            qipan[15, 4] = "╲┃╱";
            qipan[17, 4] = "╱┃╲";
            return qipan;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*int x, y;
            string x1, y1;
            int colup = 0, coldown = 0;
            int rowleft = 0, rowright = 0;
            int m;
            int dialeftup = 0, dialeftdown = 0, diarightup = 0,
                diarightdown = 0;
            int judgement;*/
            string [,] qipan = layout();
                for (int i = 0; i <= 18; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Console.Write(qipan[i, j]);
                    }
                    Console.Write("\n");
                }
        }
    }
}
