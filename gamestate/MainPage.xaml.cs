using gamestate.classstate;
using gamestate.pages;
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace gamestate
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            User2.instance.CreditUpdated += Instance_CreditUpdated;
            MyFrame.Navigated += OnNavigated;
            SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
            Online.IsSelected = true;
        }
        private void Instance_CreditUpdated(object sender, EventArgs e)
        {
            TitleTextBlock.Text = User2.instance.Credit;
        }
        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            if (MyFrame.CanGoBack)
            {
                // Show UI in title bar if opted-in and in-app backstack is not empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Visible;
            }
            else
            {
                // Remove the UI from the title bar if in-app back stack is empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Collapsed;
            }
        }

        private void App_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (MyFrame.CanGoBack)
            {
                MyFrame.GoBack();
                // 设置选中的 item
                if (MyFrame.SourcePageType == typeof(local))
                {
                    Local.IsSelected = true;
                }
                else if (MyFrame.SourcePageType == typeof(online))
                {
                    Online.IsSelected = true;
                }
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }


        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Online.IsSelected)
            {
                TitleTextBlock.Text = "在线游戏";
                NavigateHamburgerMenu(MyFrame, typeof(online));
            }
            else if (Local.IsSelected)
            {
                TitleTextBlock.Text = "离线游戏";
                NavigateHamburgerMenu(MyFrame, typeof(local));
            }
            else if (Collection.IsSelected)
            {
                TitleTextBlock.Text = "游戏收藏";
                NavigateHamburgerMenu(MyFrame, typeof(About));
            }
            else
            {
            }
        }
        private void NavigateHamburgerMenu(Frame frame, Type pageType)
        {
            // 如果跳转的 page 和当前 page 不同，才跳转
            if (frame.CurrentSourcePageType != pageType)
            {
                frame.Navigate(pageType);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Online.IsSelected = true;
        }

        private void setting_Click(object sender, RoutedEventArgs e)
        {
            Mysplitview2.IsPaneOpen = !Mysplitview2.IsPaneOpen;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (blue.IsChecked == true)
            {
                coloratxt.Text = Colors.LightBlue.R + "," + Colors.LightBlue.G + "," + Colors.LightBlue.B;
            }
            else if (theme.IsChecked == true)
            {
                coloratxt.Text = ((Color)Application.Current.Resources["SystemAccentColor"]).R
                    + "," + ((Color)Application.Current.Resources["SystemAccentColor"]).G
                    + "," + ((Color)Application.Current.Resources["SystemAccentColor"]).B;
            }
            else if (orange.IsChecked == true)
            {
                coloratxt.Text = Colors.Orange.R + "," + Colors.Orange.G + "," + Colors.Orange.B;
            }
            else if (LightGray.IsChecked == true)
            {
                coloratxt.Text = Colors.LightGray.R + "," + Colors.LightGray.G + "," + Colors.LightGray.B;
            }

            if (dark.IsChecked == true)
            {
                colorbtxt.Text = Colors.Gray.R + "," + Colors.Gray.G + "," + Colors.Gray.B;
            }
            else if (light.IsChecked == true)
            {
                colorbtxt.Text = Colors.White.R + "," + Colors.White.G + "," + Colors.White.B;

            }

            if (white.IsChecked == true)
            {
                colorctxt.Text = "255,255,255";
            }
            else if (black.IsChecked == true)
            {
                colorctxt.Text = "0,0,0";
            }

            string temp = coloratxt.Text;
            string[] rgb = temp.Split(',');
            byte r, g, b;
            try
            {
                r = byte.Parse(rgb[0]);
                g = byte.Parse(rgb[1]);
                b = byte.Parse(rgb[2]);
            }
            catch (Exception) { r = 0; g = 255; b = 0; coloratxt.Text = "0,255,0"; }
            if (r > 255 || r < 0 || g > 255 || g < 0 || b > 255 || b < 0) { r = 0; g = 255; b = 0; coloratxt.Text = "0,255,0"; }
            (Application.Current.Resources["accent"] as SolidColorBrush).Color = Color.FromArgb(255, r, g, b);

            temp = colorbtxt.Text;
            rgb = temp.Split(',');
            try
            {
                r = byte.Parse(rgb[0]);
                g = byte.Parse(rgb[1]);
                b = byte.Parse(rgb[2]);
            }
            catch (Exception) { r = 0; g = 0; b = 0; colorbtxt.Text = "0,0,0"; }
            if (r > 255 || r < 0 || g > 255 || g < 0 || b > 255 || b < 0) { r = 0; g = 0; b = 0; colorbtxt.Text = "0,0,0"; }
            (Application.Current.Resources["bg"] as SolidColorBrush).Color = Color.FromArgb(255, r, g, b);

            temp = colorctxt.Text;
            rgb = temp.Split(',');
            try
            {
                r = byte.Parse(rgb[0]);
                g = byte.Parse(rgb[1]);
                b = byte.Parse(rgb[2]);
            }
            catch (Exception) { r = 0; g = 0; b = 0; colorctxt.Text = "0,0,0"; }
            if (r > 255 || r < 0 || g > 255 || g < 0 || b > 255 || b < 0) { r = 0; g = 0; b = 0; colorctxt.Text = "0,0,0"; }
            (Application.Current.Resources["txt"] as SolidColorBrush).Color = Color.FromArgb(255, r, g, b);

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
                coloratxt.Text = (Application.Current.Resources["accent"] as SolidColorBrush).Color.R
                    + "," + (Application.Current.Resources["accent"] as SolidColorBrush).Color.G
                    + "," + (Application.Current.Resources["accent"] as SolidColorBrush).Color.B;
                colorbtxt.Text = (Application.Current.Resources["bg"] as SolidColorBrush).Color.R
                    + "," + (Application.Current.Resources["bg"] as SolidColorBrush).Color.G
                    + "," + (Application.Current.Resources["bg"] as SolidColorBrush).Color.B;
                colorctxt.Text = (Application.Current.Resources["txt"] as SolidColorBrush).Color.R
                    + "," + (Application.Current.Resources["txt"] as SolidColorBrush).Color.G
                    + "," + (Application.Current.Resources["txt"] as SolidColorBrush).Color.B;
            }
            base.OnNavigatedTo(e);
        }

        private void txt_LostFocus(object sender, RoutedEventArgs e) { RadioButton_Click(sender, e); }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(SearchPage));
        }

        private void share_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += DataTransferManager_DataRequested;
            DataTransferManager.ShowShareUI();
        }

        private async void DataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            string textSource;
            textSource = "我正在gamestate中参加游戏，一起来玩吧";
            string textTitle = "一起来玩小游戏呀！";
            string textDescription = "最新潮最好玩的小游戏";
            DataPackage data = args.Request.Data;
            data.Properties.Title = textTitle;
            data.Properties.Description = textDescription;
            data.SetText(textSource);
            DataRequestDeferral GetFiles = args.Request.GetDeferral();
            try
            {
                StorageFile imageFile = await Package.Current.InstalledLocation.GetFileAsync("Assets\\99.png");
                data.Properties.Thumbnail = RandomAccessStreamReference.CreateFromFile(imageFile);
                data.SetBitmap(RandomAccessStreamReference.CreateFromFile(imageFile));
            }
            finally
            {
                GetFiles.Complete();
            }
        }

        private void Page_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            classstate.user.instance.Keycode = e.OriginalKey;
        }

        private void online_Share(object sender, RoutedEventArgs e)
        {
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += DataTransferManager_DataRequested;
            DataTransferManager.ShowShareUI();
        }
    }
}
