namespace gamestate
{
    public class TodoItem : ViewModelBase
    {
        // 保存时间
        private string Data;
        public string data { get { return this.Data; } set { Set(ref Data, value); } }

        // 玩家评论
        private string Description;
        public string description { get { return this.Description; } set { Set(ref Description, value); } }

        private string Winner;
        public string winner { get { return this.Winner; } set { Set(ref Winner, value); } }

        private int[,] SaveMatrix;
        public int[,] saveMatrix { get { return this.SaveMatrix; } set { Set(ref SaveMatrix, value); } }
        public TodoItem(string data = "2016-5-13", string description = "", string winner = "", int[,] saveMatrix = null)
        {
            this.data = data;
            this.description = description;
            this.saveMatrix = saveMatrix;
            this.winner = winner;
            if (this.saveMatrix == null)
            {
                this.saveMatrix = new int[GoBang.matrixWidth, GoBang.matrixWidth];
                for (int i = 0; i < GoBang.matrixWidth; i++)
                {
                    for (int j = 0; j < GoBang.matrixWidth; j++)
                    {
                        this.saveMatrix[i, j] = 0;
                    }
                }
            }
        }
    }
}
