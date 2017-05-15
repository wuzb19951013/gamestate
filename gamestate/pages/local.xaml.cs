using gamestate.classstate;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace gamestate.pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class local : Page
    {
        public local()
        {
            this.InitializeComponent();
        }
        

        private void StartGo_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GoBang));
            User2.instance.Credit = "五子棋";

        }


        private void SaveGo_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SavePage));
        }
        private void GoScore_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GoBangScore));
        }
        private void Start2048_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(the2048));
            User2.instance.Credit = "2048";
        }
    }
}
