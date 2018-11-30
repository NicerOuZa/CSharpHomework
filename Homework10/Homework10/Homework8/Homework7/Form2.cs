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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private long orderNum;
        private long phoneNum;
        private void Form2_Load(object sender, EventArgs e)
        {
            numericUpDown1.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            //新建订单
                DateTime nowDate = DateTime.Now;               
                orderNum = Convert.ToInt64(nowDate.Date.ToString("yyyyMMdd") + this.textBox1.Text);
                //检查订单号是否重复
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
                phoneNum = Convert.ToInt64(this.numericUpDown1.Text);
                if (phoneNum < 10000000000)
                {
                    MessageBox.Show("请输入正确的11位手机号码！");
                    return;
                }
                OrderService.AddOrder(orderNum, orderGood, client, orderSum,phoneNum);
                DBO.insert(orderNum, orderGood, client, phoneNum, orderSum);

             //添加到Form1的CommonBox中
                Form1.form1.comboBox1.DataSource = null;
                Form1.form1.comboBox1.DataSource = OrderService.allOrders;
                Form1.form1.comboBox1.DisplayMember = "OrderNum";
                //string str = String.Format("订单号：{0}   商品名称：{1}   客户：{2}   金额：{3}", this.textBox1.Text, this.textBox2.Text,
                //    this.textBox3.Text, this.textBox4.Text);
                //Form1.form1.comboBox1.Items.Add(str);
                Form1.form1.comboBox1.SelectedIndex = 0;
                this.Close();
            }
            catch (Exception exception)
            {

                MessageBox.Show("请正确输入订单");
            }
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            phoneNum = Convert.ToInt64(this.numericUpDown1.Text);
            if (phoneNum > 10000000000 && phoneNum < 99999999999)
            {
                label6.ForeColor = Color.Green;
                label6.Text = "手机号格式正确！";
            }
            else
            {
                label6.ForeColor = Color.Red;
                label6.Text = "请输入11位手机号！";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DateTime nowDate = DateTime.Now;
            orderNum = Convert.ToInt64(nowDate.Date.ToString("yyyyMMdd") + this.textBox1.Text);
            foreach (Order temp in OrderService.allOrders)
            {
                if (temp.OrderNum == orderNum)
                {
                    label7.Text = "订单号重复！";
                    label7.ForeColor = Color.Red;                       
                    return;
                }
            }

            label7.Text = "";
        }
    }
}
