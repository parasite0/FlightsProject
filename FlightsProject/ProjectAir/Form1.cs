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
    public partial class Form1 : Form
    {
        static string cs = "Host=localhost;Username=postgres;Password=Spawn777;Database=Air Timetable";
        static NpgsqlConnection con = new NpgsqlConnection(cs);

        public Form1()
        {
            InitializeComponent();

            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Flights flights = new Flights();
            flights.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tickets tickets = new Tickets();
            tickets.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Airports airports = new Airports();
            airports.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Aircraft aircraft = new Aircraft();
            aircraft.Show();
        }
    }
}
