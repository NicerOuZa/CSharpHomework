using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    class OrderService
    {
        static List<Order> allOrders = new List<Order>();
        private static int count = 0;


        static public void AddOrder(int orderNum, string goodName, string client, double orderSum)//添加订单
        {
            allOrders.Add(new Order(orderNum, goodName, client, orderSum));
            count++;
        }



        static public void RemoveOrder(int orderNum)     //删除指定订单，根据订单号删
        {

            //foreach (var or in allOrders)
            //{
            //    if (or.OrderNum == orderNum)
            //    {
            //        allOrders.Remove(or);
            //        count--;
            //        return;
            //    }
            //}
            //Console.WriteLine("删除订单失败，没有与之相匹配的订单");

            try
            {
                var res =allOrders
                         .Where(od => od.OrderNum == orderNum)
                         .Select(od=>od);
                Order a = (Order)res;
                allOrders.Remove(a);
            }
            catch
            {
                Console.WriteLine("删除订单失败，没有与之相匹配的订单");
            }
        }

        static public Order InquiryOrder(int orderNum)                 //根据订单号查询订单信息
        {       
            var res = from order in allOrders where order.OrderNum == orderNum select order;
            Order a = res.Single();
            return a;
        }
        static public Order InquiryOrder(string orderGood)                 //根据订单号查询订单信息
        {
            var res = from order in allOrders where order.GoodName == orderGood select order;
            Order a = res.Single();
            return a;
        }
        static public Order InquiryOrder_(string Client)                 //根据订单号查询订单信息
        {
            var res = from order in allOrders where order.Client == Client select order;
            Order a = res.Single();
            return a;
        }

        static public void AmendOrder(int orderNum, string goodName, string client, double orderSum)
        {
                var res = from order in allOrders where order.OrderNum == orderNum select order;
                Order a = res.Single();
              
                a.GoodName = goodName;
                a.Client = client;
                a.OrderSum = orderSum;
        }

    }
}
