using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    
   public  class Program1
    {
        static void Main(string[] args)
        {
            int sum = 0;
            Console.WriteLine("作业一：输出用户指定数字的所有素数因子");
            Console.WriteLine("请输入一个正整数来找出它的所有素数因子：");
            try
            {
                 sum = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("输入值不是整数，非法！");
            }
            Console.WriteLine("{0}的所有素数因子为：",sum);
            for(int i = 2;i<=sum;i++)
            {
                for (int j = 2; j <= i / 2+1; j++)
                {

                    if ((i % j == 0)&&(i!=j))
                        break;
                        if ((i == j) || (j == i / 2 + 1))
                   {  
                           if(sum%i==0)
                        Console.Write(i.ToString() + '\t');
                    }

                }
            }  
            Console.WriteLine("作业二提供了两种方法，第一种用库函数，第二种用list和自定义函数，请选择：（1 or 2）");
                var select = Console.ReadLine();
                switch (select)
                {
                  case "1": Program2.ArrayList1(); break;   //两种调用，一行代码的需要加 static
                  case "2":Program2 B = new Program2();
                  var numberList = new List<double>(); 
                   B.ArrayList2(numberList);
                   B.fun(numberList);break;
                  default: Console.WriteLine("你输入的选择不合法！");break;
            }
            Program3.selection();
        }                            
        }
    }
    
