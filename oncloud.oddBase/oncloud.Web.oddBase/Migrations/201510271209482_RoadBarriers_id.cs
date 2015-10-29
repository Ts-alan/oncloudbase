namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoadBarriers_id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpecificationofRM", "RoadBarriers_id", "dbo.TheHorizontalRoadMarking");
            DropIndex("dbo.SpecificationOfRbs", new[] { "RoadBarriers_Id" });
            DropIndex("dbo.SpecificationofRM", new[] { "RoadBarriers_id" });
            AddColumn("dbo.SpecificationofRM", "RoadBarriers_id1", c => c.Int(nullable: false));
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_Id", c => c.Int());
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_id", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationOfRbs", "RoadBarriers_Id");
            CreateIndex("dbo.SpecificationofRM", "RoadBarriers_id1");
            AddForeignKey("dbo.SpecificationofRM", "RoadBarriers_id1", "dbo.TheHorizontalRoadMarking", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecificationofRM", "RoadBarriers_id1", "dbo.TheHorizontalRoadMarking");
            DropIndex("dbo.SpecificationofRM", new[] { "RoadBarriers_id1" });
            DropIndex("dbo.SpecificationOfRbs", new[] { "RoadBarriers_Id" });
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_id", c => c.Int());
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_Id", c => c.Int(nullable: false));
            DropColumn("dbo.SpecificationofRM", "RoadBarriers_id1");
            CreateIndex("dbo.SpecificationofRM", "RoadBarriers_id");
            CreateIndex("dbo.SpecificationOfRbs", "RoadBarriers_Id");
            AddForeignKey("dbo.SpecificationofRM", "RoadBarriers_id", "dbo.TheHorizontalRoadMarking", "id", cascadeDelete: true);
        }
    }
}
