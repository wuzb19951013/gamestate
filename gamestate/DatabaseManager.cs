using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace gamestate
{
    public class DatabaseManager
    {

        public enum identity
        {
            black, white, man, computer, none
        }

        private SQLiteConnection connRecord = null;

        public DatabaseManager()
        {
            connRecord = new SQLiteConnection("record.db");
            createTable();
            initial(); // 初始化数据，如果已经存在了这个项，不会重复插入，也不会更改信息，所以不需要担心
        }
        private void createTable()
        {
            if (connRecord == null) return;
            // 创建表 
            string sql;
            sql = @"CREATE TABLE IF NOT EXISTS
                    CHESSMAN(row integer(15) primary key not null,
                             chesses varchar(15))";
            using (var statement = connRecord.Prepare(sql))
            {
                statement.Step();
            }
            sql = @"CREATE TABLE IF NOT EXISTS
                    RECORD(identity varchar(2) primary key not null,
                           mode varchar(2),
                           winNum integer)";
            using (var statement = connRecord.Prepare(sql))
            {
                statement.Step();
            }
            sql = @"CREATE TABLE IF NOT EXISTS
                    GAME(time varchar primary key not null,
                         matrix varchar(441),
                         comment varchar,
                         winner varchar(2))";
            using (var statement = connRecord.Prepare(sql))
            {
                statement.Step();
            }
        }
        // 若数据库为空,插入默认数据 
        private void initial()
        {
            if (connRecord == null) return;
            // 全部初始化为空 
            string sql;
            string defaultChesses = "000000000000000000000";
            for (int i = 0; i < 15; i++)
            {
                sql = @"INSERT INTO CHESSMAN(row, chesses) VALUES(?, ?)";
                using (var statement = connRecord.Prepare(sql))
                {
                    statement.Bind(1, i);
                    statement.Bind(2, defaultChesses);
                    // row为primary key, 不可重复插入,
                    // 如果插入违反约束, 说明不是第一次插入, 即已经初始化完毕, 所以不再执行 
                    if (statement.Step() == SQLiteResult.CONSTRAINT)
                    {
                        break;
                    }
                }
            }

            sql = @"INSERT INTO RECORD(identity, mode, winNum) VALUES(?, ?, ?), (?, ?, ?), (?, ?, ?), (?, ?, ?)";
            using (var statement = connRecord.Prepare(sql))
            {
                statement.Bind(1, "电脑");
                statement.Bind(2, "人机");
                statement.Bind(3, 0);
                statement.Bind(4, "人");
                statement.Bind(5, "人机");
                statement.Bind(6, 0);
                statement.Bind(7, "白方");
                statement.Bind(8, "人人");
                statement.Bind(9, 0);
                statement.Bind(10, "黑方");
                statement.Bind(11, "人人");
                statement.Bind(12, 0);
                statement.Step();
            }
        }

        // 保存棋局数据以便在terminate后重新加载
        public void storeData(int[,] arr)
        {
            if (connRecord == null) return;
            string sql;
            for (int i = 0; i < 15; i++)
            {
                sql = @"UPDATE CHESSMAN
                            SET chesses = ?
                            WHERE row = ?";
                using (var statement = connRecord.Prepare(sql))
                {
                    string newChesses = "";
                    for (int j = 0; j < 15; j++)
                    {
                        newChesses += arr[i, j].ToString();
                    }
                    statement.Bind(1, newChesses);
                    statement.Bind(2, i);
                    statement.Step();
                }
            }
        }
        public int[,] getData()
        {
            int[,] arr = new int[15, 15];
            string sql;
            sql = @"SELECT chesses
                    FROM CHESSMAN";
            int i = 0;
            using (var statement = connRecord.Prepare(sql))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        arr[i, j] = (statement[0].ToString())[j] - '0';
                    }
                    i++;
                }
            }
            return arr;
        }

        // 保存游戏
        public void storeGame(int[,] arr, string time, string comment, identity winner)
        {
            if (connRecord == null) return;
            string matrix = "";
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    matrix += arr[i, j].ToString();
                }
            }
            string winnerStr;
            if (winner == identity.black)
            {
                winnerStr = "黑方";
            } else if (winner == identity.white)
            {
                winnerStr = "白方";
            } else if (winner == identity.man)
            {
                winnerStr = "人";
            } else
            {
                winnerStr = "电脑";
            }
            string sql = @"INSERT INTO GAME(time, matrix, comment, winner) VALUES(?, ?, ?, ?)";
            using (var statement = connRecord.Prepare(sql))
            {
                statement.Bind(1, time);
                statement.Bind(2, matrix);
                statement.Bind(3, comment);
                statement.Bind(4, winnerStr);
                statement.Step();
            }
        }
        // 返回一个string数组,其中有三个元素,第一个为棋盘,第二个为评论,第三个为赢家
        // 可以调用下面第二个的convertToArray将棋盘由string转换为数组.
        public string [] getGame1(string time)
        {
            // info[0]:matrix, info[1]:comment, info[2]:winner
            string[] info = new string[3];
            string sql = @"SELECT matrix, comment, winner, time
                           FROM GAME
                           WHERE time LIKE ?";
            using (var statement = connRecord.Prepare(sql))
            {
                statement.Bind(1, "%" + time + "%");
                statement.Step();
                info[0] = statement[0].ToString();
                info[1] = statement[1].ToString();
                info[2] = statement[2].ToString();
            }
            return info;
        }

        // 改动自上一个函数
        // 返回一个string[4]数组,其中每一个string[],有四个元素,第一个为棋盘,第二个为评论,第三个为赢家，第四个为时间
        public ObservableCollection<string[]> getGame(string time)
        {
            // string[0]:matrix, string[1]:comment, string[2]:winner, info[3]:detailtime
            ObservableCollection<string[]> list = new ObservableCollection<string[]>();
            string sql = @"SELECT matrix, comment, winner, time
                           FROM GAME
                           WHERE time LIKE ?";
            using (var statement = connRecord.Prepare(sql))
            {
                statement.Bind(1, "%" + time + "%");
                while (statement.Step() == SQLiteResult.ROW)
                {
                    list.Add(new string[4]
                    {
                        statement[0].ToString(),
                        statement[1].ToString(),
                        statement[2].ToString(),
                        statement[3].ToString()
                    });
                }
            }
            return list;
        }

        public int[,] convertToArray(string str)
        {
            int[,] matrix = new int[15, 15];
            int pos = 0;
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    matrix[i, j] = str[pos] - '0';
                    pos++;
                }
            }
            return matrix;
        }

        public void addWinNum(identity id)
        {
            string sql = @"UPDATE RECORD
                           SET winNum = winNum + 1
                           WHERE identity = ?";
            using (var statement = connRecord.Prepare(sql))
            {
                if (id == identity.black)
                {
                    statement.Bind(1, "黑方");
                } else if (id == identity.white)
                {
                    statement.Bind(1, "白方");
                } else if (id == identity.man)
                {
                    statement.Bind(1, "人");
                } else if (id == identity.computer)
                {
                    statement.Bind(1, "电脑");
                }
                statement.Step();
            }
        }
        public int getWinNum(identity id)
        {
            string sql = @"SELECT winNum
                           FROM RECORD
                           WHERE identity = ?";
            using (var statement = connRecord.Prepare(sql))
            {
                if (id == identity.black)
                {
                    statement.Bind(1, "黑方");
                }
                else if (id == identity.white)
                {
                    statement.Bind(1, "白方");
                }
                else if (id == identity.man)
                {
                    statement.Bind(1, "人");
                }
                else if (id == identity.computer)
                {
                    statement.Bind(1, "电脑");
                }
                statement.Step();
                if (statement[0] != null) return int.Parse(statement[0].ToString());
                else return 0;
            }
        }

        //删除
        public void deleteGame(string time)
        {
            if (connRecord == null) return;
            string sql = @"DELETE FROM GAME
                           WHERE time = ?";
            using (var statement = connRecord.Prepare(sql))
            {
                statement.Bind(1, time);
                statement.Step();
            }
        }
        // 修改评论 
        public void editComment(string time, string comment)
        {
            if (connRecord == null) return;
            string sql = @"UPDATE GAME
                           SET comment = ?
                           WHERE time = ?";
            using (var statement = connRecord.Prepare(sql))
            {
                statement.Bind(1, comment);
                statement.Bind(2, time);
                statement.Step();
            }
        }


    }
}
