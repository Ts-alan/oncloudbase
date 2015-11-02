namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
			//CreateTable(
			//	"dbo.City",
			//	c => new
			//		{
			//			id = c.Int(nullable: false, identity: true),
			//			Name = c.String(nullable: false),
			//		})
			//	.PrimaryKey(t => t.id);
            
			//CreateTable(
			//	"dbo.Street",
			//	c => new
			//		{
			//			id = c.Int(nullable: false, identity: true),
			//			Name = c.String(),
			//			BreadthS = c.String(nullable: false),
			//			LengthS = c.String(nullable: false),
			//			BreadthE = c.String(nullable: false),
			//			LengthE = c.String(nullable: false),
			//			City_id = c.Int(nullable: false),
			//			UniqueNumber = c.String(nullable: false),
			//		})
			//	.PrimaryKey(t => t.id)
			//	.ForeignKey("dbo.City", t => t.City_id)
			//	.Index(t => t.City_id);
            
			//CreateTable(
			//	"dbo.layoutDislocations",
			//	c => new
			//		{
			//			Id = c.Int(nullable: false, identity: true),
			//			ImageData = c.Binary(),
			//			ImageMimeType = c.String(),
			//			Street_id = c.Int(),
			//		})
			//	.PrimaryKey(t => t.Id)
			//	.ForeignKey("dbo.Street", t => t.Street_id)
			//	.Index(t => t.Street_id);
            
			//CreateTable(
			//	"dbo.layoutSchemes",
			//	c => new
			//		{
			//			Id = c.Int(nullable: false),
			//			ImageData = c.Binary(),
			//			ImageMimeType = c.String(),
			//		})
			//	.PrimaryKey(t => t.Id)
			//	.ForeignKey("dbo.Street", t => t.Id)
			//	.Index(t => t.Id);
            
			//CreateTable(
			//	"dbo.Segment",
			//	c => new
			//		{
			//			id = c.Int(nullable: false, identity: true),
			//			Name = c.Int(nullable: false),
			//			BreadthS = c.String(nullable: false),
			//			LengthS = c.String(nullable: false),
			//			BreadthE = c.String(nullable: false),
			//			LengthE = c.String(nullable: false),
			//			Street_id = c.Int(nullable: false),
			//		})
			//	.PrimaryKey(t => t.id)
			//	.ForeignKey("dbo.Street", t => t.Street_id)
			//	.Index(t => t.Street_id);
            
			//CreateTable(
			//	"dbo.SpecificationofRS",
			//	c => new
			//		{
			//			id = c.Int(nullable: false, identity: true),
			//			CountRS = c.Int(nullable: false),
			//			Street_id = c.Int(nullable: false),
			//			RoadSigns_id = c.Int(nullable: false),
			//			SegmentId = c.Int(nullable: false),
			//			RoadSigns_id1 = c.Int(),
			//		})
			//	.PrimaryKey(t => t.id)
			//	.ForeignKey("dbo.RoadSigns", t => t.RoadSigns_id1)
			//	.ForeignKey("dbo.Segment", t => t.SegmentId, cascadeDelete: true)
			//	.ForeignKey("dbo.Street", t => t.Street_id)
			//	.Index(t => t.Street_id)
			//	.Index(t => t.SegmentId)
			//	.Index(t => t.RoadSigns_id1);
            
			//CreateTable(
			//	"dbo.RoadSigns",
			//	c => new
			//		{
			//			id = c.Int(nullable: false, identity: true),
			//			NumberRoadSigns = c.String(nullable: false),
			//			Description = c.String(nullable: false, maxLength: 4000),
			//			IndifikatorMultipleImage = c.Boolean(nullable: false),
			//			ImageData = c.Binary(),
			//			ImageMimeType = c.String(),
			//		})
			//	.PrimaryKey(t => t.id);
            
			//CreateTable(
			//	"dbo.MultipleImageForRS",
			//	c => new
			//		{
			//			Id = c.Int(nullable: false, identity: true),
			//			ImageData = c.Binary(),
			//			ImageMimeType = c.String(),
			//			RoadSignsid = c.Int(nullable: false),
			//		})
			//	.PrimaryKey(t => t.Id)
			//	.ForeignKey("dbo.RoadSigns", t => t.RoadSignsid, cascadeDelete: true)
			//	.Index(t => t.RoadSignsid);
            
			//CreateTable(
			//	"dbo.SpecificationOfRbs",
			//	c => new
			//		{
			//			Id = c.Int(nullable: false, identity: true),
			//			Length = c.String(),
			//			RoadBarriers_id = c.Int(nullable: false),
			//			RoadBarriers_Id = c.Int(),
			//			Street_id = c.Int(),
			//		})
			//	.PrimaryKey(t => t.Id)
			//	.ForeignKey("dbo.RoadBarriers", t => t.RoadBarriers_Id)
			//	.ForeignKey("dbo.Street", t => t.Street_id)
			//	.Index(t => t.RoadBarriers_Id)
			//	.Index(t => t.Street_id);
            
			//CreateTable(
			//	"dbo.RoadBarriers",
			//	c => new
			//		{
			//			Id = c.Int(nullable: false, identity: true),
			//			NumberBarriers = c.String(nullable: false),
			//			Description = c.String(nullable: false, maxLength: 4000),
			//			ImageData = c.Binary(),
			//			ImageMimeType = c.String(),
			//		})
			//	.PrimaryKey(t => t.Id);
            
			//CreateTable(
			//	"dbo.SpecificationofRM",
			//	c => new
			//		{
			//			id = c.Int(nullable: false, identity: true),
			//			length = c.String(),
			//			area = c.String(),
			//			Street_id = c.Int(nullable: false),
			//			TheHorizontalRoadMarking_id = c.Int(nullable: false),
			//			TheHorizontalRoadMarking_id1 = c.Int(nullable: false),
			//		})
			//	.PrimaryKey(t => t.id)
			//	.ForeignKey("dbo.TheHorizontalRoadMarking", t => t.TheHorizontalRoadMarking_id1, cascadeDelete: true)
			//	.ForeignKey("dbo.Street", t => t.Street_id)
			//	.Index(t => t.Street_id)
			//	.Index(t => t.TheHorizontalRoadMarking_id1);
            
			//CreateTable(
			//	"dbo.TheHorizontalRoadMarking",
			//	c => new
			//		{
			//			id = c.Int(nullable: false, identity: true),
			//			NumberMarking = c.String(nullable: false),
			//			description = c.String(nullable: false, storeType: "ntext"),
			//			ImageData = c.Binary(),
			//			ImageMimeType = c.String(),
			//		})
			//	.PrimaryKey(t => t.id);
            
			//CreateTable(
			//	"dbo.Increment",
			//	c => new
			//		{
			//			id = c.Int(nullable: false),
			//			Counter = c.Int(nullable: false),
			//		})
			//	.PrimaryKey(t => t.id);
            
			//CreateTable(
			//	"dbo.IntelliSenseStreet",
			//	c => new
			//		{
			//			id = c.Int(nullable: false),
			//			Street = c.String(nullable: false, maxLength: 50),
			//			Type = c.String(maxLength: 50),
			//		})
			//	.PrimaryKey(t => new { t.id, t.Street });
            
        }
        
        public override void Down()
        {
			//DropForeignKey("dbo.Street", "City_id", "dbo.City");
			//DropForeignKey("dbo.SpecificationofRS", "Street_id", "dbo.Street");
			//DropForeignKey("dbo.SpecificationofRM", "Street_id", "dbo.Street");
			//DropForeignKey("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1", "dbo.TheHorizontalRoadMarking");
			//DropForeignKey("dbo.SpecificationOfRbs", "Street_id", "dbo.Street");
			//DropForeignKey("dbo.SpecificationOfRbs", "RoadBarriers_Id", "dbo.RoadBarriers");
			//DropForeignKey("dbo.Segment", "Street_id", "dbo.Street");
			//DropForeignKey("dbo.SpecificationofRS", "SegmentId", "dbo.Segment");
			//DropForeignKey("dbo.SpecificationofRS", "RoadSigns_id1", "dbo.RoadSigns");
			//DropForeignKey("dbo.MultipleImageForRS", "RoadSignsid", "dbo.RoadSigns");
			//DropForeignKey("dbo.layoutSchemes", "Id", "dbo.Street");
			//DropForeignKey("dbo.layoutDislocations", "Street_id", "dbo.Street");
			//DropIndex("dbo.SpecificationofRM", new[] { "TheHorizontalRoadMarking_id1" });
			//DropIndex("dbo.SpecificationofRM", new[] { "Street_id" });
			//DropIndex("dbo.SpecificationOfRbs", new[] { "Street_id" });
			//DropIndex("dbo.SpecificationOfRbs", new[] { "RoadBarriers_Id" });
			//DropIndex("dbo.MultipleImageForRS", new[] { "RoadSignsid" });
			//DropIndex("dbo.SpecificationofRS", new[] { "RoadSigns_id1" });
			//DropIndex("dbo.SpecificationofRS", new[] { "SegmentId" });
			//DropIndex("dbo.SpecificationofRS", new[] { "Street_id" });
			//DropIndex("dbo.Segment", new[] { "Street_id" });
			//DropIndex("dbo.layoutSchemes", new[] { "Id" });
			//DropIndex("dbo.layoutDislocations", new[] { "Street_id" });
			//DropIndex("dbo.Street", new[] { "City_id" });
			//DropTable("dbo.IntelliSenseStreet");
			//DropTable("dbo.Increment");
			//DropTable("dbo.TheHorizontalRoadMarking");
			//DropTable("dbo.SpecificationofRM");
			//DropTable("dbo.RoadBarriers");
			//DropTable("dbo.SpecificationOfRbs");
			//DropTable("dbo.MultipleImageForRS");
			//DropTable("dbo.RoadSigns");
			//DropTable("dbo.SpecificationofRS");
			//DropTable("dbo.Segment");
			//DropTable("dbo.layoutSchemes");
			//DropTable("dbo.layoutDislocations");
			//DropTable("dbo.Street");
			//DropTable("dbo.City");
        }
    }
}
