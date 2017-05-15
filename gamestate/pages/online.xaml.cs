using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using gamestate.models;
using Windows.UI.Xaml.Media.Imaging;


// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace gamestate.pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class online : Page
    {
        private List<Game> Games;
        private List<Game> Games2;
        private List<Game> Games3;
        private List<Game> Games4;
        private List<Game> Games5;
        private List<Game> Games6;
        public online()
        {
            this.InitializeComponent();
            rtb.RatingValue = 5;
            Games = Gamemanager.GetGames();
            Games2 = Gamemanager2.GetGames();
            Games3 = Gamemanager3.GetGames();
            Games4 = Gamemanager4.GetGames();
            Games5 = Gamemanager5.GetGames();
            Games6 = Gamemanager6.GetGames();
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var game = (Game)e.ClickedItem;
            this.Frame.Navigate(typeof(webgameview), game.Sourse);
        }

        private void GridItem_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // 根据窗口大小动态调整 item 长宽
            var grid = (ItemsWrapGrid)sender;

            if (Window.Current.Bounds.Width < 700)
            {
                grid.ItemWidth = e.NewSize.Width / 4;
            }
            else if (Window.Current.Bounds.Width >= 700 && Window.Current.Bounds.Width <= 1056)
            {
                grid.ItemWidth = e.NewSize.Width / 6;
            }
            else if (Window.Current.Bounds.Width > 1056)
            {
                grid.ItemWidth = e.NewSize.Width / 8;
            }
            grid.ItemHeight = grid.ItemWidth;
        }

        private void online_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void GridItem_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            var grid = (ItemsWrapGrid)sender;

            if (Window.Current.Bounds.Width < 700)
            {
                grid.ItemWidth = e.NewSize.Width / 2;
            }
            else if (Window.Current.Bounds.Width >= 700 && Window.Current.Bounds.Width <= 1056)
            {
                grid.ItemWidth = e.NewSize.Width / 3;
            }
            else if (Window.Current.Bounds.Width > 1056)
            {
                grid.ItemWidth = e.NewSize.Width / 4;
            }
            grid.ItemHeight = grid.ItemWidth * 9 / 16;
        }



        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
            string source = "http://www.pika78.com/?newurl=aHR0cDovL3N6aG9uZy40Mzk5LmNvbS80Mzk5c3dmL3VwbG9hZF9zd2YvZnRwMjIvZ2FtZWh3cS8yMDE3MDQxMy8wNC9pbmRleC5odG1s";
            this.Frame.Navigate(typeof(webgameview), source);
        }

        private void Grid_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            string source = "http://yx.h5uc.com/zhuazhunayinfu/";
            this.Frame.Navigate(typeof(webgameview), source);
        }

        private void Grid_Tapped_2(object sender, TappedRoutedEventArgs e)
        {
            string source = "http://yx.h5uc.com/zhizhuwangbuchanxian/";
            this.Frame.Navigate(typeof(webgameview), source);
        }

        private void Grid_Tapped_3(object sender, TappedRoutedEventArgs e)
        {
            string source = "http://yx.h5uc.com/dangshexiaotou/";
            this.Frame.Navigate(typeof(webgameview), source);
        }

        private void FlipView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rtb.RatingValue = 5;
        }

        private void Grid_Tapped_4(object sender, TappedRoutedEventArgs e)
        {
            var transform = rementuijian.TransformToVisual((UIElement)myscrollview.Content);
            Point absolutePosition = transform.TransformPoint(new Point(0, 0));
            myscrollview.ChangeView(null, absolutePosition.Y, null, false);
        }

        private void Grid_Tapped_5(object sender, TappedRoutedEventArgs e)
        {
            var transform = xinpinchangxian.TransformToVisual((UIElement)myscrollview.Content);
            Point absolutePosition = transform.TransformPoint(new Point(0, 0));
            myscrollview.ChangeView(null, absolutePosition.Y, null, false);
        }

        private void Grid_Tapped_6(object sender, TappedRoutedEventArgs e)
        {
            var transform = yizhiyule.TransformToVisual((UIElement)myscrollview.Content);
            Point absolutePosition = transform.TransformPoint(new Point(0, 0));
            myscrollview.ChangeView(null, absolutePosition.Y, null, false);
        }

        private void Grid_Tapped_7(object sender, TappedRoutedEventArgs e)
        {
            var transform = wunaodanji.TransformToVisual((UIElement)myscrollview.Content);
            Point absolutePosition = transform.TransformPoint(new Point(0, 0));
            myscrollview.ChangeView(null, absolutePosition.Y, null, false);
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var grid = (Grid)sender;
            grid.Height = grid.Width * 9 / 16;
        }

        private void MyFlipView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var grid = (FlipView)sender;
            grid.Height = Window.Current.Bounds.Width * 27 / 80;
        }

        private void yinyue_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var grid = (Grid)sender;
            grid.Height = Window.Current.Bounds.Width * 27 / 80;
        }

        private void MyFlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        string GameUrl = "http://yx.h5uc.com/senlinlixianji/";
        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(webgameview), GameUrl);
        }

        private void Image_Loaded_0(object sender, RoutedEventArgs e)
        {
            GameName.Text = "森林历险记";
            Intro.Text = "森林历险记，要小心不能碰到黑猫，否则会被女巫囚禁！\n"+ "游戏玩法相对比较简单，玩家主要通过点击屏幕或拖动、滑动屏幕来进行游戏。部分游戏在PC端，请尝试使用键盘的方向键，空格键，或者WSAD按键进行操作。手机用户请直接在屏幕上进行手势操作。";
            GameUrl = "http://yx.h5uc.com/senlinlixianji/";
        }

        private void Image_Loaded_1(object sender, RoutedEventArgs e)
        {
            GameName.Text = "怪兽糖糖冲击";
            Intro.Text = " 可爱的糖果小怪物又来了！这次还是需要你的帮助来吃掉不同的糖果！操作方式非常简单，在糖果处点击，小怪就会马上飞过去吃掉糖果。";
            GameUrl = "http://yx.h5uc.com/guaisoutangtangchongji/";
        }

        private void Image_Loaded_2(object sender, RoutedEventArgs e)
        {
            GameName.Text = "极限越野7";
            Intro.Text = "单纯的水上汽艇，让你爽个够!单纯的水上汽艇，让你爽个够!这一部又更新了不少的赛道和关卡，道具也是多了不少，肯定会给大家带来一种全新的感觉!";
            GameUrl = "http://yx.h5uc.com/UphillRush/";
        }

        private void Image_Loaded_3(object sender, RoutedEventArgs e)
        {
            GameName.Text = "奇妙方块";
            Intro.Text = "奇妙的小方块，堆叠起来不倒就赢！";
            GameUrl = "http://yx.h5uc.com/qimiaodefangkuai/";
        }

        private void Image_Loaded_4(object sender, RoutedEventArgs e)
        {
            GameName.Text = "冰上滚动2";
            Intro.Text = "点一下冰球或雪花就会跳起来，想办法吃到星星，并且不能碰到便便哦！通关秘诀就是一直点点点！直到到达指定的地点！";
            GameUrl = "http://yx.h5uc.com/bingshangundong/";

        }
    }
}
