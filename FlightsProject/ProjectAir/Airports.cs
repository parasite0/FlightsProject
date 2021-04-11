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
    public partial class Airports : Form
    {
        static string cs = "Host=localhost;Username=postgres;Password=Spawn777;Database=Air Timetable";
        static NpgsqlConnection con = new NpgsqlConnection(cs);

        private DataSet ds1 = new DataSet();

        public Airports()
        {
            InitializeComponent();

            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * from airports", con);
            adap.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter($"insert into airports (name_airport, city) values ('{textBox1.Text}', '{textBox2.Text}')", con);
            adap.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter($"update airports set name_airport = '{textBox1.Text}', city = '{textBox2.Text}' where name_airport = '{textBox1.Text}'", con);
            adap.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter($"delete from airports where name_airport = '{textBox1.Text}'", con);
            adap.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
        }
    }
}
