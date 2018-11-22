using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace homework9
{
    class Program
    {
        static void Main(string[] args) {
            //  
            string str1 = "drop table if exists client;" + "create table client(id int(11) primary key ,name varchar(20),phonenumber varchar(20));";
            string str2 = "drop table if exists orders;" + "create table orders(orderName varchar(30), orderCount varchar(30));";
            string str3= "drop table if exists orderdetail;" + "create table orderdetail(goodprice varchar(20),goodamounts varchar(20));";
            string url = "server = localhost; database =ccg ; User id = root; password = 192168153156";
            MySqlConnection conn = new MySqlConnection(url);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str1, conn);               
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand(str2, conn);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand(str3, conn);
                cmd.ExecuteNonQuery();
                //Console.WriteLine(cmd.CommandText);
                if (conn.State == ConnectionState.Open)
                {
                    Console.WriteLine("连接数据库成功");
                }
                else
                {
                    Console.WriteLine("连接数据库失败");
                }                
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
                
            }
        
    }
    //    public static List<Thread> ths = new List<Thread>();
    //    private Hashtable urls = new Hashtable();
    //    private Hashtable urls2 = new Hashtable();
    //    private int count = 0;
    //    private int count2 = 0;
    //    public A a = null;
    //    public delegate void ThreadRunCompleteEvent();

    //    private object _lockObj = new object();
    //    private int _downLoadCount = 10;
    //    public int _alreadyRunCount = 0;
    //    public ThreadRunCompleteEvent DownCompleted = null;


    //    public void ThreadSample()
    //    {
    //        while (true)
    //        {
    //            string current = null;
    //            foreach (string url in urls.Keys)
    //            {
    //                if ((bool)urls[url])
    //                    continue;
    //                current = url;
    //            }

    //            if (current == null || count > 10)
    //                break;
    //            DownCompleted += OnDownCompleted;
    //        for (int i = 0; i < _downLoadCount; i++)
    //        {
    //            Thread thread = new Thread(DownLoad(current));
    //            thread.Start();
    //        }
    //    }

    //    string DownLoad(string current)
    //    {
    //        try
    //        {
    //            if (DownCompleted != null)
    //                DownCompleted();
    //            WebClient webclient = new WebClient();
    //            webclient.Encoding = Encoding.UTF8;
    //            string html = webclient.DownloadString(url);
    //            string filename = "F:\\C#\\新建文件夹\\" + count.ToString();
    //            File.WriteAllText(filename, html, Encoding.UTF8);
    //            return html;
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //            return "";
    //        }
            
    //    }

    //    private void OnDownCompleted()
    //    {
    //        lock (_lockObj)
    //            _alreadyRunCount++;

    //        if (_alreadyRunCount > _downLoadCount)
    //        {
    //            //全部下载完毕执行
    //        }
    //    }
    //    static void Main(string[] args)
    //    {
    //        var stopWatch = new Stopwatch();
    //        Program myCrawler = new Program();
    //        string startUrl = "http://www.cnblogs.com/dstang2000/";
    //        if (args.Length >= 1)
    //            startUrl = args[0];
    //        myCrawler.urls.Add(startUrl, false);
    //        stopWatch.Start();
    //        myCrawler.Crawl();
    //    }
    }
}
