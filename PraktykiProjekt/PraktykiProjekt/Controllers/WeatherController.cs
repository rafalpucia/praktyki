using PraktykiProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PraktykiProjekt.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cities()
        {
            var service = new WeatherService();

            var model = new CitiesViewModel();
            model.UsersCities = service.GetCitiesForUser();

            return View(model);

        }

        [HttpPost]
        public ActionResult Cities(string city)
        {
            var service = new WeatherService();

            service.AddCityForUser(city);

            var model = new CitiesViewModel();
            model.UsersCities = service.GetCitiesForUser();

            return View(model);

        }

        public ActionResult Delete(int? cityId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var city = ctx.Cities.Find(cityId);
                return View(city);
            }
        }

        [HttpPost]
        public ActionResult Delete(int cityId)
        {
            var service = new WeatherService();
            service.DeleteUsersCity(cityId);

            return RedirectToAction("Cities");

        }

        public ActionResult Statistics()
        {
            var service = new WeatherService();
            var cities = service.GetCitiesForUser();
            return View(cities);
        }

        public ActionResult Autocomplete(string term)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var items = ctx.Cities.Select(u => u.Name).ToArray();
                //var items = new[] { "Apple", "Pear", "Banana", "Pineapple", "Peach" };

                var filteredItems = items.Where(
                    item => item.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0
                    );
                return Json(filteredItems, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetChartData(int cityId)
        {
            var jsonResult = new JsonResult();

            var service = new WeatherService();
            var weatherList = service.GetWeathersForCity(cityId);
            var result = new List<PlotElement>();
            foreach (var item in weatherList)
            {
                result.Add(new PlotElement { Date = item.Time.ToString("yyyy-MM-dd hh:mm:ss"), Humidity = item.Humidity, Temperature = item.Temperature });
            }
            jsonResult.Data = result;
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonResult;
        }

    }
}