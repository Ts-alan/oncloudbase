namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoadSignsIdModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpecificationOfRbs", "Street_id", "dbo.Street");
            DropForeignKey("dbo.SpecificationOfRbs", "RoadBarriers_Id", "dbo.RoadBarriers");
            DropIndex("dbo.SpecificationOfRbs", new[] { "RoadBarriers_Id" });
            DropIndex("dbo.SpecificationOfRbs", new[] { "Street_id" });
            RenameColumn(table: "dbo.Segment", name: "Street_id", newName: "StreetId");
            RenameColumn(table: "dbo.SpecificationOfRbs", name: "Street_id", newName: "StreetId");
            RenameColumn(table: "dbo.SpecificationOfRbs", name: "RoadBarriers_Id", newName: "RoadBarriersId");
            RenameIndex(table: "dbo.Segment", name: "IX_Street_id", newName: "IX_StreetId");
            AddColumn("dbo.layoutDislocations", "SegmentId", c => c.Int(nullable: false));
            AddColumn("dbo.SpecificationOfRbs", "SegmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.SpecificationOfRbs", "Length", c => c.Int(nullable: false));
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriersId", c => c.Int(nullable: false));
            AlterColumn("dbo.SpecificationOfRbs", "StreetId", c => c.Int(nullable: false));
            CreateIndex("dbo.layoutDislocations", "SegmentId");
            CreateIndex("dbo.SpecificationOfRbs", "SegmentId");
            CreateIndex("dbo.SpecificationOfRbs", "RoadBarriersId");
            CreateIndex("dbo.SpecificationOfRbs", "StreetId");
            AddForeignKey("dbo.layoutDislocations", "SegmentId", "dbo.Segment", "id", cascadeDelete: true);
            AddForeignKey("dbo.SpecificationOfRbs", "SegmentId", "dbo.Segment", "id", cascadeDelete: true);
            AddForeignKey("dbo.SpecificationOfRbs", "StreetId", "dbo.Street", "id", cascadeDelete: true);
            AddForeignKey("dbo.SpecificationOfRbs", "RoadBarriersId", "dbo.RoadBarriers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecificationOfRbs", "RoadBarriersId", "dbo.RoadBarriers");
            DropForeignKey("dbo.SpecificationOfRbs", "StreetId", "dbo.Street");
            DropForeignKey("dbo.SpecificationOfRbs", "SegmentId", "dbo.Segment");
            DropForeignKey("dbo.layoutDislocations", "SegmentId", "dbo.Segment");
            DropIndex("dbo.SpecificationOfRbs", new[] { "StreetId" });
            DropIndex("dbo.SpecificationOfRbs", new[] { "RoadBarriersId" });
            DropIndex("dbo.SpecificationOfRbs", new[] { "SegmentId" });
            DropIndex("dbo.layoutDislocations", new[] { "SegmentId" });
            AlterColumn("dbo.SpecificationOfRbs", "StreetId", c => c.Int());
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriersId", c => c.Int());
            AlterColumn("dbo.SpecificationOfRbs", "Length", c => c.String());
            DropColumn("dbo.SpecificationOfRbs", "SegmentId");
            DropColumn("dbo.layoutDislocations", "SegmentId");
            RenameIndex(table: "dbo.Segment", name: "IX_StreetId", newName: "IX_Street_id");
            RenameColumn(table: "dbo.SpecificationOfRbs", name: "RoadBarriersId", newName: "RoadBarriers_Id");
            RenameColumn(table: "dbo.SpecificationOfRbs", name: "StreetId", newName: "Street_id");
            RenameColumn(table: "dbo.Segment", name: "StreetId", newName: "Street_id");
            CreateIndex("dbo.SpecificationOfRbs", "Street_id");
            CreateIndex("dbo.SpecificationOfRbs", "RoadBarriers_Id");
            AddForeignKey("dbo.SpecificationOfRbs", "RoadBarriers_Id", "dbo.RoadBarriers", "Id");
            AddForeignKey("dbo.SpecificationOfRbs", "Street_id", "dbo.Street", "id");
        }
    }
}
