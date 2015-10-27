namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecificationOfRbs", "RoadBarriers_id", c => c.Int(nullable: false));
            AddColumn("dbo.SpecificationOfRbs", "RoadBarriers_id1", c => c.Int());
            AddColumn("dbo.SpecificationofRM", "RoadBarriers_id", c => c.Int(nullable: false));
            AddColumn("dbo.SpecificationofRS", "RoadSigns_id", c => c.Int(nullable: false));
            AddColumn("dbo.SpecificationofRS", "RoadSigns_id1", c => c.Int());
            CreateIndex("dbo.SpecificationOfRbs", "RoadBarriers_id1");
            CreateIndex("dbo.SpecificationofRM", "RoadBarriers_id");
            CreateIndex("dbo.SpecificationofRS", "RoadSigns_id1");
            AddForeignKey("dbo.SpecificationOfRbs", "RoadBarriers_id1", "dbo.RoadBarriers", "id");
            AddForeignKey("dbo.SpecificationofRM", "RoadBarriers_id", "dbo.TheHorizontalRoadMarking", "id", cascadeDelete: true);
            AddForeignKey("dbo.SpecificationofRS", "RoadSigns_id1", "dbo.RoadSigns", "id");
            DropColumn("dbo.SpecificationofRM", "Mackup");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SpecificationofRM", "Mackup", c => c.String(nullable: false));
            DropForeignKey("dbo.SpecificationofRS", "RoadSigns_id1", "dbo.RoadSigns");
            DropForeignKey("dbo.SpecificationofRM", "RoadBarriers_id", "dbo.TheHorizontalRoadMarking");
            DropForeignKey("dbo.SpecificationOfRbs", "RoadBarriers_id1", "dbo.RoadBarriers");
            DropIndex("dbo.SpecificationofRS", new[] { "RoadSigns_id1" });
            DropIndex("dbo.SpecificationofRM", new[] { "RoadBarriers_id" });
            DropIndex("dbo.SpecificationOfRbs", new[] { "RoadBarriers_id1" });
            DropColumn("dbo.SpecificationofRS", "RoadSigns_id1");
            DropColumn("dbo.SpecificationofRS", "RoadSigns_id");
            DropColumn("dbo.SpecificationofRM", "RoadBarriers_id");
            DropColumn("dbo.SpecificationOfRbs", "RoadBarriers_id1");
            DropColumn("dbo.SpecificationOfRbs", "RoadBarriers_id");
        }
    }
}
