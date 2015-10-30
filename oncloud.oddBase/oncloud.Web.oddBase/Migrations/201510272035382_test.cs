namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpecificationofRM", "RoadBarriers_id", "dbo.TheHorizontalRoadMarking");
            DropIndex("dbo.SpecificationOfRbs", new[] { "RoadBarriers_Id" });
            DropIndex("dbo.SpecificationofRM", new[] { "RoadBarriers_id" });
            RenameColumn(table: "dbo.SpecificationofRM", name: "RoadBarriers_id", newName: "TheHorizontalRoadMarking_id1");
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_Id", c => c.Int());
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_id", c => c.Int(nullable: false));
            AlterColumn("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationOfRbs", "RoadBarriers_Id");
            CreateIndex("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1");
            AddForeignKey("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1", "dbo.TheHorizontalRoadMarking", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1", "dbo.TheHorizontalRoadMarking");
            DropIndex("dbo.SpecificationofRM", new[] { "TheHorizontalRoadMarking_id1" });
            DropIndex("dbo.SpecificationOfRbs", new[] { "RoadBarriers_Id" });
            AlterColumn("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1", c => c.Int());
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_id", c => c.Int());
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.SpecificationofRM", name: "TheHorizontalRoadMarking_id1", newName: "RoadBarriers_id");
            CreateIndex("dbo.SpecificationofRM", "RoadBarriers_id");
            CreateIndex("dbo.SpecificationOfRbs", "RoadBarriers_Id");
            AddForeignKey("dbo.SpecificationofRM", "RoadBarriers_id", "dbo.TheHorizontalRoadMarking", "id");
        }
    }
}
