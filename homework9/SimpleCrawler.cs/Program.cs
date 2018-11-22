using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
    delegate Action A();
//delegate void A();
 delegate void  Action();
namespace SimpleCrawler.cs
{
    
     class Crawler
    {
        static AutoResetEvent myEvent = new AutoResetEvent(false);
        private Hashtable urls = new Hashtable();
        private Hashtable urls2 = new Hashtable();
        private int count = 0;
        private int count2 = 0;
        public  A a = null;
       // public B b = null;
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            Crawler myCrawler = new Crawler();
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1)
                startUrl = args[0];
            myCrawler.urls.Add(startUrl, false);
            stopWatch.Start();
             myCrawler.Crawl();
            myEvent.WaitOne();
            Console.WriteLine("线程池终止！");
            stopWatch.Stop();
            Console.WriteLine("Parallel run " + stopWatch.ElapsedMilliseconds + " ms.");
            myCrawler.urls2.Add(startUrl, false);
            stopWatch.Restart();
            new Thread(myCrawler.Crawl2).Start();
            stopWatch.Stop();
            Console.WriteLine("一般情况下爬行了"+ stopWatch.ElapsedMilliseconds+"ms");
            Console.Read();

        }
        public void Crawl()
        {
            Console.WriteLine("开始爬行了......");
           
            while (true)
            {
                List<Thread> ths = new List<Thread>();
                string current = null;
                List<string> currents = new List<string>();         
                string[] html = new string[10];
                foreach (string url in urls.Keys)
                {
                    if ((bool) urls[url])
                        continue;
                    currents.Add(url);
                    current = url;
                }
                if (current == null || count > 10)
                {
                    myEvent.Set();
                    break;
                }
                for (int i = 0; i < currents.Count; i++)
                {                   
                    Console.WriteLine("爬行" + currents[i] + "页面");
                    ThreadPool.SetMaxThreads(5, 5);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(Parse),DownLoad(currents[i]));
                    //var  Task = new Task(() => Parse(DownLoad(currents[i])));
                   // Task.WaitAll();
                    urls[currents[i]] = true;
                        count++;
                }                                                                                  
            }
            Console.WriteLine("爬行结束");
        }
        private void Crawl2()
        {
            Console.WriteLine("开始爬行了......");           
            while (true)
            {

                string current = null;
                foreach (string url in urls2.Keys)
                {
                    if ((bool)urls2[url])
                        continue;
                    current = url;
                }

                if (current == null || count2 > 10)
                    break;
                Console.WriteLine(      "爬行"+current+"页面");
                string html = DownLoad2(current);
                urls2[current] = true;
                count2++;
                Parse(html);
            }
            Console.WriteLine("爬行结束");
        }
        public string DownLoad(object url)
        {
            try
            {
                WebClient webclient = new WebClient();
                webclient.Encoding = Encoding.UTF8;
                string html = webclient.DownloadString((string)url);
                string filename = "F:\\C#\\新建文件夹\\" + count.ToString();
                File.WriteAllText(filename, html, Encoding.UTF8);
                //Parse(html);
                return html;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
            
        }
        public string DownLoad2(string url)
        {
            try
            {
                WebClient webclient = new WebClient();
                webclient.Encoding = Encoding.UTF8;
                string html = webclient.DownloadString(url);
                string filename2 = "F:\\C#\\新建文件夹\\" + (count2+100).ToString();
                File.WriteAllText(filename2, html, Encoding.UTF8);
                return html;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }

        }
        public void Parse(object html)
        { 
                string strRef = @"(href|HREF)[]* = []*[""'][^""'#>]+[""']";
                MatchCollection matches = new Regex(strRef).Matches(html.ToString());
                foreach (Match match in matches)
                {
                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', ',', '>');
                    if (strRef.Length == 0)
                    {
                        continue;
                    }

                    if (urls[strRef] == null)
                    {
                        urls[strRef] = false;
                    }
                }
            } 
    }
}
