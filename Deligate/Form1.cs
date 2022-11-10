using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountClass;

namespace Deligate
{
    public partial class Form1 : Form
    {
        string message;
        void PrintSimpleMessage(string message) => listBox1.Items.Add(message);
        public Form1()
        {
            InitializeComponent();
        }
        Account account;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            account = new Account(Convert.ToInt32(textBox2.Text), textBox1.Text);
            listBox1.Items.Add($"Владелец счёта: {account.fio}, сумма на счете: {account.sum}");
            account.RegisterHandler(PrintSimpleMessage);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            account.Add(Convert.ToInt32(textBox3.Text));
            listBox1.Items.Clear();
            listBox1.Items.Add($"Владелец счёта: {account.fio}, сумма на счете: {account.sum}");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox2.Text);
            if (account.sum < x)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("На счету нет cредств");
            }
            else
            {
                account.Take(Convert.ToInt32(textBox2.Text));
                listBox1.Items.Clear();
                listBox1.Items.Add($"Владелец счёта: {account.fio}, сумма на счете: {account.sum}");
            }
        }
    }
}
