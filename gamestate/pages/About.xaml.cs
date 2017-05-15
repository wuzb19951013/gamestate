using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace gamestate.pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class About : Page
    {
        public string s1 = "", s2 = "", s3 = "", s4 = "", s5 = "";
        public string p1 = "http://acmoon.top/666666666", p2 = "http://acmoon.top/666666666", p3 = "http://acmoon.top/666666666", p4 = "http://acmoon.top/666666666", p5 = "http://acmoon.top/666666666";
        public About()
        {
            this.InitializeComponent();
            App.UserData.CurrentInstance.Titles[0, 0] = "hahahahahahahahaha";
            if (App.UserData.CurrentInstance.Collections.Count == 0)
            {
                return;
            }
            if (App.UserData.CurrentInstance.Collections[0] != null)
            {
                s1 = App.UserData.CurrentInstance.Collections[0].Title;
                p1 = App.UserData.CurrentInstance.Collections[0].Sourse;
                i1.Source = new BitmapImage(new Uri(App.UserData.CurrentInstance.Collections[0].Coverimage));
            }
            if (App.UserData.CurrentInstance.Collections.Count == 1)
            {
                return;
            }
            if (App.UserData.CurrentInstance.Collections[1] != null)
            {
                s2 = App.UserData.CurrentInstance.Collections[1].Title;
                p2 = App.UserData.CurrentInstance.Collections[1].Sourse;

                i2.Source = new BitmapImage(new Uri(App.UserData.CurrentInstance.Collections[1].Coverimage));
            }
            if (App.UserData.CurrentInstance.Collections.Count == 2)
            {
                return;
            }
            if (App.UserData.CurrentInstance.Collections[2] != null)
            {
                s3 = App.UserData.CurrentInstance.Collections[2].Title;
                p3 = App.UserData.CurrentInstance.Collections[2].Sourse;
                i3.Source = new BitmapImage(new Uri(App.UserData.CurrentInstance.Collections[2].Coverimage));
            }
            if (App.UserData.CurrentInstance.Collections.Count == 3)
            {
                return;
            }
            if (App.UserData.CurrentInstance.Collections[3] != null)
            {
                s4 = App.UserData.CurrentInstance.Collections[3].Title;
                p4 = App.UserData.CurrentInstance.Collections[3].Sourse;
                i4.Source = new BitmapImage(new Uri(App.UserData.CurrentInstance.Collections[3].Coverimage));
            }
            if (App.UserData.CurrentInstance.Collections.Count == 4)
            {
                return;
            }
            if (App.UserData.CurrentInstance.Collections[4] != null)
            {
                s5 = App.UserData.CurrentInstance.Collections[4].Title;
                p5 = App.UserData.CurrentInstance.Collections[4].Sourse;
                i5.Source = new BitmapImage(new Uri(App.UserData.CurrentInstance.Collections[4].Coverimage));
            }
        }
        public void GetCollections()
        {
        }

        private void i1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            title.Text = s1;
        }

        private void play(object sender, RoutedEventArgs e)
        {
            if(title.Text == s1)
            {
                this.Frame.Navigate(typeof(webgameview), p1);
            }
            else if (title.Text == s2)
            {
                this.Frame.Navigate(typeof(webgameview), p2);
            }
            else if (title.Text == s3)
            {
                this.Frame.Navigate(typeof(webgameview), p3);
            }
            else if (title.Text == s4)
            {
                this.Frame.Navigate(typeof(webgameview), p4);
            }
            else
            {
                this.Frame.Navigate(typeof(webgameview), p5);
            }
        }
        private void share(object sender, RoutedEventArgs e)
        {
            //分享游戏平台
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += DataTransferManager_DataRequested;
            DataTransferManager.ShowShareUI();
        }
        private async void DataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            string textSource;
            textSource = "我正在Game State中参加游戏，一起来玩吧";
            string textTitle = "一起来玩小游戏呀！";
            string textDescription = title.Text;
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
        private void i2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            title.Text = s2;

        }

        private void i3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            title.Text = s3;

        }

        private void i4_Tapped(object sender, TappedRoutedEventArgs e)
        {
            title.Text = s4;

        }

        private void i5_Tapped(object sender, TappedRoutedEventArgs e)
        {
            title.Text = s5;

        }
    }
}
