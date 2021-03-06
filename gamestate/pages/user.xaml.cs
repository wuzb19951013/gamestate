﻿using System;
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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace gamestate.pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class user : Page
    {
        public user()
        {
            this.InitializeComponent();
        }
        private void SaveGo_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SavePage));
        }
        private void GoScore_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GoBangScore));
        }
    }
}
