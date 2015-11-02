namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SegmentlayoutDislocation : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Segment", name: "Street_id", newName: "StreetId");
            RenameIndex(table: "dbo.Segment", name: "IX_Street_id", newName: "IX_StreetId");
            AddColumn("dbo.layoutDislocations", "SegmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.layoutDislocations", "SegmentId");
            AddForeignKey("dbo.layoutDislocations", "SegmentId", "dbo.Segment", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.layoutDislocations", "SegmentId", "dbo.Segment");
            DropIndex("dbo.layoutDislocations", new[] { "SegmentId" });
            DropColumn("dbo.layoutDislocations", "SegmentId");
            RenameIndex(table: "dbo.Segment", name: "IX_StreetId", newName: "IX_Street_id");
            RenameColumn(table: "dbo.Segment", name: "StreetId", newName: "Street_id");
        }
    }
}
