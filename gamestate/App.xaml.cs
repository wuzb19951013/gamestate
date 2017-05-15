using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Windows.Storage;
using Windows.UI;
using System.Collections.ObjectModel;
using gamestate.pages;
using gamestate.models;
using System.Collections.Generic;

namespace gamestate
{
    sealed partial class App : Application
    {
        public static DatabaseManager db;
        public static ViewModel viewModel;
        public App()
        {
            //001
            
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            db = new DatabaseManager();
            viewModel = new ViewModel();
            InitializeViewModel();
        }

        // 002
        private void InitializeViewModel()
        {
            ObservableCollection<string[]> dataFromDatabase = db.getGame("");
            string[] data;
            int[,] saveMatrix;
            string time, description, winner;
            for (int i = 0; i < dataFromDatabase.Count; i++)
            {
                data = dataFromDatabase[i];
                saveMatrix = db.convertToArray(data[0]);
                description = data[1];
                winner = data[2];
                time = data[3];
                viewModel.AllItems.Add(new TodoItem(time, description, winner, saveMatrix));
            }
        }


        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif
            Frame rootFrame = Window.Current.Content as Frame;

            // 不要在窗口已包含内容时重复应用程序初始化，
            // 只需确保窗口处于活动状态
            if (rootFrame == null)
            {
                // 创建要充当导航上下文的框架，并导航到第一页
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;
                //  Display an extended splash screen if app was not previously running.
                if (e.PreviousExecutionState != ApplicationExecutionState.Running)
                {
                    bool loadState = (e.PreviousExecutionState == ApplicationExecutionState.Terminated);
                    LoadingPage LoadingPage = new LoadingPage(e.SplashScreen, loadState);
                    rootFrame.Content = LoadingPage;
                    Window.Current.Content = rootFrame;
                }
                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //003
                    GoBang.gameStart = (bool)ApplicationData.Current.LocalSettings.Values["gameStart"];
                    GoBang.isAIOrNot = (bool)ApplicationData.Current.LocalSettings.Values["isAIOrNot"];
                }
                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated || e.PreviousExecutionState == ApplicationExecutionState.ClosedByUser)
                {
                    //TODO: 从之前挂起的应用程序加载状态
                    UserData.Load();
                }
                // 将框架放在当前窗口中
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // 当导航堆栈尚未还原时，导航到第一页，
                    // 并通过将所需信息作为导航参数传入来配置
                    // 参数
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // 确保当前窗口处于活动状态
                Window.Current.Activate();
                //004
                Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;

                //跳转返回
                rootFrame.Navigated += (s, a) =>
                {
                    if (rootFrame.CanGoBack)
                    {
                        // Setting this visible is ignored on Mobile and when in tablet mode!     
                        Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = Windows.UI.Core.AppViewBackButtonVisibility.Visible;
                    }
                    else
                    {
                        Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = Windows.UI.Core.AppViewBackButtonVisibility.Collapsed;
                    }
                };
            }
        }

        /// <summary>
        /// 导航到特定页失败时调用
        /// </summary>
        ///<param name="sender">导航失败的框架</param>
        ///<param name="e">有关导航失败的详细信息</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// 在将要挂起应用程序执行时调用。  在不知道应用程序
        /// 无需知道应用程序会被终止还是会恢复，
        /// 并让内存内容保持不变。
        /// </summary>
        /// <param name="sender">挂起的请求的源。</param>
        /// <param name="e">有关挂起请求的详细信息。</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: 保存应用程序状态并停止任何后台活动
            //005
            ApplicationData.Current.LocalSettings.Values["gameStart"] = GoBang.gameStart;
            ApplicationData.Current.LocalSettings.Values["isAIOrNot"] = GoBang.isAIOrNot;
            if (GoBang.gameStart)
            {
                db.storeData(GoBang.matrix);
            }
            deferral.Complete();

            UserData.Save();
        }
        //006
        private void OnBackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
        {
            
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
                return;
            
            // Navigate back if possible, and if the event has not 
            // already been handled .
            if (rootFrame.CanGoBack && e.Handled == false)
            {
                e.Handled = true;
                Window.Current.Close();
                rootFrame.GoBack();
            }
        }
        public class UserData
        {
            private static UserData _userData = null;
            static UserData() { _userData = new UserData(); }
            public static UserData CurrentInstance { get { return _userData; } }

            string score = "0", best = "0"; int[,] num = new int[4, 4];
            public string Score { get { return score; } set { score = value; } }
            public string Best { get { return best; } set { best = value; } }
            public int[,] Num { get { return num; } set { num = value; } }

            byte[,] accent = new byte[2, 4];
            public byte[,] AccentAndBg { get { return accent; } set { accent = value; } }
            public int Nth { get; set; }
            //收藏的游戏网址
            public List<Game> Collections = new List<Game> { };
            string[,] game_url = new string[10, 10];
            string[,] title = new string[10, 10];
            string[,] cover = new string[10, 10];
            public string[,] Urls { get { return game_url; } set { game_url = value; } }

            public string[,] Covers { get { return cover; } set { cover = value; } }

            public string[,] Titles { get { return title; } set { title = value; } }
            public static void Load()
            {
                Debug.WriteLine("正加载数据...");
                var rs = ApplicationData.Current.RoamingSettings;
                object v = null;
                if (rs.Values.TryGetValue("score", out v)) { CurrentInstance.Score = (string)v; } else { CurrentInstance.Score = "0"; }
                if (rs.Values.TryGetValue("best", out v)) { CurrentInstance.Best = (string)v; } else { CurrentInstance.Best = "0"; }
                if (rs.Values.TryGetValue("nth", out v)) { CurrentInstance.Nth = (int)v; } else { CurrentInstance.Nth = 0; }
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (rs.Values.TryGetValue(i + "" + j, out v)) { CurrentInstance.Num[i, j] = (int)v; }
                        else { CurrentInstance.Num[i, j] = 0; }
                        if (i < 2)
                        {
                            if (rs.Values.TryGetValue(i + "a" + j, out v)) { CurrentInstance.AccentAndBg[i, j] = (byte)v; }

                        }
                    }
                }//for

              (Current.Resources["accent"] as SolidColorBrush).Color = Color.FromArgb(
                    CurrentInstance.AccentAndBg[0, 0],
                    CurrentInstance.AccentAndBg[0, 1],
                    CurrentInstance.AccentAndBg[0, 2],
                    CurrentInstance.AccentAndBg[0, 3]);
                (Current.Resources["bg"] as SolidColorBrush).Color = Color.FromArgb(
                    CurrentInstance.AccentAndBg[1, 0],
                    CurrentInstance.AccentAndBg[1, 1],
                    CurrentInstance.AccentAndBg[1, 2],
                    CurrentInstance.AccentAndBg[1, 3]);

                if (!rs.Values.TryGetValue("0a0", out v))
                {
                    //设置为系统主题色的方法
                    //http://stackoverflow.com/questions/12647401/applicationpagebackgroundthemebrush-not-working
                    (Current.Resources["accent"] as SolidColorBrush).Color = (Color)Current.Resources["SystemAccentColor"];
                    (Current.Resources["accent"] as SolidColorBrush).Color = Colors.Gray;
                }

                byte txtr = 0, txtg = 0, txtb = 0;
                if (rs.Values.TryGetValue("txtr", out v)) { txtr = (byte)v; }
                if (rs.Values.TryGetValue("txtg", out v)) { txtg = (byte)v; }
                if (rs.Values.TryGetValue("txtb", out v)) { txtb = (byte)v; }
                (Current.Resources["txt"] as SolidColorBrush).Color = Color.FromArgb(255, txtr, txtg, txtb);

            }//load

            public static void Save()
            {
                Debug.WriteLine("正保存数据");
                var rs = ApplicationData.Current.RoamingSettings;
                rs.Values["score"] = CurrentInstance.Score;
                rs.Values["best"] = CurrentInstance.best;
                CurrentInstance.AccentAndBg[0, 0] = (Current.Resources["accent"] as SolidColorBrush).Color.A;
                CurrentInstance.AccentAndBg[0, 1] = (Current.Resources["accent"] as SolidColorBrush).Color.R;
                CurrentInstance.AccentAndBg[0, 2] = (Current.Resources["accent"] as SolidColorBrush).Color.G;
                CurrentInstance.AccentAndBg[0, 3] = (Current.Resources["accent"] as SolidColorBrush).Color.B;
                CurrentInstance.AccentAndBg[1, 0] = (Current.Resources["bg"] as SolidColorBrush).Color.A;
                CurrentInstance.AccentAndBg[1, 1] = (Current.Resources["bg"] as SolidColorBrush).Color.R;
                CurrentInstance.AccentAndBg[1, 2] = (Current.Resources["bg"] as SolidColorBrush).Color.G;
                CurrentInstance.AccentAndBg[1, 3] = (Current.Resources["bg"] as SolidColorBrush).Color.B;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        rs.Values[i + "" + j] = CurrentInstance.Num[i, j];
                        if (i < 2)
                        {
                            rs.Values[i + "a" + j] = CurrentInstance.AccentAndBg[i, j];
                        }
                    }
                }//for
                rs.Values["txtr"] = (Current.Resources["txt"] as SolidColorBrush).Color.R;
                rs.Values["txtg"] = (Current.Resources["txt"] as SolidColorBrush).Color.G;
                rs.Values["txtb"] = (Current.Resources["txt"] as SolidColorBrush).Color.B;
                rs.Values["nth"] = CurrentInstance.Nth;
            }//save
        }//class

    }
}
