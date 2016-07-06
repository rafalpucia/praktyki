using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraktykiProjekt.Models
{
    public class Weather
    {
        public int WeatherId { get; set; }
        public City City { get; set; }

        public DateTime Time { get; set; }
        public double Temperature { get; set; }
        public int Humidity { get; set; }
    }
}