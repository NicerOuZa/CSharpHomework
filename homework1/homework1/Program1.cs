using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    class Program1
    {
        static void Main(string[] args)
        {
           string x,y;
           double m, n,s;
            Console.Write("请输入两个数字以计算其乘积：");
            x = Console.ReadLine();
            m = double.Parse(x);
            y = Console.ReadLine();
            n = double.Parse(y);
            s = m * n;
            Console.WriteLine($"{m}和{n}的乘积是: {s}");
        }
    }
}
