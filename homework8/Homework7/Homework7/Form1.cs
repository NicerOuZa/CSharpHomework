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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            form1 = this;
        }

        public static Form1 form1;
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBox1.SelectedItem.ToString() == "")
                {
                    if (this.textBox2.Text == "")
                    {
                        if (this.textBox3.Text == "")
                        {
                            MessageBox.Show("请输入要查询的条件！");
                        }
                        else
                        {
                            string client = this.textBox3.Text;
                            Order order = OrderService.InquiryOrder_(client);
                            string str = String.Format("订单号：{0}   商品名称：{1}   客户：{2}   金额：{3}   电话号码：{4}", order.OrderNum, order.GoodName,
                                order.Client, order.OrderSum, order.PhoneNum);
                            MessageBox.Show(str);
                        }
                    }
                    else
                    {
                        string goodName = this.textBox2.Text;
                        Order order = OrderService.InquiryOrder(goodName);
                        string str = String.Format("订单号：{0}   商品名称：{1}   客户：{2}   金额：{3}   电话号码：{4}", order.OrderNum, order.GoodName,
                            order.Client, order.OrderSum, order.PhoneNum);
                        MessageBox.Show(str);
                    }
                }
                else
                {
                    long orderNum = Int64.Parse(this.comboBox1.SelectedItem.ToString());
                    Order order = OrderService.InquiryOrder(orderNum);
                    string str = String.Format("订单号：{0}   商品名称：{1}   客户：{2}   金额：{3}   电话号码：{4}", order.OrderNum, order.GoodName,
                        order.Client, order.OrderSum,order.PhoneNum);
                    MessageBox.Show(str);
                }
                
                

            }
            catch (Exception exception)
            {
                MessageBox.Show("没有查到此订单！");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isfind = false;
            foreach (Form fm in Application.OpenForms)
            {
                if (fm.Name == "Form2")
                {
                    fm.WindowState = FormWindowState.Maximized;
                    fm.WindowState = FormWindowState.Normal;
                    fm.Activate();
                    return;
                }
            }
            if (!isfind)
            {
                Form form = new Form2();
                form.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool isfind = false;
            foreach (Form fm in Application.OpenForms)
            {
                if (fm.Name == "Form3")
                {
                    fm.WindowState = FormWindowState.Maximized;
                    fm.WindowState = FormWindowState.Normal;
                    fm.Activate();
                    return;
                }
            }
            if (!isfind)
            {
                Form form = new Form3();
                form.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool isfind = false;
            foreach (Form fm in Application.OpenForms)
            {
                if (fm.Name == "Form4")
                {
                    fm.WindowState = FormWindowState.Maximized;
                    fm.WindowState = FormWindowState.Normal;
                    fm.Activate();
                    return;
                }
            }
            if (!isfind)
            {
                Form form = new Form4();
                form.Show();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
