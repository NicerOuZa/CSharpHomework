using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    //求一个整数数组的最大值最小值平均值和所有元素的和
    public  class Program2
    {
 


//参考了CSDN上创建动态数组的方法
//方法一：通过 Splist()和Join()函数
        public static void ArrayList1()
        {
            Console.WriteLine("作业二：通过 Splist()和Join()函数求一个整数数组的最大值最小值平均值和所有元素的和");
            Console.WriteLine("Please input numbers in format (1 2 3 4 ...100)，输入一个数字后敲一下空格即可！");
            var input = Console.ReadLine();
            var strings = input.Split(' ');
            var numbers = new int[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                numbers[i] = Convert.ToInt32(strings[i]);
            }
            Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine("数组的和是："+numbers.Sum().ToString());
            Console.WriteLine("数组的最大值是" + numbers.Max().ToString() + ' ' + "最小值是：" + numbers.Min().ToString());
            Console.WriteLine("数组的平均值：" + (numbers.Sum()/ strings.Length).ToString());
            Console.Read();
        }
//方法二：利用List<double>,书201
         public  void ArrayList2(List<double>list)
        {
            Console.WriteLine("作业二：利用List<double>和Join()函数求一个整数数组的最大值最小值平均值和所有元素的和");
            var input = string.Empty;      
            Console.WriteLine("While inputting numbers,Please input \"end\" to stop sorting the array.");
            while (!input.Equals("end"))
            {
                input = Console.ReadLine();
                if (!input.Equals("end"))
                {
                    list.Add(Convert.ToDouble(input));
                }
            }
            Console.WriteLine("array: {0}", string.Join(" ", list));
        }
        public  void fun(List<double> list)
        {
           double n=0, ave, sum=0,item;
            double[] nums = list.ToArray();
            double max = nums[0], min = max = nums[0];
            foreach (double i in list)
            {
                item = i;
                n++;
                sum += i;
                if(max<item)
                {
                    max = item;
                }
                if (min > item)
                {
                    min = item;
                }
            }
            ave = sum / n;
            Console.WriteLine("数组的和是："+sum.ToString());
            Console.WriteLine("数组的平均值："+ave.ToString());
            Console.WriteLine("数组的最大值是"+max.ToString() +' '+"最小值是："+ min.ToString());
        }
    }
}