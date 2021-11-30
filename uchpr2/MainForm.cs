using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uchpr2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string login = "f";
            string password = "123";
            if (textBox1.Text == login && textBox2.Text == password)
            {
                Form1 f2 = new Form1(true);
                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f2 = new Form1(false);
            f2.ShowDialog();
        }
    }
}
