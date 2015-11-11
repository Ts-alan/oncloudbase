namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotrequeredTheHorizontalRoadMaking : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1", "dbo.TheHorizontalRoadMarking");
            DropIndex("dbo.SpecificationofRM", new[] { "TheHorizontalRoadMarking_id1" });
            AlterColumn("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1", c => c.Int());
            CreateIndex("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1");
            AddForeignKey("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1", "dbo.TheHorizontalRoadMarking", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1", "dbo.TheHorizontalRoadMarking");
            DropIndex("dbo.SpecificationofRM", new[] { "TheHorizontalRoadMarking_id1" });
            AlterColumn("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1");
            AddForeignKey("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1", "dbo.TheHorizontalRoadMarking", "id", cascadeDelete: true);
        }
    }
}
