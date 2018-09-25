using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homwwork2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //方法1
            //int a = Convert.ToInt32(textBox1.Text.Trim());
            // int b = Convert.ToInt32(textBox2.Text.Trim());
            //int s = a * b;
            //label1.Text = Convert.ToString($"{a}和{b}的乘积是：{s}");
            //方法2
            //label1.Text = (int.Parse(textBox1.Text) * int.Parse(textBox2.Text)).ToString();
            //方法3
            //double a = double.Parse(textBox1.Text);
            // double b = double.Parse(textBox2.Text);
            //label1.Text = (a * b).ToString();
            //方法4：
            double a, b;
            if (double.TryParse(textBox1.Text, out a) == false)
            {
                MessageBox.Show("输入值无法转换为double型");
            }
            if (double.TryParse(textBox2.Text, out b) == false)
            {
                MessageBox.Show("输入值无法转换为double型");
            }
            try
            {
                label1.Text = (a * b).ToString();
            }
            catch
            {
                MessageBox.Show("输出值无法转换为string型");
            }
        }
    }
}
