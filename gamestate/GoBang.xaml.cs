using gamestate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace gamestate
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class GoBang : Page
    {
        //定义全局变量 
        public static int matrixWidth = 15;
        public static int[,] matrix;
        //设置全局 记录新放下的棋子在第几行第几列  为后续的悔棋功能做准备
        private int newChess_row = 0, newChess_col = 0;
        //计算网格宽度
        double gridWidth;
        //定义三种状态
        enum state { black, white, none };
        //标记胜利者
        DatabaseManager.identity winner;
        state chessState;
        //定义是否开始
        public static bool gameStart = false;
        public static bool isAIOrNot = false;

        public GoBang()
        {
            this.InitializeComponent();
            InstallChessboard();// 绘制棋盘
            // 初始化数据: 若从之前挂起的应用程序加载状态,gameStart在OnLaunched中复原,否则gameStart为false
            if (gameStart)      // 若上次游戏未结束,则恢复游戏数据
            {
                matrix = App.db.getData();
                drawChess();    // 渲染棋子
                if (isAIOrNot)  // 如果是人机模式,则轮到人落子
                {
                    chessState = state.black;
                }
                else            // 如果是人人模式,则需要判断轮到哪一方落子
                {
                    int numOfWhite = 0, numOfBlack = 0;
                    for (int i = 0; i < matrixWidth; i++)
                    {
                        for (int j = 0; j < matrixWidth; j++)
                        {
                            if (matrix[i, j] == 1)
                            {
                                numOfWhite++;
                            }
                            else if (matrix[i, j] == 2)
                            {
                                numOfBlack++;
                            }
                        }
                    }
                    // 由于黑方先落子,所以黑子不少于白子,且若黑子多于白子,则轮到白方落子;若黑子等于白子,则轮到黑方落子
                    chessState = numOfBlack > numOfWhite ? state.white : state.black;
                }
            }
            else
            {
                matrix = new int[matrixWidth, matrixWidth];
                for (int i = 0; i < matrixWidth; i++)
                {
                    for (int j = 0; j < matrixWidth; j++)
                    {
                        matrix[i, j] = 0;
                    }
                }
                // 默认黑方先攻
                chessState = state.black;
                winner = DatabaseManager.identity.none;
            }
            gridWidth = (chessBoard.Width - 30) / 14;
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        // 展示对战信息
        public void showWinRate()
        {
            // 展示人机对战信息
            if (isAIOrNot)
            {
                int manWinNum = App.db.getWinNum(DatabaseManager.identity.man);
                int comWinNum = App.db.getWinNum(DatabaseManager.identity.computer);
                double manWinRate = 100 * manWinNum * 1.0 / (manWinNum + comWinNum);
                showTile.showInfo("人机对战信息", "玩家胜率：" + ((int)manWinRate).ToString() + "%", "电脑胜率：" + (100 - (int)manWinRate).ToString() + "%");
            }
            // 展示人人对战信息
            else
            {
                int blackWinNum = App.db.getWinNum(DatabaseManager.identity.black);
                int whiteWinNum = App.db.getWinNum(DatabaseManager.identity.white);
                double blackWinRate = 100 * blackWinNum * 1.0 / (blackWinNum + whiteWinNum);
                showTile.showInfo("人人对战信息", "黑棋胜率：" + ((int)blackWinRate).ToString() + "%", "白棋胜率：" + (100 - ((int)blackWinRate)).ToString() + "%");
            }
        }

        // 绘制棋盘
        public void InstallChessboard()
        {
            //定义棋盘背景色
            chessBoard.Background = new SolidColorBrush(Color.FromArgb(255, 255, 147, 15));
            double BoardWid, BoardHei;
            BoardWid = chessBoard.Width;
            BoardHei = chessBoard.Height;
            //控制网格的绘制
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
                    newChess.Width = 26;
                    newChess.Height = 26;
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

        public void PTP_Clicked(object sender, RoutedEventArgs e)
        {
            if (gameStart && (isAIOrNot == true))
            {
                var i = new MessageDialog("正在人机游戏中").ShowAsync();
                return;
            }
            if (!gameStart) resetChess(); // 如果现在没有开始已经有人胜利了就初始化棋盘
            else
            {
                var i = new MessageDialog("正在人人游戏中，如果需要重新开始请点击重新开始按钮").ShowAsync();
            }
            chessState = state.black;
            gameStart = true;
            isAIOrNot = false;
            HintImformation.Text = "黑方请下棋";
            winner = DatabaseManager.identity.none;
        }
        public void PTM_Clicked(object sender, RoutedEventArgs e)
        {
            if (gameStart && (isAIOrNot == false))
            {
                var i = new MessageDialog("正在人人游戏中").ShowAsync();
                return;
            }
            if (!gameStart) resetChess(); // 如果现在没有开始已经有人胜利了就初始化棋盘
            else
            {
                var i = new MessageDialog("正在人机游戏中，如果需要重新开始请点击重新开始按钮").ShowAsync();
            }
            chessState = state.black;
            gameStart = true;
            isAIOrNot = true;
            HintImformation.Text = "";
            winner = DatabaseManager.identity.none;
        }

        //棋盘点击事件
        public void boardClicked(object sender, PointerRoutedEventArgs e)
        {
            if (!gameStart)
            {
                var k = new MessageDialog("请选择模式").ShowAsync();
                return;
            }

            //获取点击位置
            Point chessPosition = e.GetCurrentPoint(chessBoard).Position;
            //新建棋子--绘制椭圆
            Ellipse newChess = new Ellipse();
            newChess.Width = 26;
            newChess.Height = 26;
            getChessRowAndCol(chessPosition);
            if (!setNewChess(newChess))
            {
                //如果下棋失败了，结束整个函数
                return;
            }

            //人人模式
            if (!isAIOrNot)
            {
                state judgeState = judge();
                if (judgeState == state.black)
                {
                    gameStart = false;
                    App.db.addWinNum(DatabaseManager.identity.black);
                    var i = new MessageDialog("黑棋胜利了，恭喜恭喜！").ShowAsync();
                    showWinRate();
                    HintImformation.Text = "黑棋胜利了，恭喜恭喜！";
                    winner = DatabaseManager.identity.black;
                }
                else if (judgeState == state.white)
                {
                    gameStart = false;
                    App.db.addWinNum(DatabaseManager.identity.white);
                    var i = new MessageDialog("白棋胜利了，恭喜恭喜！").ShowAsync();
                    showWinRate();
                    HintImformation.Text = "白棋胜利了，恭喜恭喜！";
                    winner = DatabaseManager.identity.white;
                }
            }
            //人机模式
            else
            {
                state judgeState = judge();
                if (judgeState != state.none)
                {
                    gameStart = false;
                    App.db.addWinNum(DatabaseManager.identity.man);
                    var i = new MessageDialog("你胜过了计算机，恭喜恭喜！").ShowAsync();
                    showWinRate();
                    HintImformation.Text = "你胜过了计算机，恭喜恭喜！";
                    winner = DatabaseManager.identity.man;
                }
                else
                {
                    point AIChessPosition = point.getNextPointByAI(matrix);
                    //新建棋子--绘制椭圆
                    Ellipse newAIChess = new Ellipse();
                    newAIChess.Width = 26;
                    newAIChess.Height = 26;
                    newChess_row = AIChessPosition.x;
                    newChess_col = AIChessPosition.y;
                    setNewChess(newAIChess);
                    judgeState = judge();
                    if (judgeState != state.none)
                    {
                        gameStart = false;
                        App.db.addWinNum(DatabaseManager.identity.computer);
                        var i = new MessageDialog("计算机赢啦，继续加油！").ShowAsync();
                        showWinRate();
                        HintImformation.Text = "计算机赢啦，继续加油！";
                        winner = DatabaseManager.identity.computer;
                    }

                }
            }
        }

        public bool setNewChess(Ellipse newChess)
        {
            if (matrix[newChess_row, newChess_col] == 0)
            {
                //两种情况，白棋还是黑棋
                if (chessState == state.black)
                {
                    newChess.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                    //当前下的是黑棋，黑棋置2
                    matrix[newChess_row, newChess_col] = 2;
                    chessState = state.white;  //改变状态
                    if (!isAIOrNot)
                    {
                        HintImformation.Text = "白方请下棋";
                    }
                    else
                    {
                        HintImformation.Text = "";
                    }
                }
                else
                {
                    newChess.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    //当前下的是白棋，白棋置1
                    matrix[newChess_row, newChess_col] = 1;
                    chessState = state.black;
                    if (!isAIOrNot)
                    {
                        HintImformation.Text = "黑方请下棋";
                    }
                    else
                    {
                        HintImformation.Text = "";
                    }
                }
                //设置棋子的位置
                Canvas.SetLeft(newChess, newChess_col * (chessBoard.Width - 30) / 14 + 5);
                Canvas.SetTop(newChess, newChess_row * (chessBoard.Width - 30) / 14 + 5);
                chessBoard.Children.Add(newChess);
                return true;
            }
            else
            {
                //不能放
                return false;
            }
        }

        public void getChessRowAndCol(Point chessPosition)
        {
            //先计算出取整行
            newChess_row = (int)((chessPosition.Y - 15) / gridWidth);
            //再计算行偏差
            double deviation = (chessPosition.Y - 15) / gridWidth - Math.Truncate((chessPosition.Y - 15) / gridWidth);

            //行偏差大于0.5, 要向下一行
            if (deviation > 0.5)
            {
                newChess_row++;
                newChess_col = (int)((chessPosition.X - 15) / gridWidth);
                deviation = (chessPosition.X - 15) / gridWidth - Math.Truncate((chessPosition.X - 15) / gridWidth);
                //列偏差大于0.5，要向右一行
                if (deviation > 0.5) newChess_col++;
            }
            else
            {
                newChess_col = (int)((chessPosition.X - 15) / gridWidth);
                deviation = (chessPosition.X - 15) / gridWidth - Math.Truncate((chessPosition.X - 15) / gridWidth);
                if (deviation > 0.5) newChess_col++;
            }
        }

        //  重新开始
        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            gameStart = false;
            resetChess();
            HintImformation.Text = "";
            winner = DatabaseManager.identity.none;
        }

        // 初始化棋盘
        private void resetChess()
        {
            chessBoard.Children.Clear();
            InstallChessboard();
            for (int i = 0; i < matrixWidth; i++)
            {
                for (int j = 0; j < matrixWidth; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        // 分享
        private void ShareButton_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += DataTransferManager_DataRequested;
            DataTransferManager.ShowShareUI();
        }

        private async void DataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            //throw new NotImplementedException();
            string textSource;
            // 人机对战
            if (isAIOrNot)
            {
                int manWinNum = App.db.getWinNum(DatabaseManager.identity.man);
                int comWinNum = App.db.getWinNum(DatabaseManager.identity.computer);
                double manWinRate = 100 * manWinNum * 1.0 / (manWinNum + comWinNum);
                textSource = "我正在gamestate的人机大战中，胜率已经高达" + ((int)manWinRate).ToString() + "%，不服来战!";
            }
            // 人人对战
            else
            {
                int blackWinNum = App.db.getWinNum(DatabaseManager.identity.black);
                int whiteWinNum = App.db.getWinNum(DatabaseManager.identity.white);
                double blackWinRate = 100 * blackWinNum * 1.0 / (blackWinNum + whiteWinNum);
                string nowWinner, WinRate;
                if (winner == DatabaseManager.identity.black)
                {
                    nowWinner = "黑棋";
                    WinRate = ((int)blackWinRate).ToString();
                }
                else if (winner == DatabaseManager.identity.white)
                {
                    nowWinner = "白棋";
                    WinRate = (100 - (int)blackWinRate).ToString();
                }
                else if (chessState == state.white)
                {
                    nowWinner = "白棋";
                    WinRate = (100 - (int)blackWinRate).ToString();
                }
                else
                {
                    nowWinner = "黑棋";
                    WinRate = ((int)blackWinRate).ToString();
                }

                textSource = "我正在gamestate的人人对战中，我选的" + nowWinner + "胜率已经高达" + WinRate + "%，不服来战!";
            }
            string textTitle = "共享标题";
            string textDescription = "共享描述";
            DataPackage data = args.Request.Data;
            data.Properties.Title = textTitle;
            data.Properties.Description = textDescription;
            data.SetText(textSource);

            DataRequestDeferral GetFiles = args.Request.GetDeferral();

            try
            {
                StorageFile imageFile = await Package.Current.InstalledLocation.GetFileAsync("Assets\\images.jpg");
                data.Properties.Thumbnail = RandomAccessStreamReference.CreateFromFile(imageFile);
                data.SetBitmap(RandomAccessStreamReference.CreateFromFile(imageFile));
            }
            finally
            {
                GetFiles.Complete();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //如果棋局并没有结束
            if (winner == DatabaseManager.identity.none)
            {
                var i = new MessageDialog("棋局还没有结束").ShowAsync();
                return;
            }
            //保存在数据库以及App里的ViewModel
            App.db.storeGame(matrix, DateTime.Now.ToString(), "", winner);
            string Winner = "";
            switch (winner)
            {
                case DatabaseManager.identity.black: Winner = "黑方"; break;
                case DatabaseManager.identity.computer: Winner = "电脑"; break;
                case DatabaseManager.identity.man: Winner = "人"; break;
                case DatabaseManager.identity.white: Winner = "白方"; break;
            }
            App.viewModel.AllItems.Add(new TodoItem(DateTime.Now.ToString(), "", Winner, matrix));
            var j = new MessageDialog("棋局保存成功").ShowAsync();
        }



        //接口说明：返回三种状态state.black代表黑赢，state.white代表白赢，state.none代表没有
        private state judge()
        {
            //无需全棋盘扫描 五子棋胜利必然与最后一子落下相关
            //以放下的棋子为原点，向八个方向分别检测
            int i;
            int[] num = new int[4] { 1, 1, 1, 1 }; // 计算横竖斜斜的方向的子数目, 刚下那个子算一个
            //向右判断同行不同列
            for (i = 1; i <= 4 && newChess_col + i >= 0 && newChess_col + i < matrixWidth && matrix[newChess_row, newChess_col] == matrix[newChess_row, newChess_col + i]; i++)
            {
                num[0]++;
            }
            //向左判断同行不同列
            for (i = 1; i <= 4 && newChess_col - i >= 0 && newChess_col - i < matrixWidth && matrix[newChess_row, newChess_col] == matrix[newChess_row, newChess_col - i]; i++)
            {
                num[0]++;
            }

            //向下判断同列不同行
            for (i = 1; i <= 4 && newChess_row + i >= 0 && newChess_row + i < matrixWidth && matrix[newChess_row, newChess_col] == matrix[newChess_row + i, newChess_col]; i++)
            {
                num[1]++;
            }
            //向上判断同列不同行
            for (i = 1; i <= 4 && newChess_row - i >= 0 && newChess_row - i < matrixWidth && matrix[newChess_row, newChess_col] == matrix[newChess_row - i, newChess_col]; i++)
            {
                num[1]++;
            }

            //向右上判断
            for (i = 1; i <= 4 && newChess_row + i >= 0 && newChess_row + i < matrixWidth && newChess_col + i >= 0 && newChess_col + i < matrixWidth && matrix[newChess_row, newChess_col] == matrix[newChess_row + i, newChess_col + i]; i++)
            {
                num[2]++;
            }
            //向左下判断
            for (i = 1; i <= 4 && newChess_row - i >= 0 && newChess_row - i < matrixWidth && newChess_col - i >= 0 && newChess_col - i < matrixWidth && matrix[newChess_row, newChess_col] == matrix[newChess_row - i, newChess_col - i]; i++)
            {
                num[2]++;
            }

            //向左上判断
            for (i = 1; i <= 4 && newChess_row - i >= 0 && newChess_row - i < matrixWidth && newChess_col + i >= 0 && newChess_col + i < matrixWidth && matrix[newChess_row, newChess_col] == matrix[newChess_row - i, newChess_col + i]; i++)
            {
                num[3]++;
            }

            //向右下判断
            for (i = 1; i <= 4 && newChess_row + i >= 0 && newChess_row + i < matrixWidth && newChess_col - i >= 0 && newChess_col - i < matrixWidth && matrix[newChess_row, newChess_col] == matrix[newChess_row + i, newChess_col - i]; i++)
            {
                num[3]++;
            }

            for (i = 0; i < 4; i++)
            {
                if (num[i] >= 5) // 总共五个以上就可以胜利了
                {
                    if (chessState == state.white)
                        return state.black;
                    else
                        return state.white;
                }
            }

            return state.none;
        }



    }

}