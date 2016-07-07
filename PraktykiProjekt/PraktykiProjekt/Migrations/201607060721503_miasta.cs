namespace PraktykiProjekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class miasta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cities");
        }
    }
}
