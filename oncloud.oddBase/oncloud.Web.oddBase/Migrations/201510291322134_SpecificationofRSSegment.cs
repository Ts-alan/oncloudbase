namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpecificationofRSSegment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecificationofRS", "SegmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationofRS", "SegmentId");
            AddForeignKey("dbo.SpecificationofRS", "SegmentId", "dbo.Segment", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecificationofRS", "SegmentId", "dbo.Segment");
            DropIndex("dbo.SpecificationofRS", new[] { "SegmentId" });
            DropColumn("dbo.SpecificationofRS", "SegmentId");
        }
    }
}
