namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_city_to_intelliStreet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IntelliSenseStreet", "CityId", c => c.Int(nullable: false, defaultValue:1));
            CreateIndex("dbo.IntelliSenseStreet", "CityId");
            AddForeignKey("dbo.IntelliSenseStreet", "CityId", "dbo.City", "id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IntelliSenseStreet", "CityId", "dbo.City");
            DropIndex("dbo.IntelliSenseStreet", new[] { "CityId" });
            DropColumn("dbo.IntelliSenseStreet", "CityId");
        }
    }
}
