using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Xsl;

namespace Homework7
{
    class OrderService
    {
        public static List<Order> allOrders = new List<Order>();
        private static int count = 0;


        static public void AddOrder(long orderNum, string goodName, string client, double orderSum,long phoneNum)//添加订单
        {
            allOrders.Add(new Order(orderNum, goodName, client, orderSum,phoneNum));
            count++;
        }



        static public void RemoveOrder(long orderNum)     //删除指定订单，根据订单号删
        {
            try
            {
                var res = from order in allOrders where order.OrderNum == orderNum select order;
                Order a = res.Single();
                allOrders.Remove(a);
            }
            catch
            {
                Console.WriteLine("删除订单失败，没有与之相匹配的订单");
            }
        }

        static public Order InquiryOrder(long orderNum)                 //根据订单号查询订单信息
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

        static public void Export(string htmlName)
        {
            Order[] orders = new Order[allOrders.Count];
            for (int i = 0; i < allOrders.Count; i++)
            {
                orders[i] = allOrders[i];
            }


            String xmlFileName = "s.xml";
            FileStream fs = new FileStream(xmlFileName, FileMode.Create);
            XmlSerializer xmlser = new XmlSerializer(typeof(Order[]));
            xmlser.Serialize(fs, orders);
            fs.Close();


            XslCompiledTransform trans = new XslCompiledTransform();
            trans.Load("XSLTFile1.xslt");
            trans.Transform(xmlFileName, htmlName);
        }

    }
}
