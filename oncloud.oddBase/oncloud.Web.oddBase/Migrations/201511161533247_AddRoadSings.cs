namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoadSings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecificationofRS", "RoadSignsId", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationofRS", "RoadSignsId");
            AddForeignKey("dbo.SpecificationofRS", "RoadSignsId", "dbo.RoadSigns", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecificationofRS", "RoadSignsId", "dbo.RoadSigns");
            DropIndex("dbo.SpecificationofRS", new[] { "RoadSignsId" });
            DropColumn("dbo.SpecificationofRS", "RoadSignsId");
        }
    }
}
