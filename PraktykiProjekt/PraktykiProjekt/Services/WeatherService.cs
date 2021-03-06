﻿using Newtonsoft.Json;
using PraktykiProjekt.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PraktykiProjekt
{
    public class WeatherService
    {
        public Weather GetWeatherFor(int id)
        {
            var result = new Weather();
            var uri = new StringBuilder();
            uri.Append("http://api.openweathermap.org/data/2.5/weather?id=");
            uri.Append(id);
            uri.Append("&APPID=31a9764e90f49c8b904515015bd6cdd8");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri.ToString());
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                using (var ctx = new ApplicationDbContext())
                {
                    dynamic w = JsonConvert.DeserializeObject(reader.ReadToEnd());
                    //cities.Add(new City { CityId = array._id, Country = array.country, Name = array.name });
                    result.Temperature = w.main.temp - 273.5;
                    result.Humidity = w.main.humidity;
                    result.Time = DateTime.Now;

                    return result;
                }
            }
        }

        public List<City> GetCitiesForUser()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var result = new List<City>();
                //var user = ctx.Users.Where(u => u.UserName == HttpContext.Current.User.Identity.Name).Single();

                result = ctx.Cities.Where(c => c.UserList.Select(u => u.UserName).Contains(HttpContext.Current.User.Identity.Name)).ToList();
                return result;
            }
        }

        public List<Weather> GetWeathersForCity(int cityId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Weathers.Where(u => u.City.CityId == cityId).ToList();
            }
        }

        public void AddCityForUser(string city)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var cityToDb = ctx.Cities.Where(u => u.Name == city).FirstOrDefault();
                var user = ctx.Users.Where(u => u.UserName == HttpContext.Current.User.Identity.Name).Single();

                if (!user.Cities.Contains(cityToDb) && !cityToDb.UserList.Contains(user))
                {
                    cityToDb.UserList.Add(user);
                    user.Cities.Add(cityToDb);
                    ctx.SaveChanges();
                }
            }
        }

        public void DeleteUsersCity(int cityId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var city = ctx.Cities.Find(cityId);
                var user = ctx.Users.Where(u => u.UserName == HttpContext.Current.User.Identity.Name).Single();

                ctx.Users.Find(user.Id).Cities.Remove(city);
                ctx.Cities.Find(city.CityId).UserList.Remove(user);

                ctx.SaveChanges();
            }
        }
    }
}