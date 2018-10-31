using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    class Order
    {
        public Order(int orderNum, string goodName, string client, double orderSum)
        {
            this.OrderNum = orderNum;
            this.GoodName = goodName;
            this.Client = client;
            this.OrderSum = orderSum;
        }

        public int OrderNum
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
    }
}
