using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ProjectAir
{
    public partial class Tickets : Form
    {
        static string cs = "Host=localhost;Username=postgres;Password=Spawn777;Database=Air Timetable";
        static NpgsqlConnection con = new NpgsqlConnection(cs);

        private DataSet ds1 = new DataSet();

        public Tickets()
        {
            InitializeComponent();

            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT full_name, no_flight from tickets", con);
            adap.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter($"insert into tickets (full_name, no_flight) values ('{textBox1.Text}', '{textBox2.Text}')", con);
            adap.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter($"update tickets set full_name = '{textBox1.Text}', no_flight = '{textBox2.Text}' where full_name = '{textBox1.Text}'", con);
            adap.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter($"delete from tickets where full_name = '{textBox1.Text}'", con);
            adap.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
        }
    }
}
