using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    [Serializable]
    public class Order
    {
        public Order(long orderNum, string goodName, string client, double orderSum,long PhoneNum)
        {
            this.OrderNum = orderNum;
            this.GoodName = goodName;
            this.Client = client;
            this.OrderSum = orderSum;
            this.PhoneNum = PhoneNum;
        }
        public Order()
        {

        }

        public long OrderNum
        {
            get;
            set;
        }
        public string GoodName
        {
            get;
            set;
        }
        public string Client
        {
            get;
            set;
        }
        public double OrderSum
        {
            get;
            set;
        }
        public long PhoneNum
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Convert.ToString(OrderNum);
        }
    }
}
