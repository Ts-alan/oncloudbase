namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SpecificationofRM", new[] { "TheHorizontalRoadMarking_id1" });
            DropColumn("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id");
            RenameColumn(table: "dbo.SpecificationofRM", name: "TheHorizontalRoadMarking_id1", newName: "TheHorizontalRoadMarking_id");
            AlterColumn("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id", c => c.Int());
            CreateIndex("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SpecificationofRM", new[] { "TheHorizontalRoadMarking_id" });
            AlterColumn("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.SpecificationofRM", name: "TheHorizontalRoadMarking_id", newName: "TheHorizontalRoadMarking_id1");
            AddColumn("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1");
        }
    }
}
