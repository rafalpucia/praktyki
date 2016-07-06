namespace PraktykiProjekt.Migrations
{
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;

    internal sealed class Configuration : DbMigrationsConfiguration<PraktykiProjekt.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PraktykiProjekt.Models.ApplicationDbContext context)
        {
            using (StreamReader r = new StreamReader("C:/Users/rafal/Desktop/PraktykiProjekt/PraktykiProjekt/Json/city.list.json"))
            {
                /*
                string line;
                var cities = new List<City>();
                //using (var context = new ApplicationDbContext())
                {
                    while ((line = r.ReadLine()) != null)
                    {
                        dynamic array = JsonConvert.DeserializeObject(line);

                        context.Cities.AddOrUpdate(new City() { CityId = array._id, Country = array.country, Name = array.name, _id = array._id });
                    }
                }
            }
            */

                //  This method will be called after migrating to the latest version.

                //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
                //  to avoid creating duplicate seed data. E.g.
                //
                //    context.People.AddOrUpdate(
                //      p => p.FullName,
                //      new Person { FullName = "Andrew Peters" },
                //      new Person { FullName = "Brice Lambson" },
                //      new Person { FullName = "Rowan Miller" }
                //    );
                //
            }
        }
    }
}
