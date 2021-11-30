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
    public partial class record : Form
    {
        static string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=b1;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public record()
        {
            InitializeComponent();
            Table<clientserv> clservice = context.GetTable<clientserv>();
            dataGridView2.DataSource = clservice.ToList();
        }
        private void Добавить_Click(object sender, EventArgs e)
        {
            
            clientserv newclientServ = new clientserv { ClientID = Convert.ToInt32(comboBox1.SelectedValue), ServiceID = Convert.ToInt32(comboBox2.SelectedValue), StartTime = Convert.ToDateTime(dateTimePicker1.Value) };
            context.GetTable<clientserv>().InsertOnSubmit(newclientServ);
            context.SubmitChanges();
            dataGridView2.DataSource = context.GetTable<clientserv>().ToList();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void record_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "b1DataSet.Client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this.b1DataSet.Client);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "b1DataSet.Service". При необходимости она может быть перемещена или удалена.
            this.serviceTableAdapter.Fill(this.b1DataSet.Service);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "b1DataSet.ClientService". При необходимости она может быть перемещена или удалена.
            this.clientServiceTableAdapter.Fill(this.b1DataSet.ClientService);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form1 f1 = new Form1(false);
            //f1.Show();
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
