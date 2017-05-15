using gamestate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace gamestate
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SavePage : Page
    {
        public ViewModel viewModel;
        public TodoItem currentItem; // 保存点击到的item
        public SavePage()
        {
            this.InitializeComponent();
            viewModel = App.viewModel;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            TodoItem item = (TodoItem)(e.ClickedItem);
            currentItem = item;
            description.Text = item.description;
        }

        //重写导航函数，也许以后有用
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            return;
        }

        //  前往ViewChess查看棋局
        private void ViewChess_Click(object sender, RoutedEventArgs e)
        {
            var item = ((MenuFlyoutItem)e.OriginalSource).DataContext as TodoItem;
            Frame.Navigate(typeof(ViewChess), item.saveMatrix);
        }

        // 确认按钮
        private void desButton_Click(object sender, RoutedEventArgs e)
        {
            string newDescription;
            if (currentItem != null)
            {
                newDescription = description.Text;
                App.viewModel.UpdateTodoItem(currentItem.data, newDescription);
                App.db.editComment(currentItem.data, newDescription);
                description.Text = "";
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var item = ((MenuFlyoutItem)e.OriginalSource).DataContext as TodoItem;
            App.db.deleteGame(item.data);
            App.viewModel.DeleteTodoItem(item.data);
        }
    }
}
