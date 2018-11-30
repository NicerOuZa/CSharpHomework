using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DBtest
{
    class DBO
    {
        public static void selcetAll()
        {
            MySqlConnection conn = DB_utils.GetConnection();
            conn.Open();
            string sql = "SELECT * FROM ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetInt32("id") + reader.GetString("username") + reader.GetString("password"));
            }

            Console.ReadKey();
        }

        public static void selectById(int id)
        {
            MySqlConnection conn = DB_utils.GetConnection();
            conn.Open();
            string sql = "SELECT * FROM mygamedb.users where id = @para1";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("para1", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetInt32("id") + reader.GetString("username") + reader.GetString("password"));
            }

            Console.ReadKey();
        }

        public static void getRowNum()
        {
            MySqlConnection conn = DB_utils.GetConnection();
            conn.Open();
            string sql = "select count(*) from mygamedb.users";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            Object result = cmd.ExecuteScalar();
            if (result != null)
            {
                Console.WriteLine(int.Parse(result.ToString()));
            }
        }

        public static void delete()
        {
            MySqlConnection conn = DB_utils.GetConnection();
            conn.Open();
            string sql = "DELETE FROM `mygamedb`.`users` WHERE (`id` = '15')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int results = cmd.ExecuteNonQuery();
            Console.WriteLine(results);
        }

        public static void insert(long orderNum, string goodName, string client,long phoneNum,double orderSum)
        {
            MySqlConnection conn = DB_utils.GetConnection();
            conn.Open();
            string sql = "INSERT INTO `orderdb`.`order` (`oredernum`, `goodname`, `client`, `phonenum`, `sum`) VALUES (@para1, @para2, @para3, @para4, @para5);";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("para1", orderNum);
            cmd.Parameters.AddWithValue("para2", goodName);
            cmd.Parameters.AddWithValue("para3", client);
            cmd.Parameters.AddWithValue("para4", phoneNum);
            cmd.Parameters.AddWithValue("para5", orderSum);
            cmd.ExecuteNonQuery();
        }

        public static void update1(long ordernum,long newnum)
        {
            MySqlConnection conn = DB_utils.GetConnection();
            conn.Open();
            string sql = "UPDATE `orderdb`.`order` SET `oredernum` = @para1 WHERE (`oredernum` = @para2)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("para1", newnum);
            cmd.Parameters.AddWithValue("para2", ordernum);
            cmd.ExecuteNonQuery();
        }
        public static void update2(long ordernum, string goodname)
        {
            MySqlConnection conn = DB_utils.GetConnection();
            conn.Open();
            string sql = "UPDATE `orderdb`.`order` SET `goodname` = @para1 WHERE (`oredernum` = @para2)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("para1", goodname);
            cmd.Parameters.AddWithValue("para2", ordernum);
            cmd.ExecuteNonQuery();
        }
        public static void update3(long ordernum, string client)
        {
            MySqlConnection conn = DB_utils.GetConnection();
            conn.Open();
            string sql = "UPDATE `orderdb`.`order` SET `client` = @para1 WHERE (`oredernum` = @para2)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("para1", client);
            cmd.Parameters.AddWithValue("para2", ordernum);
            cmd.ExecuteNonQuery();
        }
        public static void update4(long ordernum, long phnum)
        {
            MySqlConnection conn = DB_utils.GetConnection();
            conn.Open();
            string sql = "UPDATE `orderdb`.`order` SET `phonenum` = @para1 WHERE (`oredernum` = @para2)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("para1", phnum);
            cmd.Parameters.AddWithValue("para2", ordernum);
            cmd.ExecuteNonQuery();
        }
        public static void update5(long ordernum, double sum)
        {
            MySqlConnection conn = DB_utils.GetConnection();
            conn.Open();
            string sql = "UPDATE `orderdb`.`order` SET `sum` = @para1 WHERE (`oredernum` = @para2)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("para1", sum);
            cmd.Parameters.AddWithValue("para2", ordernum);
            cmd.ExecuteNonQuery();
        }
    }
}
