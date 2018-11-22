using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework7
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
           // Application.EnableVisualStyles();
           // Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new Form1());
            string str = "use ccg"+"create table client(string name(varchar 20),string phonenumber(varchar20));"
              + "create table order(int number(varchar 20),string ordername(varchar 20),int ordernumber(varchar 20));"
              + "create table ordertail(int goodprice(varchar 20),int goodamounts(varchar 20));";
            string url= "server = localhost; database =ccg ; User id = root; password = 192168153156";
            MySqlConnection conn = new MySqlConnection(url);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                Console.WriteLine(cmd.CommandText);
                if (conn.State == ConnectionState.Open)
                {
                    MessageBox.Show("连接数据库成功");
                }
                else
                {
                    MessageBox.Show("连接数据库失败");
                }

                if (cmd.ExecuteNonQuery() > 0)
                {
                    Console.WriteLine("数据插入成功！");
                }
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
