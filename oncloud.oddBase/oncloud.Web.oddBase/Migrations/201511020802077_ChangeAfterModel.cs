namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAfterModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SpecificationOfRbs", new[] { "RoadBarriers_id1" });
            DropColumn("dbo.SpecificationOfRbs", "RoadBarriers_id");
            RenameColumn(table: "dbo.SpecificationOfRbs", name: "RoadBarriers_id1", newName: "RoadBarriers_Id");
            RenameColumn(table: "dbo.SpecificationofRM", name: "RoadBarriers_id", newName: "TheHorizontalRoadMarking_id1");

            RenameIndex(table: "dbo.SpecificationofRM", name: "IX_RoadBarriers_id", newName: "IX_TheHorizontalRoadMarking_id1");

            AddColumn("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id", c => c.Int(nullable: false));
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_Id", c => c.Int());
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_id", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationOfRbs", "RoadBarriers_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SpecificationOfRbs", new[] { "RoadBarriers_Id" });
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_id", c => c.Int());
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_Id", c => c.Int(nullable: false));
            DropColumn("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id");
            RenameIndex(table: "dbo.SpecificationofRM", name: "IX_TheHorizontalRoadMarking_id1", newName: "IX_RoadBarriers_id");
            RenameColumn(table: "dbo.SpecificationofRM", name: "TheHorizontalRoadMarking_id1", newName: "RoadBarriers_id");
            RenameColumn(table: "dbo.SpecificationOfRbs", name: "RoadBarriers_Id", newName: "RoadBarriers_id1");
            AddColumn("dbo.SpecificationOfRbs", "RoadBarriers_id", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationOfRbs", "RoadBarriers_id1");
        }
    }
}
