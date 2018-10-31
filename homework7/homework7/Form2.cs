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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //新建订单
                int orderNum = Convert.ToInt32(this.textBox1.Text);
                string orderGood = this.textBox2.Text;
                string client = this.textBox3.Text;
                double orderSum = Convert.ToDouble(this.textBox4.Text);
                OrderService.AddOrder(orderNum, orderGood, client, orderSum);

                //添加到Form1的CommonBox中
                string str = String.Format("订单号：{0}   商品名称：{1}   客户：{2}   金额：{3}", this.textBox1.Text, this.textBox2.Text,
                    this.textBox3.Text, this.textBox4.Text);
                Form1.form1.comboBox1.Items.Add(str);
                Form1.form1.comboBox1.SelectedIndex = 0;
                this.Close();
            }
            catch (Exception exception)
            {

                MessageBox.Show("请正确输入订单");
            }
            
        }
    }
}
