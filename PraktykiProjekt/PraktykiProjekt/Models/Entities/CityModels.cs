using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraktykiProjekt.Models
{
    public class City
    {
        public int CityId { get; set; }

        public int _id { get; set;}
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual List<ApplicationUser> UserList { get; set; }
        public virtual List<Weather> WeatherList { get; set; }

        public City()
        {
            UserList = new List<ApplicationUser>();
            WeatherList = new List<Weather>();
        }
    }
}