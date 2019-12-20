using System;
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
        ProgramMod mod = new ProgramMod();
        public MainWindow()
        {
            InitializeComponent();
            Processs();
        }
        public void Processs()
        {
            Matrix = mod.Resetground();
            Road = mod.Setroad();
            CreatGrid(Matrix);
        }
        public void CreatGrid(Chess[,] Matrix)
        {
            Grid grid = new Grid();
            ColumnDefinition[] c = new ColumnDefinition[9];
            this.Content = grid;
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //=======================================================================

            ImageBrush Board = new ImageBrush();
            Board.ImageSource = new BitmapImage(new Uri(@"\Users\SUNNY\source\repos\WPFXiangqi\Resources\Board.jpg", UriKind.RelativeOrAbsolute));
            grid.Background = Board;
            //=======================================================================

            for (int i = 0; i < 9; i++)
            {
                c[i] = new ColumnDefinition();
                c[i].Width = new GridLength(75);
                grid.ColumnDefinitions.Add(c[i]);
            }
            RowDefinition[] r = new RowDefinition[10];
            for (int i = 0; i < 10; i++)
            {
                r[i] = new RowDefinition();
                r[i].Height = new GridLength(75);
                grid.RowDefinitions.Add(r[i]);
            }
            layout(Matrix, grid);
        }
        public void layout(Chess[,] Matrix, Grid grid)
        {
            Button[,] btn = new Button[10, 9];
            TextBlock[,] text = new TextBlock[10, 9];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    btn[i, j] = new Button();
                    text[i, j] = new TextBlock();
                    btn[i, j].Width = 65;
                    btn[i, j].Height = 65;
                    btn[i, j].Margin = new Thickness(8, 10, 0, 0);
                    btn[i, j].BorderThickness = new Thickness(0, 0, 0, 0);
                    btn[i, j].Background = Brushes.Transparent;
                    btn[i, j] = PutChess(Matrix, btn[i, j], i, j);
                    //btn[i, j].Background = Brushes.ForestGreen;
                    //btn[i, j].Background = new SolidColorBrush(Colors.MediumSlateBlue);
                    btn[i, j].SetValue(Grid.RowProperty, i);
                    btn[i, j].SetValue(Grid.ColumnProperty, j);
                    if(Road[i,j].road == Chess.chessroad.can)
                    {
                        btn[i, j].Width = 30;
                        btn[i, j].Height = 30;
                        btn[i, j].Background = Brushes.ForestGreen;
                    }
                    grid.Children.Add(btn[i, j]);
                }
            }
            Buttoneven(Matrix,btn);

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
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            bool result;
            ProgramCon con = new ProgramCon();
            int btnRow = (int)((Button)sender).GetValue(Grid.RowProperty);
            int btnCol = (int)((Button)sender).GetValue(Grid.ColumnProperty);
            //MessageBox.Show("Button is:" + "\n - Column ="+btnCol + "\n - Row =" + btnRow);
            if (chozentime%2 == 0)
            {
                chozenX = btnRow;
                chozenY = btnCol;
                if (Matrix[chozenX, chozenY].side == Chess.player.blank)
                {
                    MessageBox.Show("There is no piece");
                }
                else if(player%2 == 0)
                {
                    if (Matrix[chozenX, chozenY].side == Chess.player.blue)
                    {
                        MessageBox.Show("Now it is red turn ,you can not chose this chess");
                    }
                    else
                    {
                        // MessageBox.Show("You chozen it.");
                        //MessageBox.Show("Button is:" + "\n - Column =" + btnCol + "\n - Row =" + btnRow);
                        Road = con.Road(chozenX, chozenY, Matrix);
                        CreatGrid(Matrix);
                        Road = mod.Setroad();
                        chozentime++;
                    }
                }
                else if(player%2 == 1)
                {
                    if (Matrix[chozenX, chozenY].side == Chess.player.red)
                    {
                        MessageBox.Show("Now it is blue turn ,you can not chose this chess");
                    }
                    else
                    {
                        // MessageBox.Show("You chozen it.");
                        //MessageBox.Show("Button is:" + "\n - Column =" + btnCol + "\n - Row =" + btnRow);
                        Road = con.Road(chozenX, chozenY, Matrix);
                        CreatGrid(Matrix);
                        Road = mod.Setroad();
                        chozentime++;
                    }
                }
            }
            else
            {
                X = btnRow;
                Y = btnCol;
                // MessageBox.Show("Button is:" + "\n - Column =" + btnCol + "\n - Row =" + btnRow);
                if (X == chozenX && Y == chozenY)
                {
                    MessageBox.Show("Cancel the operation!");
                    CreatGrid(Matrix);
                }
                else
                {
                    bool move = con.movechess(X, Y, chozenX, chozenY, Matrix);
                    if(move == false)
                    {
                        MessageBox.Show("You can not move there!");
                    }
                    result = con.Result(Matrix);
                    if (result == false)
                    {
                        CreatGrid(Matrix);
                        if (player == 0)
                        {
                            MessageBox.Show("Game over,red win!");
                        }
                        else
                        {
                            MessageBox.Show("Game over,blue win!");
                        }
                        System.Environment.Exit(0);
                    }
                    else
                    {
                        CreatGrid(Matrix);
                    }
                    player++;
                }
                chozentime++;
            }
        }
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
