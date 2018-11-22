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

namespace Program1
{
    class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        private List<string> currents;
        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            myCrawler.urls.Add(startUrl, false);
            Stopwatch stopwatch = new Stopwatch();


            stopwatch.Start();

            myCrawler.Crawl();
            //Parallel.Invoke(actions);

            stopwatch.Stop();
            Console.WriteLine("耗时" + stopwatch.ElapsedMilliseconds);
        }

        private void Crawl()
        {
            Console.WriteLine("开始爬行了");
            while (true)
            {
                string current = null;
                currents = new List<string>();         //存current数组
                string[] html = new string[10];
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url])
                    {
                        continue;
                    }
                    currents.Add(url);                   //把url加到currents里
                    current = url;
                }

                if (current == null || count > 30)
                {
                    break;
                }

                int tdNum = 10;                      //线程数
                Thread[] tds = new Thread[tdNum];
                for (int i = 0; i < tdNum; i++)
                {
                    if (i < currents.Count)
                    {
                        Console.WriteLine("爬行" + currents[i] + "页面");
                        if(i<currents.Count)
                            tds[i] = new Thread(() => { DownLoad(currents[i]); });
                        urls[currents[i]] = true;
                        count++;
                        tds[i].Start();
                        tds[i].Join();
                    }

                } 
               
            }
            Console.WriteLine("爬行结束");
        }


        public void DownLoad(string url)
        {
            try
            {
               
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);


                Parse(html);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[]* = []*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
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
