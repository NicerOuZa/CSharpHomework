using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace homework4
{
    // 闹钟
    public class Clock
    {
        public string name = "闹钟机器人提示你";         
        //声明委托
        public delegate void RingEventHandler(Object sender, RingEventArgs e);
        public event RingEventHandler Ring; //声明事件
        // 定义BoiledEventArgs类，传递给Observer所感兴趣的信息
        public class RingEventArgs : EventArgs
        {
            public System.DateTime time { get; set; }      
        }

        // 可以供继承自 Heater 的类重写，以便继承类拒绝其他对象对它的监视
        protected virtual void OnRing(RingEventArgs e)
        {
            if (Ring != null)
            { // 如果有对象注册
                Ring(this, e);  // 调用所有注册对象的方法
            }
        }

        // 计时器
        public void TimeKeeper()
        {
            RingEventArgs e = new RingEventArgs();
            Console.WriteLine("请按照以下格式输入：注意中英文符号");
            Console.WriteLine("2018/1/1 0:0:0");
            string s = Console.ReadLine();
            DateTime time=DateTime.Now;
            
            try
            {
                time = DateTime.Parse(s);
            }
            catch
            {
                Console.WriteLine("输入的日期不符合要求哦！");
            }
            while (true)
            {
                System.DateTime now = System.DateTime.Now;
                Thread.Sleep(1000);
                Console.WriteLine(now);
                if (now >= time)
                {
                    e.time = now;
                    OnRing(e);  // 调用 OnBolied方法
                }
            }
            
        }
    }

    // 警报器
    public class Alarm
    {
        public void MakeAlert(Object sender, Clock.RingEventArgs e)
        {
            Clock clocker = (Clock)sender;     //以后如果有多个发布者，便于修改
                                                //访问 sender 中的公共字段
            Console.WriteLine("Alarm：{0}", clocker.name);
            Console.WriteLine("Alarm: 嘀嘀嘀，现在已经 {0} 点了：", e.time);
            Console.WriteLine();
        }
    }

    // 闹钟屏幕显示器
    public class Display
    {
        public static void ShowMsg(Object sender, Clock.RingEventArgs e)
        {   //静态方法
            Clock clocker = (Clock)sender;
            Console.WriteLine("Display：{0} ",clocker.name);
            Console.WriteLine("Display：时间快到了，当前时间：{0}点。", e.time);
            Console.WriteLine();
        }
    }

    class Program1
    {
        static void Main()
        {
         //   Console.WriteLine("作业1：");
          //  Clock clocker = new Clock();
         //   Alarm alarm = new Alarm();
         //   clocker.Ring += alarm.MakeAlert;   //注册方法
         //   clocker.Ring += Display.ShowMsg;       //注册静态方法
         // heater.Ring += (new Alarm()).MakeAlert;      //给匿名对象注册方法
         // heater.Ring += new Clock.RingEventHandler(alarm.MakeAlert);    //也可以这么注册
         //   clocker.TimeKeeper();   //计时，会自动调用注册过对象的方法
            Console.WriteLine("作业2:");
            OrderService a = new OrderService();
            a.AddOrder("n1","n2","n3","n4","n5");
            a.AddOrder("b1", "b2", "b3", "b4", "b5");
            a.AddOrder("c1", "c2", "c3", "c4", "c5");
            a.AddOrder("d1", "d2", "d3", "d4", "d5");
            Console.WriteLine("初始订单状态：");
            foreach(Order order in a.orderStore)
            {
                Console.WriteLine(order.Clientname + " " + order.Ordername + " " + order.Ordernumber+" "+ order.Detail.Productname + " " + order.Detail.Productprice + " " + order.Detail.Productamounts);
            }
            a.DeleteOrder();
            Console.WriteLine("删除后：");
            foreach (Order order in a.orderStore)
            {
                Console.WriteLine(order.Clientname + " " + order.Ordername + " " + order.Ordernumber + " " + order.Detail.Productname + " " + order.Detail.Productprice + " " + order.Detail.Productamounts);
            }
            Console.WriteLine("修改前：");
            a.CorrectOrder();
            Console.WriteLine("修改后：");
            foreach (Order order in a.orderStore)
            {
                Console.WriteLine(order.Clientname + " " + order.Ordername + " " + order.Ordernumber + " " + order.Detail.Productname + " " + order.Detail.Productprice + " " + order.Detail.Productamounts);
            }
            Console.ReadKey();
        }
    }
}


