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

namespace uchpr2
{
    public partial class redact : Form
    {
        static string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=b1;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        Form1 form1;
        public redact(Form1 form)
        {
            InitializeComponent();
            form1 = form;        
            service currentService = context.GetTable<service>().FirstOrDefault(
x => x.ID == Convert.ToInt32(form1.dataGridView1.CurrentRow.Cells[0].Value));
            textBox1.Text = currentService.Title;
            textBox2.Text = Convert.ToString(currentService.Cost);
            textBox3.Text = Convert.ToString(currentService.DurationInSeconds);
            textBox4.Text = Convert.ToString(currentService.Description);
            textBox5.Text = Convert.ToString(currentService.Discount);
            textBox6.Text = currentService.MainImagePath;
            Table<service> service = context.GetTable<service>();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            service currentService = context.GetTable<service>().FirstOrDefault(
x => x.ID == Convert.ToInt32(form1.dataGridView1.CurrentRow.Cells[0].Value));
            currentService.Title = textBox1.Text;
            currentService.Cost = Convert.ToInt32(textBox2.Text);
            currentService.DurationInSeconds = Convert.ToInt32(textBox3.Text);
            currentService.Description = textBox4.Text;
            currentService.Discount = Convert.ToInt32(textBox5.Text);
            currentService.MainImagePath = textBox6.Text;
            context.SubmitChanges();
            Table<service> service = context.GetTable<service>();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
