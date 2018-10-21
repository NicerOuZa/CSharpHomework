using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework5.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.Xml;

namespace homework5.Program.Tests
{
    public class Order
    {
        public string Ordername { get; set; }
        public string Clientname { get; set; }
        public string Ordernumber { get; set; }
        public OrderDetails Detail = new OrderDetails();
        public Order(string Ordername,string Clientname,string Ordernumber)
        {
            this.Clientname = Clientname;
            this.Ordername = Ordername;
            this.Ordernumber = Ordernumber;
        }
        public Order() { }
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
    [TestClass()]
    public class OrderService2Tests
    {
        public Order[] od;
        public List<Order> orderStore = new List<Order>();
        [TestMethod()]
        public void AddOrderTest()
        {
            Order []od ={new Order(1.ToString(),2.ToString(),3.ToString()),new Order("a","b","c")
            };
            try
            {
                foreach(var item in od)
                orderStore.Add(item);
            }
            catch
            {
                Console.WriteLine("添加失败！");
            }
        }
        public XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));//new一个xml的Serializer对象来指向序列化的对象
        [TestMethod()]
        public void ExportTest()
        {
            FileStream fs = new FileStream("s.xml", FileMode.Create);
            try
            {               
               
                if (od.GetType().IsSerializable)
                {
                    xmlSerializer.Serialize(fs, od);
                    fs.Close();
                }
                else if (od == null)
                {
                    fs.Close();
                    throw new NullReferenceException();
                }
                else
                {
                    fs.Close();
                    throw new TargetParameterCountException();
                }
            }
            catch (TargetParameterCountException)
            {
                Console.WriteLine("  hahahaha  ");
             
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("未将对象引用设置到对象的实例");
            }
            finally
            {
                fs.Close();
            }
        }

        [TestMethod()]
        public void ImportTest()
        {
            string path = @"F:\C#\Git\homework6\homework6\bin\Debug\s.xml";
            try
            {

                using (FileStream fs = new FileStream("s.xml", FileMode.Open))
                {
                    if (fs.Position == 0)
                        throw new XmlException();
                    
                        else if (false == File.Exists(path))
                        throw new FileNotFoundException();
                    else
                    {
                        List<Order> lists = (List<Order>)xmlSerializer.Deserialize(fs);
                        foreach (var item in lists)
                        {
                            Console.WriteLine(item.ToString());
                        }

                    }
                }
                
            }
            catch(XmlException)
            {
                Console.WriteLine("进行了写入操作，最后流的位置停留在尾部。因此，要在反序列化之前将流的位置定位到开始 0 的位置");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("文件找不到哦");
            }
        }
    }
}