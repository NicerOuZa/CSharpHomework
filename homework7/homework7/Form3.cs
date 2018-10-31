using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework7
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int orderNum = Convert.ToInt32(this.textBox1.Text);
                Order order = OrderService.InquiryOrder(orderNum);
                Order order2 = new Order(order.OrderNum,order.GoodName,order.Client,order.OrderSum);
                
                    if (!(this.textBox2.Text == ""))
                    {
                        order.OrderNum = Convert.ToInt32(textBox2.Text);
                    }
                    if (!(this.textBox3.Text == ""))
                    {
                        order.GoodName = textBox3.Text;
                    }
                    if (!(this.textBox4.Text == ""))
                    {
                        order.Client = textBox4.Text;
                    }
                    if (!(this.textBox5.Text == ""))
                    {
                        order.OrderSum = Convert.ToDouble(textBox5.Text);
                    }

               
                    

                    if (this.textBox2.Text == "" & this.textBox3.Text == "" & this.textBox4.Text == "" & this.textBox5.Text == "")
                    {
                        MessageBox.Show("您未修改任何内容！");
                    }
                    else
                    {
                        string str = String.Format("订单号：{0}   商品名称：{1}   客户：{2}   金额：{3}", order2.OrderNum, order2.GoodName,
                            order2.Client, order2.OrderSum);
                        int cF = Form1.form1.comboBox1.FindString(str);
                        Form1.form1.comboBox1.Items.RemoveAt(cF);
                        str = String.Format("订单号：{0}   商品名称：{1}   客户：{2}   金额：{3}", order.OrderNum, order.GoodName,
                            order.Client, order.OrderSum);
                        Form1.form1.comboBox1.Items.Add(str);
                        Form1.form1.comboBox1.SelectedIndex = 0;
                    this.Close();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("没有找到此订单或您修改的内容有误！");
                }
              
                
                //while (count <10)
                //{                 
                //    if (this.textBox2.Text == "")
                //    {
                //        if (this.textBox3.Text == "")
                //        {
                //            if (this.textBox4.Text == "")
                //            {
                //                if (this.textBox5.Text == "")
                //                {
                //                    MessageBox.Show("您未修改任何内容！");
                //                    break;
                //                }
                //                else
                //                {
                //                    order.OrderSum = Convert.ToDouble(textBox5.Text);
                //                }
                //            }
                //            else
                //            {
                //                order.Client = textBox4.Text;
                //                break;
                //            }
                //        }
                //        else
                //        {
                //            order.GoodName = textBox3.Text;
                //        }
                //    }
                //    else
                //    {
                //        order.OrderNum = Convert.ToInt32(textBox2.Text);
                //    }

                //    count++;
                //}

            
            
        }
    }
}
