namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteRoadSIngs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpecificationofRS", "RoadSigns_id1", "dbo.RoadSigns");
            DropIndex("dbo.SpecificationofRS", new[] { "RoadSigns_id1" });
            DropColumn("dbo.SpecificationofRS", "RoadSigns_id");
            DropColumn("dbo.SpecificationofRS", "RoadSigns_id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SpecificationofRS", "RoadSigns_id1", c => c.Int());
            AddColumn("dbo.SpecificationofRS", "RoadSigns_id", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationofRS", "RoadSigns_id1");
            AddForeignKey("dbo.SpecificationofRS", "RoadSigns_id1", "dbo.RoadSigns", "id");
        }
    }
}
