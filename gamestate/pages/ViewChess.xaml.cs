using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace gamestate
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ViewChess : Page
    {
        public ViewChess()
        {
            this.InitializeComponent();
        }

        public int matrixWidth = GoBang.matrixWidth;
        public int[,] matrix;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            matrix = ((int[,])e.Parameter);
            InstallChessboard();
            drawChess();
            return;
        }

        // 绘制棋盘
        public void InstallChessboard()
        {
            //定义棋盘背景色
            chessBoard.Background = new SolidColorBrush(Color.FromArgb(255, 255, 147, 15));
            double BoardWid, BoardHei;
            BoardWid = chessBoard.Width;
            BoardHei = chessBoard.Height;
            //绘制线条 20 * 20的棋盘需要15条线
            for (int i = 0; i < matrixWidth; i++)
            {
                Line xLine = new Line();
                Line yLine = new Line();
                xLine.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                yLine.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                xLine.X1 = 15;
                xLine.X2 = BoardWid - 15;
                yLine.Y1 = 15;
                yLine.Y2 = BoardHei - 15;
                xLine.Y1 = xLine.Y2 = yLine.X1 = yLine.X2 = (BoardHei - 30) / 14 * i + 15;
                chessBoard.Children.Add(xLine);
                chessBoard.Children.Add(yLine);
            }
        }
        // 渲染棋子
        public void drawChess()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (matrix[i, j] == 0)
                        continue;
                    Ellipse newChess = new Ellipse();
                    newChess.Width = 20;
                    newChess.Height = 20;
                    if (matrix[i, j] == 1)
                    {
                        newChess.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

                    }
                    else if (matrix[i, j] == 2)
                    {
                        newChess.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                    }
                    Canvas.SetLeft(newChess, j * (chessBoard.Width - 30) / 14 + 5);
                    Canvas.SetTop(newChess, i * (chessBoard.Width - 30) / 14 + 5);
                    chessBoard.Children.Add(newChess);
                }
            }
        }

        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

        }
    }
}
