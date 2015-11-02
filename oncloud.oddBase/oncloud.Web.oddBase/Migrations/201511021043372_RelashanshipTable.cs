namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelashanshipTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SpecificationOfRbs", new[] { "RoadBarriers_Id" });
            AddColumn("dbo.SpecificationOfRbs", "SegmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_Id", c => c.Int());
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_id", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationOfRbs", "SegmentId");
            CreateIndex("dbo.SpecificationOfRbs", "RoadBarriers_Id");
            AddForeignKey("dbo.SpecificationOfRbs", "SegmentId", "dbo.Segment", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecificationOfRbs", "SegmentId", "dbo.Segment");
            DropIndex("dbo.SpecificationOfRbs", new[] { "RoadBarriers_Id" });
            DropIndex("dbo.SpecificationOfRbs", new[] { "SegmentId" });
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_id", c => c.Int());
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_Id", c => c.Int(nullable: false));
            DropColumn("dbo.SpecificationOfRbs", "SegmentId");
            CreateIndex("dbo.SpecificationOfRbs", "RoadBarriers_Id");
        }
    }
}
