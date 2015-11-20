namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTheHorizontalRoadMarking : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id", "dbo.TheHorizontalRoadMarking");
            DropIndex("dbo.SpecificationofRM", new[] { "TheHorizontalRoadMarking_id" });
            RenameColumn(table: "dbo.SpecificationofRM", name: "TheHorizontalRoadMarking_id", newName: "TheHorizontalRoadMarkingId");
            AlterColumn("dbo.SpecificationofRM", "TheHorizontalRoadMarkingId", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationofRM", "TheHorizontalRoadMarkingId");
            AddForeignKey("dbo.SpecificationofRM", "TheHorizontalRoadMarkingId", "dbo.TheHorizontalRoadMarking", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecificationofRM", "TheHorizontalRoadMarkingId", "dbo.TheHorizontalRoadMarking");
            DropIndex("dbo.SpecificationofRM", new[] { "TheHorizontalRoadMarkingId" });
            AlterColumn("dbo.SpecificationofRM", "TheHorizontalRoadMarkingId", c => c.Int());
            RenameColumn(table: "dbo.SpecificationofRM", name: "TheHorizontalRoadMarkingId", newName: "TheHorizontalRoadMarking_id");
            CreateIndex("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id");
            AddForeignKey("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id", "dbo.TheHorizontalRoadMarking", "id");
        }
    }
}
