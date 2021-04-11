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
    public partial class Flights : Form
    {
        static string cs = "Host=localhost;Username=postgres;Password=Spawn777;Database=Air Timetable";
        static NpgsqlConnection con = new NpgsqlConnection(cs);

        private DataSet ds1 = new DataSet();

        public Flights()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm:ss";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd.MM.yyyy HH:mm:ss";

            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT name_flight, departure_time, departure_airport, arrival_time, arrival_airport, aircraft from flights", con);
            adap.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter($"insert into flights (name_flight, departure_airport, departure_time, arrival_airport, arrival_time, aircraft) values ('{textBox1.Text}', '{textBox2.Text}', '{dateTimePicker1.Text}', '{textBox4.Text}', '{dateTimePicker2.Text}', '{textBox6.Text}')", con);
            adap.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter($"update flights set name_flight = '{textBox1.Text}', departure_airport = '{textBox2.Text}', departure_time = '{dateTimePicker1.Text}', arrival_airport = '{textBox4.Text}', arrival_time = '{dateTimePicker2.Text}', aircraft = '{textBox6.Text}' where name_flight = '{textBox1.Text}'", con);
            adap.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter($"delete from flights where name_flight = '{textBox1.Text}'", con);
            adap.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
        }
    }
}
