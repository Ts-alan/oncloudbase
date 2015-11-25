namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteRelashenship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.layoutDislocations", "SegmentId", "dbo.Segment");
            DropIndex("dbo.layoutDislocations", new[] { "SegmentId" });
            RenameColumn(table: "dbo.layoutDislocations", name: "SegmentId", newName: "Segment_id");
            AddColumn("dbo.Segment", "ChangeDislocationTCODD", c => c.Boolean(nullable: false));
            AlterColumn("dbo.layoutDislocations", "Segment_id", c => c.Int());
            CreateIndex("dbo.layoutDislocations", "Segment_id");
            AddForeignKey("dbo.layoutDislocations", "Segment_id", "dbo.Segment", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.layoutDislocations", "Segment_id", "dbo.Segment");
            DropIndex("dbo.layoutDislocations", new[] { "Segment_id" });
            AlterColumn("dbo.layoutDislocations", "Segment_id", c => c.Int(nullable: false));
            DropColumn("dbo.Segment", "ChangeDislocationTCODD");
            RenameColumn(table: "dbo.layoutDislocations", name: "Segment_id", newName: "SegmentId");
            CreateIndex("dbo.layoutDislocations", "SegmentId");
            AddForeignKey("dbo.layoutDislocations", "SegmentId", "dbo.Segment", "id", cascadeDelete: true);
        }
    }
}
