﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
using Controller;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Chess[,] Matrix;
        public Chess[,] Road;
        public Chess[,] Save;
        public Chess[,] Resultsave;
        public Chess[,] PassRoad;
        ProgramMod mod = new ProgramMod();
        ProgramCon con = new ProgramCon();
        public MainWindow()
        {
            InitializeComponent();
            Processs();
        }
        public void Processs()
        {
            Matrix = mod.Resetground();
            Save = mod.Resetground();
            Road = mod.Setroad();
            Resultsave = mod.Resetground();
            PassRoad = mod.Setroad();
            CreatGrid(Matrix);
        }
        public void CreatGrid(Chess[,] Matrix)
        {
            Grid maingrid = new Grid();
            this.Content = maingrid;
            Grid grid = new Grid();
            maingrid.Children.Add(grid);
            grid.HorizontalAlignment = HorizontalAlignment.Left;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            ImageBrush mainGrid = new ImageBrush();
            mainGrid.ImageSource = new BitmapImage(new Uri(@"\Users\SUNNY\source\repos\WPFXiangqi\Resources\background1.jpg", UriKind.RelativeOrAbsolute));
            maingrid.Background = mainGrid;

            //=======================================================================

            ImageBrush Board = new ImageBrush();
            Board.ImageSource = new BitmapImage(new Uri(@"\Users\SUNNY\source\repos\WPFXiangqi\Resources\Board.jpg", UriKind.RelativeOrAbsolute));
            grid.Background = Board;
            //=======================================================================
            
            ColumnDefinition[] col = new ColumnDefinition[9];
            for (int i = 0; i < 9; i++)
            {
                col[i] = new ColumnDefinition();
                col[i].Width = new GridLength(75);
                grid.ColumnDefinitions.Add(col[i]);
            }
            RowDefinition[] row = new RowDefinition[10];
            for (int i = 0; i < 10; i++)
            {
                row[i] = new RowDefinition();
                row[i].Height = new GridLength(75);
                grid.RowDefinitions.Add(row[i]);
            }
            Tips(maingrid);
            layout(Matrix, grid);
        }
        public void layout(Chess[,] Matrix, Grid grid)
        {
            Button[,] btn = new Button[10, 9];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    btn[i, j] = new Button();
                    btn[i, j].Width = 65;
                    btn[i, j].Height = 65;
                    btn[i, j].Margin = new Thickness(8, 10, 0, 0);
                    btn[i, j].BorderThickness = new Thickness(0, 0, 0, 0);
                    btn[i, j].Background = Brushes.Transparent;
                    btn[i, j] = PutChess(Matrix, btn[i, j], i, j);
                    btn[i, j].SetValue(Grid.RowProperty, i);
                    btn[i, j].SetValue(Grid.ColumnProperty, j);
                    if (Road[i, j].road == Chess.chessroad.can)
                    {
                        btn[i, j].Width = 30;
                        btn[i, j].Height = 30;
                        btn[i, j].Background = Brushes.ForestGreen;
                    }
                    grid.Children.Add(btn[i, j]);
                }
            }
            Buttoneven(Matrix, btn);
        }
        public void Tips(Grid maingrid)
        {
            TextBlock Textplayer = new TextBlock();
            maingrid.Children.Add(Textplayer);
            Textplayer.FontSize = 50;
            Textplayer.Margin = new Thickness(705, 221, 0, 0);
            TextBlock operation = new TextBlock();
            maingrid.Children.Add(operation);
            if (chozentime % 2 == 0)
            {
                operation.Text = "Select the piece";
            }
            else
            {
                operation.Text = "Move the piece";
            }
            operation.FontSize = 30;
            operation.Foreground = Brushes.Gray;
            operation.Margin = new Thickness(717, 350, 0, 0);
            if (player % 2 == 0)
            {
                Textplayer.Foreground = Brushes.Red;
                Textplayer.Text = "Red turn";
            }
            else
            {
                Textplayer.Foreground = Brushes.Blue;
                Textplayer.Text = "Blue turn";
            }
            Button Regret = new Button();
            maingrid.Children.Add(Regret);
            Regret.Width = 175;
            Regret.Height = 45;
            Regret.Content = "Regret";
            Regret.FontSize = 30;
            Regret.Margin = new Thickness(650, 250, 0, 50);
            Regret.Click += Regret_Game;
        }
        public void Regret_Game(object sender, RoutedEventArgs e)
        {
            if (regret == 0 && player !=0 ) 
            {
                if(check == false)
                {
                    check = true;
                }
                con.Trans(Matrix, Save);
                player = player - 1;
                regret++;
                CreatGrid(Matrix);
            }
            else
            {
                MessageBox.Show("No more regret");
            }
        }
        public void Buttoneven(Chess[,] Matrix, Button[,] btn)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    btn[i, j].Click += Button_Click;
                }
            }
        }
        public int chozenX;
        public int chozenY;
        public int X;
        public int Y;
        public int chozentime = 0;
        public int player = 0;
        public int regret = 0;
        public bool check = true;
        public bool defence = false;
        // public int Case;
        public int r, c;
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            int btnRow = (int)((Button)sender).GetValue(Grid.RowProperty);
            int btnCol = (int)((Button)sender).GetValue(Grid.ColumnProperty);
            Click(btnRow, btnCol);
        }
        public void Click( int btnRow, int btnCol)
        {
            bool result1,result2;
            if (chozentime % 2 == 0)
            {
                chozenX = btnRow;
                chozenY = btnCol;
                if (Matrix[chozenX, chozenY].side == Chess.player.blank)
                {
                    MessageBox.Show("There is no piece");
                }
                else if (player % 2 == 0)
                {
                    if (Matrix[chozenX, chozenY].side == Chess.player.blue)
                    {
                        MessageBox.Show("Now it is red turn ,you can not chose this chess");
                    }
                    else
                    {
                        Road = con.Road(chozenX, chozenY, Matrix);
                        chozentime++;
                        CreatGrid(Matrix);
                        Road = mod.Setroad();
                    }
                }
                else if (player % 2 == 1)
                {
                    if (Matrix[chozenX, chozenY].side == Chess.player.red)
                    {
                        MessageBox.Show("Now it is blue turn ,you can not chose this chess");
                    }
                    else
                    {
                        Road = con.Road(chozenX, chozenY, Matrix);
                        chozentime++;
                        CreatGrid(Matrix);
                        Road = mod.Setroad();
                    }
                }
            }
            else
            {
                X = btnRow;
                Y = btnCol;
                if (X == chozenX && Y == chozenY)
                {
                    MessageBox.Show("Cancel the operation!");
                    CreatGrid(Matrix);
                }
                else
                {
                    con.Trans(Save,Matrix);
                    regret = 0;
                    bool move = con.movechess(X, Y, chozenX, chozenY, Matrix);
                    if (move == false)
                    {
                        MessageBox.Show("You can not move there!");
                    }
                    else
                    {
                        if (check == true)
                        {
                            player++;
                        }
                        else 
                        {
                            Check();
                            if (check == true)
                            {
                                player++;
                            }
                            else
                            {
                                if (defence == false)
                                {
                                    MessageBox.Show("Your have been checked!");
                                    con.Trans(Matrix, Save);
                                    regret++;
                                }
                                else
                                {
                                    player++;
                                }
                            }
                        }
                    }
                    result1 = con.Result(Matrix);
                    //result2 = Result();
                    if (result1 == false /*|| result2 == false*/)
                    {
                        CreatGrid(Matrix);
                        if (player % 2 == 1)
                        {
                            MessageBox.Show("Game over, Red win!");
                        }
                        else
                        {
                            MessageBox.Show("Game over, Blue win!");
                        }
                        System.Environment.Exit(0);
                    }
                }
                chozentime++;
                Check();
                if (check == false)
                {
                    MessageBox.Show("Your have been checked!");
                }
                CreatGrid(Matrix);
            }
        }
        public void Check()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Matrix[i, j].side != Chess.player.blank)
                    {
                        Road = con.Road(i, j, Matrix);
                        for (int k = 0; k < 10; k++)
                        {
                            for (int l = 0; l < 9; l++)
                            {
                                if (Matrix[k, l].type == Chess.chesstype.jiang && Road[k, l].road == Chess.chessroad.can)
                                {
                                    check = false;
                                    if (Matrix[k, l].side == Chess.player.red && player % 2 == 1 
                                        || Matrix[k, l].side == Chess.player.blue && player % 2 == 0 && defence != true)
                                    {
                                        con.Trans(Matrix, Save);
                                        player--;
                                        regret++;
                                        check = true;
                                        MessageBox.Show("If you move there , you lose! ");
                                    }
                                    r = k;
                                    c = l;
                                    PassRoad[r, c].road = Road[r, c].road;
                                }
                            }
                        }
                        Road = mod.Setroad();
                    }
                }
            }
            if (Matrix[r, c].type == Chess.chesstype.jiang && PassRoad[r, c].road == Chess.chessroad.cant)
            {
                check = true;
                defence = true;
            }
            PassRoad = mod.Setroad();
        }
       /* public bool Result()
        {
            bool result = true;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Matrix[i, j].side != Chess.player.blank)
                    {
                        for (int k = 0; k < 10; k++)
                        {
                            for (int l = 0; l < 9; l++)
                            {
                                con.Trans(Resultsave, Matrix);
                                if (player % 2 == 1 && Matrix[i, j].side == Chess.player.red)
                                {
                                    bool move = con.movechess(i, j, k, l, Matrix);
                                    
                                    if (move == true)
                                    {
                                        for (int a = 0; a < 10; a++)
                                        {
                                            for (int b = 0; b < 9; b++)
                                            {
                                                if(Matrix[a, b].side == Chess.player.blue)
                                                {
                                                    Road = con.Road(a, b, Matrix);
                                                    if (Matrix[r, c].type == Chess.chesstype.jiang && Road[r, c].road == Chess.chessroad.can)
                                                    {
                                                        result = false;
                                                    }
                                                }
                                            }
                                        }
                                        con.Trans(Matrix, Resultsave);
                                    }
                                }
                                else if (player % 2 == 0 && Matrix[i, j].side == Chess.player.blue)
                                {
                                    bool move = con.movechess(i, j, k, l, Matrix);

                                    if (move == true)
                                    {
                                        for (int a = 0; a < 10; a++)
                                        {
                                            for (int b = 0; b < 9; b++)
                                            {
                                                if (Matrix[a, b].side == Chess.player.red)
                                                {
                                                    Road = con.Road(a, b, Matrix);
                                                    if (Matrix[r, c].type == Chess.chesstype.jiang && Road[r, c].road == Chess.chessroad.can)
                                                    {
                                                        result = false;
                                                    }
                                                }
                                            }
                                        }
                                        con.Trans(Matrix, Resultsave);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }*/
        public Button PutChess(Chess[,] Matrix, Button btn, int i, int j)
        {
            switch (Matrix[i, j].side)
            {
                case Chess.player.red:
                    switch (Matrix[i, j].type)
                    {
                        case Chess.chesstype.che:
                            ImageBrush Redche = new ImageBrush();
                            Redche.ImageSource = new BitmapImage(new Uri(@"\Users\SUNNY\source\repos\WPFXiangqi\Resources\redche.png", UriKind.RelativeOrAbsolute));
                            btn.Background = Redche;
                            return btn;
                        case Chess.chesstype.ma:
                            ImageBrush Redma = new ImageBrush();
                            Redma.ImageSource = new BitmapImage(new Uri(@"\Users\SUNNY\source\repos\WPFXiangqi\Resources\redma.png", UriKind.RelativeOrAbsolute));
                            btn.Background = Redma;
                            return btn;
                        case Chess.chesstype.xiang:
                            ImageBrush Redxiang = new ImageBrush();
                            Redxiang.ImageSource = new BitmapImage(new Uri(@"\Users\SUNNY\source\repos\WPFXiangqi\Resources\redxiang.png", UriKind.RelativeOrAbsolute));
                            btn.Background = Redxiang;
                            return btn;
                        case Chess.chesstype.shi:
                            ImageBrush Redshi = new ImageBrush();
                            Redshi.ImageSource = new BitmapImage(new Uri(@"\Users\SUNNY\source\repos\WPFXiangqi\Resources\redshi.png", UriKind.RelativeOrAbsolute));
                            btn.Background = Redshi;
                            return btn;
                        case Chess.chesstype.jiang:
                            ImageBrush Redjiang = new ImageBrush();
                            Redjiang.ImageSource = new BitmapImage(new Uri(@"\Users\SUNNY\source\repos\WPFXiangqi\Resources\redjiang.png", UriKind.RelativeOrAbsolute));
                            btn.Background = Redjiang;
                            return btn;
                        case Chess.chesstype.pao:
                            ImageBrush Redpao = new ImageBrush();
                            Redpao.ImageSource = new BitmapImage(new Uri(@"\Users\SUNNY\source\repos\WPFXiangqi\Resources\redpao.png", UriKind.RelativeOrAbsolute));
                            btn.Background = Redpao;
                            return btn;
                        case Chess.chesstype.zu:
                            ImageBrush Redzu = new ImageBrush();
                            Redzu.ImageSource = new BitmapImage(new Uri(@"\Users\SUNNY\source\repos\WPFXiangqi\Resources\redzu.png", UriKind.RelativeOrAbsolute));
                            btn.Background = Redzu;
                            return btn;
                    }
                    return btn;
                case Chess.player.blue:
                    switch (Matrix[i, j].type)
                    {
                        case Chess.chesstype.che:
                            ImageBrush Blueche = new ImageBrush();
                            Blueche.ImageSource = new BitmapImage(new Uri(@"\Users\SUNNY\source\repos\WPFXiangqi\Resources\blueche.png", UriKind.RelativeOrAbsolute));
                            btn.Background = Blueche;
                            return btn;
                        case Chess.chesstype.ma:
                            ImageBrush Bluema = new ImageBrush();
                            Bluema.ImageSource = new BitmapImage(new Uri(@"\Users\SUNNY\source\repos\WPFXiangqi\Resources\bluema.png", UriKind.RelativeOrAbsolute));
                            btn.Background = Bluema;
                            return btn;
                        case Chess.chesstype.xiang:
                            ImageBrush Bluexiang = new ImageBrush();
                            Bluexiang.ImageSource = new BitmapImage(new Uri(@"\Users\SUNNY\source\repos\WPFXiangqi\Resources\bluexiang.png", UriKind.RelativeOrAbsolute));
                            btn.Background = Bluexiang;
                            return btn;
                        case Chess.chesstype.shi:
                            ImageBrush Blueshi = new ImageBrush();
                            Blueshi.ImageSource = new BitmapImage(new Uri(@"\Users\SUNNY\source\repos\WPFXiangqi\Resources\blueshi.png", UriKind.RelativeOrAbsolute));
                            btn.Background = Blueshi;
                            return btn;
                        case Chess.chesstype.jiang:
                            ImageBrush Bluejiang = new ImageBrush();
                            Bluejiang.ImageSource = new BitmapImage(new Uri(@"\Users\SUNNY\source\repos\WPFXiangqi\Resources\bluejiang.png", UriKind.RelativeOrAbsolute));
                            btn.Background = Bluejiang;
                            return btn;
                        case Chess.chesstype.pao:
                            ImageBrush Bluepao = new ImageBrush();
                            Bluepao.ImageSource = new BitmapImage(new Uri(@"\Users\SUNNY\source\repos\WPFXiangqi\Resources\bluepao.png", UriKind.RelativeOrAbsolute));
                            btn.Background = Bluepao;
                            return btn;
                        case Chess.chesstype.zu:
                            ImageBrush Bluezu = new ImageBrush();
                            Bluezu.ImageSource = new BitmapImage(new Uri(@"\Users\SUNNY\source\repos\WPFXiangqi\Resources\bluezu.png", UriKind.RelativeOrAbsolute));
                            btn.Background = Bluezu;
                            return btn;
                    }
                    return btn;
            }
            return btn;
        }
    }
}
