using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PraktykiProjekt.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PraktykiProjekt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*
            using (StreamReader r = new StreamReader("C:/Users/rafal/Desktop/PraktykiProjekt/PraktykiProjekt/Json/city.list.json"))
            {
                
                string line;
                var cities = new List<City>();
                using (var context = new ApplicationDbContext())
                {
                    while ((line = r.ReadLine()) != null)
                    {
                        dynamic array = JsonConvert.DeserializeObject(line);
                        //cities.Add(new City { CityId = array._id, Country = array.country, Name = array.name });

                        context.Cities.Add(new City() { CityId = array._id, Country = array.country, Name = array.name, _id = array._id });
                        context.SaveChanges();
                    }
                    
                }
            }
            */
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}