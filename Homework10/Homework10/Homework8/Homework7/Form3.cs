using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBtest;

namespace Homework7
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private long phoneNum;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                long orderNum = Convert.ToInt64(this.textBox1.Text);
                Order order = OrderService.InquiryOrder(orderNum);
                
                
                    if (!(this.textBox2.Text == ""))
                    {
                        //检查订单号是否重复
                        foreach (Order temp in OrderService.allOrders)
                        {
                            if (temp.OrderNum == Convert.ToInt64(textBox2.Text))
                            {
                                MessageBox.Show("订单号重复！");
                                return;
                            }
                        }
                        order.OrderNum = Convert.ToInt64(textBox2.Text);
                        DBO.update1(orderNum, Convert.ToInt64(textBox2.Text));
                    }
                    if (!(this.textBox3.Text == ""))
                    {
                        order.GoodName = textBox3.Text;
                        DBO.update2(Convert.ToInt64(textBox2.Text), textBox3.Text);
                    }
                    if (!(this.textBox4.Text == ""))
                    {
                        order.Client = textBox4.Text;
                        DBO.update3(Convert.ToInt64(textBox2.Text), textBox4.Text);
                }
                    if (!(this.textBox5.Text == ""))
                    {
                        order.OrderSum = Convert.ToDouble(textBox5.Text);
                        DBO.update5(Convert.ToInt64(textBox2.Text), Convert.ToDouble(textBox5.Text));
                    }
                if (!(this.numericUpDown1.Text == ""))
                {
                    phoneNum = Convert.ToInt64(this.numericUpDown1.Text);
                    if (phoneNum < 10000000000)
                    {
                        MessageBox.Show("请输入正确的11位手机号码！");
                        return;
                    }
                    order.PhoneNum = Convert.ToInt64(numericUpDown1.Text);
                    DBO.update4(Convert.ToInt64(textBox2.Text), Convert.ToInt64(numericUpDown1.Text));
                }




                if (this.textBox2.Text == "" & this.textBox3.Text == "" & this.textBox4.Text == "" & this.textBox5.Text == "")
                    {
                        MessageBox.Show("您未修改任何内容！");
                    }
                    else
                    {
                        Form1.form1.comboBox1.DataSource = null;
                        Form1.form1.comboBox1.DataSource = OrderService.allOrders;
                        Form1.form1.comboBox1.DisplayMember = "OrderNum";
                        Form1.form1.comboBox1.SelectedIndex = 0;
                        this.Close();
                    }
            }
            catch (Exception exception)
            {
                MessageBox.Show("没有找到此订单或您修改的内容有误！");
            }
              
                   
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            foreach (Order temp in OrderService.allOrders)
            {
                if (textBox2.Text != "" &&temp.OrderNum == Convert.ToInt32(textBox2.Text))
                {
                    label7.Text = "订单号重复！";
                    label7.ForeColor = Color.Red;
                    return;
                }
            }

            label7.Text = "";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            numericUpDown1.Text = "";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            phoneNum = Convert.ToInt64(this.numericUpDown1.Text);
            if (phoneNum > 10000000000 && phoneNum < 99999999999)
            {
                label9.ForeColor = Color.Green;
                label9.Text = "手机号格式正确！";
            }
            else
            {
                label9.ForeColor = Color.Red;
                label9.Text = "请输入11位手机号！";
            }
        }
    }
}
