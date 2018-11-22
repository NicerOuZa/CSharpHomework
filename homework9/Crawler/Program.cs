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
//这是完善版，第三个项目中有些问题搞了很久没明白，先暂时存着。
namespace Crawler
{
    public class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
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
            stopWatch.Stop();
            Console.WriteLine(" run " + stopWatch.ElapsedMilliseconds + " ms.");
        }
        private void Crawl()
        {
            Console.WriteLine("开始爬行了。。。。。。");
            while (true)
            {
                List<string> currents = new List<string>();
                lock (this)
                {
                    foreach (string url in urls.Keys)
                    {
                        if ((bool)urls[url])
                            continue;


                        if (url != null)
                            currents.Add(url);

                    }
                }

                for (int i = 0; i < currents.Count; i++)
                {
                    Console.WriteLine("爬行" + currents[i] + "页面");
                    ThreadPool.QueueUserWorkItem(new WaitCallback(Parse), DownLoad(currents[i]));
                    urls[currents[i]] = true;
                    count++;
                    if (count > 5)
                    {
                        break;
                    }
                }
                if (count > 5)
                {
                    break;
                }
            }
            Console.WriteLine("爬行结束");
        }
        public string DownLoad(string url)
        {
            try
            {
                
                    WebClient webClient = new WebClient();
                    webClient.Encoding = Encoding.UTF8;
                    string html = webClient.DownloadString(url);
                    string fileName = "F:\\C#\\新建文件夹\\" + count.ToString(); ;
                    File.WriteAllText(fileName, html, Encoding.UTF8);
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

                lock(this) 
                {
                    if (urls[strRef] == null)
                    {
                        urls[strRef] = false;
                    }
                }
            }
        }
    }
}
