namespace PraktykiProjekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relacjausercity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weathers",
                c => new
                    {
                        WeatherId = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Temperature = c.Double(nullable: false),
                        Humidity = c.Int(nullable: false),
                        City_CityId = c.Int(),
                    })
                .PrimaryKey(t => t.WeatherId)
                .ForeignKey("dbo.Cities", t => t.City_CityId)
                .Index(t => t.City_CityId);
            
            CreateTable(
                "dbo.ApplicationUserCities",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        City_CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.City_CityId })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.City_CityId, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.City_CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weathers", "City_CityId", "dbo.Cities");
            DropForeignKey("dbo.ApplicationUserCities", "City_CityId", "dbo.Cities");
            DropForeignKey("dbo.ApplicationUserCities", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserCities", new[] { "City_CityId" });
            DropIndex("dbo.ApplicationUserCities", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Weathers", new[] { "City_CityId" });
            DropTable("dbo.ApplicationUserCities");
            DropTable("dbo.Weathers");
        }
    }
}
