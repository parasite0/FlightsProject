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
    public partial class Aircraft : Form
    {
        static string cs = "Host=localhost;Username=postgres;Password=Spawn777;Database=Air Timetable";
        static NpgsqlConnection con = new NpgsqlConnection(cs);

        private DataSet ds1 = new DataSet();

        public Aircraft()
        {
            InitializeComponent();

            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * from aircraft", con);
            adap.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter($"insert into aircraft (model, number_seats) values ('{textBox1.Text}', '{textBox2.Text}')", con);
            adap.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter($"update aircraft set model = '{textBox1.Text}', number_seats = '{textBox2.Text}' where model = '{textBox1.Text}'", con);
            adap.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter($"delete from aircraft where model = '{textBox1.Text}'", con);
            adap.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
        }
    }
}
