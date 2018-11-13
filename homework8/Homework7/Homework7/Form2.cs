using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework7
{   
    public partial class Form2 : Form
    {
        public static bool judgePhonenumber(long phoneNum)
        {
            string str1 = @"^(13[0-9]|14[0-9]|15[0-9]|166|17[0-9]|18[0-9]|19[8|9])\d{8}$";
            // string str2 = @"^\d{4}\d{1,2}\d{1,2}\d{3}";
            Regex rx1 = new Regex(str1);
            //Regex rx2 = new Regex(str2);
            if (!rx1.IsMatch(phoneNum.ToString()))
            {
                MessageBox.Show("电话号码格式不对！");
                return false;
            }
            return true;
        }
        public Form2()
        {
            InitializeComponent();
        }
        private long orderNum;
        private long phoneNum;
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                //新建订单
                DateTime nowDate = DateTime.Now;
                orderNum = Convert.ToInt64(nowDate.Date.ToString("yyyyMMdd") + this.textBox1.Text);
                //检查订单号是否重复，用linq也可以，var a=.where.......，a.count()!=0就是存在

                foreach (Order temp in OrderService.allOrders)
                {
                    if (temp.OrderNum == orderNum)
                    {
                        MessageBox.Show("订单号重复！");
                        return;
                    }
                }
                string orderGood = this.textBox2.Text;
                string client = this.textBox3.Text;
                double orderSum = Convert.ToDouble(this.textBox4.Text);
                phoneNum = Convert.ToInt64(this.textBox5.Text);

            //else if (!rx2.IsMatch(orderNum.ToString()))
            //{
            //    MessageBox.Show("订单格式错误！（正确案例：19990126-123，日期加三位编号）");
            //    textBox1.Clear();
            //}
            if (judgePhonenumber(phoneNum))
            {
                OrderService.AddOrder(orderNum, orderGood, client, orderSum, phoneNum);

                //添加到Form1的CommonBox中
                Form1.form1.comboBox1.DataSource = null;
                Form1.form1.comboBox1.DataSource = OrderService.allOrders;
                Form1.form1.comboBox1.DisplayMember = "OrderNum";
                Form1.form1.comboBox1.SelectedIndex = 0;
                this.Close();
            }
                //}
            
            //catch (Exception exception)
            //{
            //    MessageBox.Show("请正确输入订单");
            //}
            
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DateTime nowDate = DateTime.Now;
            orderNum = Convert.ToInt64(nowDate.Date.ToString("yyyyMMdd") + this.textBox1.Text);
            foreach (Order temp in OrderService.allOrders)
            {
                if (temp.OrderNum == orderNum)
                {
                    label7.Text = "订单号重复了！";
                    label7.ForeColor = Color.Red;                       
                    return;
                }
            }

            label7.Text = "";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
