namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relashenshipImage : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MultipleImageForRS", newName: "ImageForRS");
            DropForeignKey("dbo.MultipleImageForRS", "RoadSignsid", "dbo.RoadSigns");
            DropIndex("dbo.ImageForRS", new[] { "RoadSignsid" });
            RenameColumn(table: "dbo.ImageForRS", name: "RoadSignsid", newName: "RoadSigns_id");
            AddColumn("dbo.ImageForRS", "RoadSignId", c => c.Int(nullable: false));
            AlterColumn("dbo.ImageForRS", "RoadSigns_id", c => c.Int());
            CreateIndex("dbo.ImageForRS", "RoadSigns_id");
            AddForeignKey("dbo.ImageForRS", "RoadSigns_id", "dbo.RoadSigns", "id");
            DropColumn("dbo.RoadSigns", "IndifikatorMultipleImage");
            DropColumn("dbo.RoadSigns", "ImageData");
            DropColumn("dbo.RoadSigns", "ImageMimeType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoadSigns", "ImageMimeType", c => c.String());
            AddColumn("dbo.RoadSigns", "ImageData", c => c.Binary());
            AddColumn("dbo.RoadSigns", "IndifikatorMultipleImage", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.ImageForRS", "RoadSigns_id", "dbo.RoadSigns");
            DropIndex("dbo.ImageForRS", new[] { "RoadSigns_id" });
            AlterColumn("dbo.ImageForRS", "RoadSigns_id", c => c.Int(nullable: false));
            DropColumn("dbo.ImageForRS", "RoadSignId");
            RenameColumn(table: "dbo.ImageForRS", name: "RoadSigns_id", newName: "RoadSignsid");
            CreateIndex("dbo.ImageForRS", "RoadSignsid");
            AddForeignKey("dbo.MultipleImageForRS", "RoadSignsid", "dbo.RoadSigns", "id", cascadeDelete: true);
            RenameTable(name: "dbo.ImageForRS", newName: "MultipleImageForRS");
        }
    }
}
