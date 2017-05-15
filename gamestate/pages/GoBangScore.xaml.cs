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
using gamestate;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace gamestate.pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class GoBangScore : Page
    {
        public GoBangScore()
        {
            this.InitializeComponent();
            loadInfo();
        }
        // 载入对战信息 
        public void loadInfo()
        {
            winNumOfBlack.Text =  App.db.getWinNum(DatabaseManager.identity.black).ToString();
            winNumOfWhite.Text = App.db.getWinNum(DatabaseManager.identity.white).ToString();
            winNumOfMan.Text = App.db.getWinNum(DatabaseManager.identity.man).ToString();
            winNumOfComputer.Text = App.db.getWinNum(DatabaseManager.identity.computer).ToString();
        }
    }
}
