namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id", "dbo.TheHorizontalRoadMarking");
            DropIndex("dbo.SpecificationofRM", new[] { "TheHorizontalRoadMarking_id" });
            AddColumn("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1", c => c.Int());
            AlterColumn("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1");
            AddForeignKey("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1", "dbo.TheHorizontalRoadMarking", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1", "dbo.TheHorizontalRoadMarking");
            DropIndex("dbo.SpecificationofRM", new[] { "TheHorizontalRoadMarking_id1" });
            AlterColumn("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id", c => c.Int());
            DropColumn("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1");
            CreateIndex("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id");
            AddForeignKey("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id", "dbo.TheHorizontalRoadMarking", "id");
        }
    }
}
