using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询）功能。在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
//写Order（订单）、OrderDetails（订单明细），OrderService（订单服务）几个类，订单数据可以保存在OrderService中一个List中。
namespace homework4
{
    class Program2
    {
    }

    class Order
    {
        public string Ordername { get; set; }
        public string Clientname { get; set; }
        public string Ordernumber { get; set; }
        public OrderDetails Detail = new OrderDetails();   
    }
    class OrderDetails
    {
        public string Productname { get; set; }
        public string Productamounts  { get; set; }
        public string Productprice { get; set; }
    }
    class OrderService
    {
        public List<Order> orderStore = new List<Order>();
        public void AddOrder(string name1, string name2, string name3, string productprice, string productamounts)
        {
            Order order = new Order();
            //OrderDetails detail = new OrderDetails();
            StringBuilder sum =new StringBuilder("a");
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
        string key;
        char num;
        int idx = -1;
        int SearchOrder()
        {
            while (Console.ReadLine() == null)
                Console.ReadLine();
            int idx = -1;
            Console.WriteLine("请输入你所持有的对应信息：");
            key = Console.ReadLine();
            Console.WriteLine("请选择查询方式：");
            Console.WriteLine("1：客户名   2：订单名  3:订单号  4：商品名  5：商品单价： 6：商品数量");
            num = (char)Console.Read();  
            switch (num)
            {
                case '1':  idx=GetClientname(key);break;
                case '3':  idx=GetOrdernumber(key);break;
                case '2':  idx=GetOrdername(key);break;
                case '4':  idx=GetProductname(key);break;
                case '5':  idx=GetProductprice(key);break;
                case '6':  idx=GetProductamounts(key);break;
                default: Console.WriteLine("你选择的方式不对哦！");break;
            }
            
            if(idx==-1)
                Console.WriteLine("对不起，查无此单！");
            return idx;
        }
        public void DeleteOrder()
        {
            Console.WriteLine("下面开始删除订单：");
            int idx = SearchOrder();
            
            try
            {
                if (idx == -1)
                    throw new DeleteException(" 很遗憾！", key);
                orderStore.Remove(orderStore[idx]);
            }
            
            catch (DeleteException e)
            {
                Console.WriteLine(e.Message + "表单:" + e.getName() + "不存在！");
            }
        }
        public void CorrectOrder()
        {
            Console.WriteLine("请输入更改元素：");
            while (Console.ReadLine() == null)
                Console.ReadLine();
            string correctdata = Console.ReadLine();
            int idx = SearchOrder();
            try
            {
                if(idx==-1)
                    throw new CorrectExeption(" 很遗憾！", correctdata);
                switch (num)
                {
                    case '1': orderStore[idx].Clientname = correctdata; break;
                    case '3': orderStore[idx].Ordernumber = correctdata; break;
                    case '2': orderStore[idx].Ordername = correctdata; break;
                    case '4': orderStore[idx].Detail.Productname = correctdata; break;
                    case '5': orderStore[idx].Detail.Productprice = correctdata; break;
                    case '6': orderStore[idx].Detail.Productamounts = correctdata; break;
                    default: Console.WriteLine("输入了无效的选择方式！"); break;
                }
            }
            catch(CorrectExeption e)
            {
                Console.WriteLine(e.Message + "表单: " + e.getName() + "不存在！");
            }
         }
        int GetClientname(string clientname)
        {
            foreach (Order order in orderStore)
            {
                if (order.Clientname == clientname)
                {
                    idx = orderStore.IndexOf(order);
                    Console.WriteLine(order.Clientname + " " + order.Ordername + " " + order.Ordernumber + " " + order.Detail.Productname + " " + order.Detail.Productprice + " " + order.Detail.Productamounts);
                    break;
                }

            }
            return idx;
        }
        int GetOrdername(string ordername)
        {
            foreach (Order order in orderStore)
            {
                if (order.Ordername == ordername)
                {
                    idx = orderStore.IndexOf(order);
                    Console.WriteLine(order.Clientname + " " + order.Ordername + " " + order.Ordernumber + " " + order.Detail.Productname + " " + order.Detail.Productprice + " " + order.Detail.Productamounts);
                }

            }
            return idx;
        }
        int GetOrdernumber(string ordernumber)
        {
            foreach (Order order in orderStore)
            {
                if (order.Ordernumber == ordernumber)
                {

                    Console.WriteLine(order.Clientname + " " + order.Ordername + " " + order.Ordernumber + " " + order.Detail.Productname + " " + order.Detail.Productprice + " " + order.Detail.Productamounts);
                    idx = orderStore.IndexOf(order);
                }

            }
            return idx;
        }
        int GetProductname(string productname)
        {
            foreach (Order order in orderStore)
            {
                if (order.Detail.Productname == productname)
                {
                    idx = orderStore.IndexOf(order);
                    Console.WriteLine(order.Clientname + " " + order.Ordername + " " + order.Ordernumber);
                    Console.WriteLine(order.Detail.Productname + " " + order.Detail.Productprice + " " + order.Detail.Productamounts);

                }

            }
            return idx;
        }
        int GetProductprice(string productprice)
        {
            foreach (Order order in orderStore)
            {
                if (order.Detail.Productprice == productprice)
                {
                    idx = orderStore.IndexOf(order);
                    Console.WriteLine(order.Clientname + " " + order.Ordername + " " + order.Ordernumber + " " + order.Detail.Productname + " " + order.Detail.Productprice + " " + order.Detail.Productamounts);
                }

            }
            return idx;
        }
        int GetProductamounts(string productamounts)
        {
            foreach (Order order in orderStore)
            {
                if (order.Detail.Productamounts == productamounts)
                {
                    idx = orderStore.IndexOf(order);
                    Console.WriteLine(order.Clientname + " " + order.Ordername + " " + order.Ordernumber + " " + order.Detail.Productname + " " + order.Detail.Productprice + " " + order.Detail.Productamounts);
                }

            }
            return idx;
        }
    }
    class DeleteException : ApplicationException
    {
        string Name { set; get; }
        public DeleteException(string message,string name) : base(message)
            {
            Name = name;
            }
        public string getName()
        {
            return Name;
        }
    }
    class CorrectExeption : ApplicationException
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
