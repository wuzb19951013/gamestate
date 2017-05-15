using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamestate
{
    public class ViewModel
    {
        private ObservableCollection<TodoItem> allItems = new ObservableCollection<TodoItem>();
        public ObservableCollection<TodoItem> AllItems { set { this.allItems = value; } get { return this.allItems; } }


        public ViewModel()
        {
            // 加入两个用来测试的item
            //this.allItems.Add(new TodoItem(DateTime.Now.ToString(), "", null));
            //this.allItems.Add(new TodoItem(DateTime.Now.ToString(), "", null));
        }

        // 用于更新item
        public void UpdateTodoItem(string time, string newDescription)
        {
            for (int i = 0; i < allItems.Count; i++)
            {
                if (allItems[i].data == time)
                {
                    allItems[i].description = newDescription;
                    return;
                }
            }
        }

        public void DeleteTodoItem(string time)
        {
            for (int i = 0; i < allItems.Count; i++)
            {
                if (allItems[i].data == time)
                {
                    allItems.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
