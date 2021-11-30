using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;


namespace uchpr2
{
    public partial class Form1 : Form
    {
        static string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=b1;Integrated Security=True";
        public int id;
        DataContext context = new DataContext(conStr);
        public Form1(bool isAdmin)
        { 
            InitializeComponent();
            if (isAdmin == true)
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                label1.Visible = true;
                comboBox1.Visible = true;
               
            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                label1.Visible = false;
                comboBox1.Visible = false;
            
            }
            Table<service> service = context.GetTable<service>();
            dataGridView1.DataSource = service.ToList();
            dataGridView1.DataSource = context.GetTable<service>().ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dobav f2 = new dobav();
            f2.ShowDialog();
            dataGridView1.DataSource = context.GetTable<service>().ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы точно хотите удалить?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (res == DialogResult.Yes)
            {
                //ClientServ clientServ = new ClientServ { ClientID = comboBox2.SelectedIndex, ServiceID = comboBox1.SelectedIndex, StartTime = dateTimePicker1.Value };
                //cont.GetTable<ClientServ>().InsertOnSubmit(clientServ);
                //cont.SubmitChanges();
                service currentAccount = context.GetTable<service>().FirstOrDefault(
x => x.ID == Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                context.GetTable<service>().DeleteOnSubmit(currentAccount);
                context.SubmitChanges();
                dataGridView1.DataSource = context.GetTable<service>().ToList();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            redact f3 = new redact(this);
            f3.ShowDialog();
            dataGridView1.DataSource = context.GetTable<service>().ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<service> services = null;
            switch (comboBox1.SelectedIndex)
            {
                case 0: services = context.GetTable<service>().Where(x => x.Discount < 0.05 && x.Discount > 0).ToList(); break;
                case 1: services = context.GetTable<service>().Where(x => x.Discount <= 0.15 && x.Discount > 0.05).ToList(); break;
                case 2: services = context.GetTable<service>().Where(x => x.Discount <= 0.3 && x.Discount > 0.15).ToList(); break;
                case 3: services = context.GetTable<service>().Where(x => x.Discount <= 0.7 && x.Discount > 0.3).ToList(); break;
                case 4: services = context.GetTable<service>().Where(x => x.Discount <= 1 && x.Discount > 0.7).ToList(); break;
                case 5: services = context.GetTable<service>().Where(x => x.Discount <= 1 && x.Discount > 0).ToList(); break;
            }
            dataGridView1.DataSource = services;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            record f = new record();
            f.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "Select *From [Service] Where [Title] Like N'%" + textBox1.Text + "%' ";
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            ad.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
