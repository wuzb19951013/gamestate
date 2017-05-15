namespace gamestate
{
    public class point
    {
        public int x, y;

        public point(int v1, int v2)
        {
            this.x = v1;
            this.y = v2;
        }

        static public point getNextPointByAI(int[,] arr)
        {
            return AI(arr);
        }

        static private int size = 14;

        static private point AI(int[,] points)
        {
            int i, j;
            int x, y;
            int x1 = 0, x2 = 0, y1 = 0, y2 = 0;
            int[,,,] qiju = new int[size, size, 8, 2];
            int[,] a1 = new int[size, size], a2 = new int[size, size], oldp = new int[size, size];
            // current state quick save  
            for (i = 0; i < size; i++)
                for (j = 0; j < size; j++)
                {
                    oldp[i, j] = points[i, j];
                }
            FillMatrix(qiju, 0, size);
            FillMatrix(a1, 0, size);
            FillMatrix(a2, 0, size);
            HowManyInLine(oldp, qiju);
            ValueTheChessboardNaive(oldp, qiju, a1, a2);

            /****************算出分数最高的空位，填写坐标*********************/
            for (i = 0; i < size; i++)
                for (j = 0; j < size; j++)
                {
                    if (a1[x1, y1] < a1[i, j])
                    { x1 = i; y1 = j; }  // black  
                }
            for (i = 0; i < size; i++)
                for (j = 0; j < size; j++)
                {
                    if (a2[x2, y2] < a2[i, j])
                    { x2 = i; y2 = j; }  // white  
                }

            if (a1[x1, y1] > a2[x2, y2])
            { x = x1; y = y1; }
            else
            { x = x2; y = y2; }

            point data = new point(x, y);
            return data;
        }

        static private void FillMatrix(int[,] arr, int num, int row)
        {
            for (int i = 0; i < row; i++)
                for (int j = 0; j < row; j++)
                    arr[i, j] = 0;
        }

        static private void FillMatrix(int[,,,] arr, int num, int row)
        {
            for (int i = 0; i < row; i++)
                for (int j = 0; j < row; j++)
                    for (int k = 0; k < 8; k++)
                        arr[i, j, k, 0] = arr[i, j, k, 1] = num;
        }

        static private void ValueTheChessboardNaive(int[,] points, int[,,,] qiju, int[,] a1, int[,] a2)
        {
            int i, j, k;
            int win;
            /******************根据评分规则对每一个空格评分***************/
            for (i = 0; i < size; i++)  // col  
                for (j = 0; j < size; j++)  // row  
                {
                    if (points[i, j] == 0)
                    {
                        win = 0;
                        for (k = 0; k < 4; k++)  // direction  
                        {
                            if (qiju[i, j, k, 0] + qiju[i, j, k + 4, 0] >= 4)
                                win += 10000;
                            else if (qiju[i, j, k, 0] + qiju[i, j, k + 4, 0] == 3)
                                win += 1000;
                            else if (qiju[i, j, k, 0] + qiju[i, j, k + 4, 0] == 2)
                                win += 100;
                            else if (qiju[i, j, k, 0] + qiju[i, j, k + 4, 0] == 1)
                                win += 10;
                        }
                        a1[i, j] = win;  // black  
                        win = 0;
                        for (k = 0; k < 4; k++)  // direction  
                        {
                            if (qiju[i, j, k, 1] + qiju[i, j, k + 4, 1] >= 4)
                                win += 10000;
                            else if (qiju[i, j, k, 1] + qiju[i, j, k + 4, 1] == 3)
                                win += 1000;
                            else if (qiju[i, j, k, 1] + qiju[i, j, k + 4, 1] == 2)
                                win += 100;
                            else if (qiju[i, j, k, 1] + qiju[i, j, k + 4, 1] == 1)
                                win += 10;
                        }
                        a2[i, j] = win;  // white  
                    }
                }
        }

        static private void HowManyInLine(int[,] oldp, int[,,,] qiju)
        {
            int i, j, k, t, cnt;
            int tx, ty;
            int[] dx = new int[8] { 0, 1, 1, 1, 0, -1, -1, -1 };
            int[] dy = new int[8] { -1, -1, 0, 1, 1, 1, 0, -1 };
            /****************为双方填写棋型表************/
            for (i = 0; i < size; i++)  // col  
                for (j = 0; j < size; j++)  // row  
                    if (oldp[i, j] == 0)
                    {
                        for (k = 0; k < 8; k++)  // direction  
                        {
                            // black  
                            cnt = 0;
                            tx = i;
                            ty = j;
                            for (t = 0; t < 5; t++)
                            {
                                tx += dx[k];
                                ty += dy[k];
                                if (tx >= size || tx < 0 || ty >= size || ty < 0) break;
                                if (oldp[tx, ty] == 1) cnt++;
                                else break;
                            }
                            qiju[i, j, k, 0] = cnt;
                            // white  
                            cnt = 0;
                            tx = i;
                            ty = j;
                            for (t = 0; t < 5; t++)
                            {
                                tx += dx[k];
                                ty += dy[k];
                                if (tx >= size || tx < 0 || ty >= size || ty < 0) break;
                                if (oldp[tx, ty] == 2) cnt++;
                                else break;
                            }
                            qiju[i, j, k, 1] = cnt;
                        }
                    }
        }

    }


}
