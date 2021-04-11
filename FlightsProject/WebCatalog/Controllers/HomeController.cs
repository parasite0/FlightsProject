using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace WebCatalog.Controllers
{
    public class HomeController : Controller
    {

        
        public IActionResult Index()
        {
            return View();
        }

        public List<string> searchFlights(string departure, string arrival, DateTime date)
        {
            List<string> Flights = new List<string>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=Spawn777;Port=5432;Database=Air Timetable;");
            conn.Open();

            string sql;
            sql = $"SELECT name_flight, departure_airport, departure_time, arrival_airport, arrival_time, aircraft FROM flights where departure_airport ilike '{departure}' and arrival_airport ilike '{arrival}' and date_trunc('day', departure_time) = '{date}'";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            List<string> str = new List<string>();
            while (dr.Read())
            {               
                str.Add("&nbspНомер рейса: " + dr.GetValue(0).ToString() + "; Откуда: " + dr.GetValue(1).ToString() + "; Время вылета: " + dr.GetDateTime(2) + "; Куда: " + dr.GetValue(3).ToString() + "; Время прилёта: " + dr.GetDateTime(4) + "; Самолёт: " + dr.GetValue(5).ToString() + "<br/>" + "<br/>");
            }
            dr.Close();
            conn.Close();
            return str;
        }
    }
}
