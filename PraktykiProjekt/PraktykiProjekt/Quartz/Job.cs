using PraktykiProjekt.Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace PraktykiProjekt.Quartz
{
    public class GetWeatherJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var service = new WeatherService();

            using (var ctx = new ApplicationDbContext())
            {
                var cities = ctx.Cities.Where(u => u.UserList.Count > 0).ToList();
                foreach (var item in cities)
                {
                    var w = service.GetWeatherFor(item._id);
                    var weather = new Weather() { Humidity = w.Humidity, Temperature = w.Temperature, City = item, Time = w.Time };
                    ctx.Weathers.Add(weather);
                    ctx.SaveChanges();
                }
            }
        }
    }
}