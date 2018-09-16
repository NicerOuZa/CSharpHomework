using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class Program3
    {
        public static void selection()
        {
            Console.WriteLine("作业三：用埃氏晒法求2-100以内的素数：");
            List<int> number = new List<int>();
            for (int i = 0, y = 2; i < 98; i++, y++)
            {
                number.Add(y); // 给空的集合注入2到99的值，用于计算
            }
            for (int i = 0; i < number.Count(); i++)
            {
                for (int j = 0; j < number.Count(); j++)
                {
                    if ((number[i] % number[j] == 0) && (number[j] != number[i]))
                    {
                        number.Remove(number[i]);
                        i--;
                        break;
                    }
                    else if (number[j] == number[i])
                        break;
                }                
            }
           foreach(int k in number)
            {
                Console.Write(k.ToString()+' ');
            }
            Console.Read();
        }
        }
 }
    

