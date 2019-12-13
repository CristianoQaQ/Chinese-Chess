using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Chess
    {
        public enum player
        {
            blank,
            red,
            blue,
        };//分为红蓝两方
        public enum chesstype
        {
            blank,
            jiang,
            che,
            ma,
            pao,
            xiang,
            zu,
            shi
        };//分为不同的棋子类型
        public enum chessroad
        {
            can,
            cant
        };//可行与不可行
        public player side;
        public chesstype type;
        public chessroad road;
    }
}
