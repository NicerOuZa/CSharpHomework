using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace homework5
{
    public class Program
    {
        static void Main(string[] args)
        {
            OrderService2 a = new OrderService2();
            a.AddOrder("n1", "n2", "n3", "10000", "n4");
            a.AddOrder("b1", "b2", "b3", "100000", "b4");
            a.AddOrder("c1", "c2", "c3", "10001", "c4");
            a.AddOrder("d1", "d2", "d3", "100", "d4");
            //a.LinqSearchOrder();
            a.Export(a.orderStore);
            a.Import(a.orderStore, a.xmlSerializer);
            Console.Read();
        }
        public class Order
        {
            public string Ordername { get; set; }
            public string Clientname { get; set; }
            public string Ordernumber { get; set; }
            public OrderDetails Detail = new OrderDetails();
            public Boolean Compare(string x, string y)
            {
                if (double.Parse(x) > double.Parse(y))
                    return true;
                else return false;

            }

            public override string ToString()
            {
                return Ordername + ' ' + Clientname + ' ' + Ordernumber + ' ' + Detail.Productname + ' ' + Detail.Productprice + ' ' + Detail.Productamounts; ;
            }
        }
        public class OrderDetails
        {
            public string Productname { get; set; }
            public string Productamounts { get; set; }
            public string Productprice { get; set; }
        }
        //class OrderService
        //{
        //    public List<Order> orderStore = new List<Order>();
        //    public void AddOrder(string name1, string name2, string name3, string productprice, string productamounts)
        //    {
        //        Order order = new Order();
        //        //OrderDetails detail = new OrderDetails();
        //        StringBuilder sum = new StringBuilder("a");
        //        do
        //        {
        //            for (int i = 0; i < 4; i++)
        //            {
        //                Random number = new Random();
        //                int s1 = number.Next(9);
        //                sum = sum.Append(s1.ToString());
        //            }
        //        }
        //        while (!fun());
        //        bool fun()
        //        {
        //            for (int i = 0; i < orderStore.Count; i++)
        //            {
        //                if (sum.ToString().Equals(orderStore[i].Ordernumber))
        //                    return false;
        //            }
        //            return true;
        //        }
        //        order.Clientname = name1;
        //        order.Ordername = name2;
        //        order.Detail.Productname = name3;
        //        order.Ordernumber = sum.ToString();
        //        order.Detail.Productprice = productprice;
        //        order.Detail.Productamounts = productamounts;
        //        orderStore.Add(order);
        //    }
        //    string key;
        //    char num;
        //    int idx = -1;
        //    int SearchOrder()
        //    {
        //        while (Console.ReadLine() == null)
        //            Console.ReadLine();
        //        int idx = -1;
        //        Console.WriteLine("请输入你所持有的对应信息：");
        //        key = Console.ReadLine();
        //        Console.WriteLine("请选择查询方式：");
        //        Console.WriteLine("1：客户名   2：订单名  3:订单号  4：商品名  5：商品单价： 6：商品数量");
        //        num = (char)Console.Read();
        //        switch (num)
        //        {
        //            case '1': idx = GetClientname(key); break;
        //            case '3': idx = GetOrdernumber(key); break;
        //            case '2': idx = GetOrdername(key); break;
        //            case '4': idx = GetProductname(key); break;
        //            case '5': idx = GetProductprice(key); break;
        //            case '6': idx = GetProductamounts(key); break;
        //            default: Console.WriteLine("你选择的方式不对哦！"); break;
        //        }

        //        if (idx == -1)
        //            Console.WriteLine("对不起，查无此单！");
        //        return idx;
        //    }
        //    public void DeleteOrder()
        //    {
        //        Console.WriteLine("下面开始删除订单：");
        //        int idx = SearchOrder();

        //        try
        //        {
        //            if (idx == -1)
        //                throw new DeleteException(" 很遗憾！", key);
        //            orderStore.Remove(orderStore[idx]);
        //        }

        //        catch (DeleteException e)
        //        {
        //            Console.WriteLine(e.Message + "表单:" + e.getName() + "不存在！");
        //        }
        //    }
        //    public void CorrectOrder()
        //    {
        //        Console.WriteLine("请输入更改元素：");
        //        while (Console.ReadLine() == null)
        //            Console.ReadLine();
        //        string correctdata = Console.ReadLine();
        //        int idx = SearchOrder();
        //        try
        //        {
        //            if (idx == -1)
        //                throw new CorrectExeption(" 很遗憾！", correctdata);
        //            switch (num)
        //            {
        //                case '1': orderStore[idx].Clientname = correctdata; break;
        //                case '3': orderStore[idx].Ordernumber = correctdata; break;
        //                case '2': orderStore[idx].Ordername = correctdata; break;
        //                case '4': orderStore[idx].Detail.Productname = correctdata; break;
        //                case '5': orderStore[idx].Detail.Productprice = correctdata; break;
        //                case '6': orderStore[idx].Detail.Productamounts = correctdata; break;
        //                default: Console.WriteLine("输入了无效的选择方式！"); break;
        //            }
        //        }
        //        catch (CorrectExeption e)
        //        {
        //            Console.WriteLine(e.Message + "表单: " + e.getName() + "不存在！");
        //        }
        //    }
        //    int GetClientname(string clientname)
        //    {
        //        foreach (Order order in orderStore)
        //        {
        //            if (order.Clientname == clientname)
        //            {
        //                idx = orderStore.IndexOf(order);
        //                Console.WriteLine(order.Clientname + " " + order.Ordername + " " + order.Ordernumber + " " + order.Detail.Productname + " " + order.Detail.Productprice + " " + order.Detail.Productamounts);
        //                break;
        //            }

        //        }
        //        return idx;
        //    }
        //    int GetOrdername(string ordername)
        //    {
        //        foreach (Order order in orderStore)
        //        {
        //            if (order.Ordername == ordername)
        //            {
        //                idx = orderStore.IndexOf(order);
        //                Console.WriteLine(order.Clientname + " " + order.Ordername + " " + order.Ordernumber + " " + order.Detail.Productname + " " + order.Detail.Productprice + " " + order.Detail.Productamounts);
        //            }

        //        }
        //        return idx;
        //    }
        //    int GetOrdernumber(string ordernumber)
        //    {
        //        foreach (Order order in orderStore)
        //        {
        //            if (order.Ordernumber == ordernumber)
        //            {

        //                Console.WriteLine(order.Clientname + " " + order.Ordername + " " + order.Ordernumber + " " + order.Detail.Productname + " " + order.Detail.Productprice + " " + order.Detail.Productamounts);
        //                idx = orderStore.IndexOf(order);
        //            }

        //        }
        //        return idx;
        //    }
        //    int GetProductname(string productname)
        //    {
        //        foreach (Order order in orderStore)
        //        {
        //            if (order.Detail.Productname == productname)
        //            {
        //                idx = orderStore.IndexOf(order);
        //                Console.WriteLine(order.Clientname + " " + order.Ordername + " " + order.Ordernumber);
        //                Console.WriteLine(order.Detail.Productname + " " + order.Detail.Productprice + " " + order.Detail.Productamounts);

        //            }

        //        }
        //        return idx;
        //    }
        //    int GetProductprice(string productprice)
        //    {
        //        foreach (Order order in orderStore)
        //        {
        //            if (order.Detail.Productprice == productprice)
        //            {
        //                idx = orderStore.IndexOf(order);
        //                Console.WriteLine(order.Clientname + " " + order.Ordername + " " + order.Ordernumber + " " + order.Detail.Productname + " " + order.Detail.Productprice + " " + order.Detail.Productamounts);
        //            }

        //        }
        //        return idx;
        //    }
        //    int GetProductamounts(string productamounts)
        //    {
        //        foreach (Order order in orderStore)
        //        {
        //            if (order.Detail.Productamounts == productamounts)
        //            {
        //                idx = orderStore.IndexOf(order);
        //                Console.WriteLine(order.Clientname + " " + order.Ordername + " " + order.Ordernumber + " " + order.Detail.Productname + " " + order.Detail.Productprice + " " + order.Detail.Productamounts);
        //            }

        //        }
        //        return idx;
        //    }
        //}
        //var query2 = students
        //       .Where(s => s.Major == "computer science")
        //       .Select(s => s.Name);
        //    foreach (var s in query1)
        //    {
        //        Console.WriteLine($"{s}");
        //    }
        public class OrderService2
        {
            public List<Order> orderStore = new List<Order>();
            public void AddOrder(string name1, string name2, string name3, string productprice, string productamounts)
            {
                Order order = new Order();
                //OrderDetails detail = new OrderDetails();
                StringBuilder sum = new StringBuilder("a");
                do
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Random number = new Random();
                        int s1 = number.Next(9);
                        sum = sum.Append(s1.ToString());
                    }
                }
                while (!fun());
                bool fun()
                {
                    for (int i = 0; i < orderStore.Count; i++)
                    {
                        if (sum.ToString().Equals(orderStore[i].Ordernumber))
                            return false;
                    }
                    return true;
                }
                order.Clientname = name1;
                order.Ordername = name2;
                order.Detail.Productname = name3;
                order.Ordernumber = sum.ToString();
                order.Detail.Productprice = productprice;
                order.Detail.Productamounts = productamounts;
                orderStore.Add(order);
            }

            //利用Linq查询订单
            //public void LinqSearchOrder()
            //{
            //    Console.WriteLine("请选择按什么方式查询：1：商品名称 2：客户名称");
            //    char select = (char)Console.Read();
            //    if (select == '1')
            //    {
            //        Console.WriteLine("请输入你所持有的商品名称：");
            //        while (Console.ReadLine() == null)
            //            Console.ReadLine();
            //        string productname = Console.ReadLine();
            //        var query1 = orderStore
            //            .Where(od => od.Detail.Productname == productname);
            //        // .Select(od=>od); 可以不写也可以写
            //        if (query1.Count() == 0)
            //        {
            //            Console.WriteLine("查无此单！");
            //        }
            //        foreach (var od in query1)
            //        {
            //            Console.WriteLine(od.Clientname + ' ' + od.Ordername + ' ' + od.Ordernumber + ' ' + od.Detail.Productname + ' ' + od.Detail.Productprice + ' ' + od.Detail.Productamounts);
            //        }

            //    }
            //    else if (select == '2')
            //    {
            //        //var query1 = from s in students
            //        //             where s.Major == "computer science"
            //        //             select s.Name;
            //        Console.WriteLine("请输入你所持有的客户姓名：");
            //        while (Console.ReadLine() == null)
            //            Console.ReadLine();
            //        string cilentname = Console.ReadLine();
            //        var query2 = from od in orderStore
            //                     where od.Clientname == cilentname
            //                     select od;
            //        foreach (var od in query2)
            //        {
            //            Console.WriteLine(od.Clientname + ' ' + od.Ordername + ' ' + od.Ordernumber + ' ' + od.Detail.Productname + ' ' + od.Detail.Productprice + ' ' + od.Detail.Productamounts);
            //        }
            //        if (query2.Count() == 0)
            //        {
            //            Console.WriteLine("无此订单！");
            //        }

            //    }
            //    else Console.WriteLine("输入信息错误或者订单不存在！！！");
            //    Console.WriteLine("现在开始查询订单价格XXXX元以上的订单,并且按金额从低到高排序：");
            //    Console.WriteLine("请输入 ：查询");
            //    while (Console.ReadLine() == null)
            //        Console.ReadLine();
            //    Console.WriteLine("请输入金额：");
            //    string price = Console.ReadLine();
            //    //  var query4 = students
            //    //.Where(s => s.Major == "computer science")
            //    //.OrderBy(s => s.Name)
            //    //.ThenByDescending(s => s.ID);

            //    var query3 = orderStore
            //        .Where(od => od.Compare(od.Detail.Productprice, price))
            //        .OrderByDescending(od => double.Parse(od.Detail.Productprice));
            //    foreach (var od in query3)
            //    {
            //        Console.WriteLine(od.Clientname + ' ' + od.Ordername + ' ' + od.Ordernumber + ' ' + od.Detail.Productname + ' ' + od.Detail.Productprice + ' ' + od.Detail.Productamounts);
            //    }
            //}
            //xml序列化和反序列化
            public XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));//new一个xml的Serializer对象来指向序列化的对象
            public void Export(List<Order> orderStore)
            {
               
                using (FileStream fs = new FileStream("s.xml", FileMode.Create))
                {
                    xmlSerializer.Serialize(fs, orderStore);
                }
            }
            //Import来输出订单内容，重写ToString方法。
            public void Import(List<Order> orderStore,XmlSerializer xmlSerializer) { 
                Console.WriteLine(File.ReadAllText("s.xml"));
                using (FileStream fs = new FileStream("s.xml", FileMode.Open))
                {
                    List<Order> lists = (List<Order>)xmlSerializer.Deserialize(fs);
                    foreach (var item in lists)
                    {
                        Console.WriteLine(item.ToString());
                    }                       
                }
            }
            public class DeleteException : ApplicationException
            {
                string Name { set; get; }
                public DeleteException(string message, string name) : base(message)
                {
                    Name = name;
                }
                public string getName()
                {
                    return Name;
                }
            }
            public class CorrectExeption : ApplicationException
            {
                string Name { set; get; }
                public CorrectExeption(string message, string name) : base(message)
                {
                    Name = name;
                }
                public string getName()
                {
                    return Name;
                }
            }
        }
    }
}

