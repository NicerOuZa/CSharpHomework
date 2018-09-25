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
           double m,n,s;
            Console.Write("请输入两个数字以计算其乘积：");
            x = Console.ReadLine();
           //法1：  m = double.Parse(x);
            y = Console.ReadLine();
            if (double.TryParse(x, out m) == false)
            {
                 //MessageBox.Show("输入值无法转换为double型");
                Console.WriteLine("输入值无法转换为double型");
            }
            //n = double.Parse(y);
            if (double.TryParse(y, out n) == false)
            {
                Console.WriteLine("输入值无法转换为double型");
            }
                s = m * n;
            Console.WriteLine($"{m}和{n}的乘积是: {s}");
        }
    }
}
