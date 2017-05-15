using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace gamestate.pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    /// 

    public sealed partial class webgameview : Page
    {
        private string src;
        private Frame rootFrame;
        public webgameview()
        {
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;
            //设置 back 事件
            SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            src = (string)e.Parameter;
        }
        private void App_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (rootFrame.CanGoBack)
            {
                Window.Current.Close();
                rootFrame.GoBack();
            }
        }
    }
}
