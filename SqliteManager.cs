using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace HpGameServerDemo
{
    public  class SqliteManager
    {
        private static SqliteManager instance;
        public static SqliteManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SqliteManager();
                }
                return  instance;
            }

        }

        //数据库连接类
        SQLiteConnection con;
        //命令类
        SQLiteCommand cmd;

        SqliteManager()
        {
            //数据库连接字符串
            string conStr = "Data Source="+Directory.GetCurrentDirectory()+"\\test.db";
            //创建连接类
            con = new SQLiteConnection(conStr);
            //打开数据库
            con.Open();
            //创建一个表
            ExecuteCmd("create table if not exists ACCOUNT(id integer primary key autoincrement,account text,password text)");

        }
        ~SqliteManager()
        {
            //释放数据库连接
            con.Dispose();
            //关闭数据库
            con.Close();

        }
        //执行除了查询之外的命令
        public int ExecuteCmd(string command)
        {
            cmd = new SQLiteCommand(command,con);
            //ExecuteNonQuery执行除了查询之外的简单命令，返回一个整形，表示影响的行数
            return cmd.ExecuteNonQuery();
        }
        //查询单个数据
        public object SearchOne(string command)
        {
            cmd= new SQLiteCommand(command,con);
            //ExecuteScalar返回一个object
            return cmd.ExecuteScalar();
        }
        //查询多个数据
        public SQLiteDataReader Search(string command)
        {
            cmd = new SQLiteCommand(command, con);
            //ExecuteReader返回一个SQLiteDataReader（由查询到的表生成的对象）
            return cmd.ExecuteReader();

        }
    }
}
