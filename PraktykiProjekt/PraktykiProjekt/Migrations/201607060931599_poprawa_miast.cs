namespace PraktykiProjekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poprawa_miast : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cities", "_id");
        }
    }
}
