namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteRelashenship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.layoutDislocations", "SegmentId", "dbo.Segment");
            DropIndex("dbo.layoutDislocations", new[] { "SegmentId" });
            DropColumn("dbo.layoutDislocations", "SegmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.layoutDislocations", "SegmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.layoutDislocations", "SegmentId");
            AddForeignKey("dbo.layoutDislocations", "SegmentId", "dbo.Segment", "id", cascadeDelete: true);
        }
    }
}
