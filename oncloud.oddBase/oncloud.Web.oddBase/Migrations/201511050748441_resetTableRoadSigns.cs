namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resetTableRoadSigns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DescriptionForRS", "DescriptionRS_id", "dbo.RoadSigns");
            DropForeignKey("dbo.ImageForRS", "RoadSigns_id", "dbo.RoadSigns");
            DropForeignKey("dbo.DescriptionForRS", "Id", "dbo.ImageForRS");
            DropForeignKey("dbo.TextForRS", "Id", "dbo.DescriptionForRS");
            DropForeignKey("dbo.TextForRS", "RoadSignsId", "dbo.RoadSigns");
            DropForeignKey("dbo.ImageForRS", "RoadSigns_id1", "dbo.RoadSigns");
            DropForeignKey("dbo.ImageForRS", "RoadSigns_id2", "dbo.RoadSigns");
            DropIndex("dbo.DescriptionForRS", new[] { "Id" });
            DropIndex("dbo.DescriptionForRS", new[] { "DescriptionRS_id" });
            DropIndex("dbo.ImageForRS", new[] { "RoadSigns_id" });
            DropIndex("dbo.ImageForRS", new[] { "RoadSigns_id1" });
            DropIndex("dbo.ImageForRS", new[] { "RoadSigns_id2" });
            DropIndex("dbo.TextForRS", new[] { "Id" });
            DropIndex("dbo.TextForRS", new[] { "RoadSignsId" });
            AddColumn("dbo.RoadSigns", "Description", c => c.String(nullable: false, maxLength: 4000));
            AddColumn("dbo.RoadSigns", "ImageData", c => c.Binary());
            AddColumn("dbo.RoadSigns", "ImageMimeType", c => c.String());
            DropTable("dbo.DescriptionForRS");
            DropTable("dbo.ImageForRS");
            DropTable("dbo.TextForRS");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TextForRS",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        RoadSignsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImageForRS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                        RoadSignId = c.Int(nullable: false),
                        RoadSigns_id = c.Int(),
                        RoadSigns_id1 = c.Int(),
                        RoadSigns_id2 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DescriptionForRS",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 4000),
                        RoadSignId = c.Int(nullable: false),
                        DescriptionRS_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.RoadSigns", "ImageMimeType");
            DropColumn("dbo.RoadSigns", "ImageData");
            DropColumn("dbo.RoadSigns", "Description");
            CreateIndex("dbo.TextForRS", "RoadSignsId");
            CreateIndex("dbo.TextForRS", "Id");
            CreateIndex("dbo.ImageForRS", "RoadSigns_id2");
            CreateIndex("dbo.ImageForRS", "RoadSigns_id1");
            CreateIndex("dbo.ImageForRS", "RoadSigns_id");
            CreateIndex("dbo.DescriptionForRS", "DescriptionRS_id");
            CreateIndex("dbo.DescriptionForRS", "Id");
            AddForeignKey("dbo.ImageForRS", "RoadSigns_id2", "dbo.RoadSigns", "id");
            AddForeignKey("dbo.ImageForRS", "RoadSigns_id1", "dbo.RoadSigns", "id");
            AddForeignKey("dbo.TextForRS", "RoadSignsId", "dbo.RoadSigns", "id", cascadeDelete: true);
            AddForeignKey("dbo.TextForRS", "Id", "dbo.DescriptionForRS", "Id");
            AddForeignKey("dbo.DescriptionForRS", "Id", "dbo.ImageForRS", "Id");
            AddForeignKey("dbo.ImageForRS", "RoadSigns_id", "dbo.RoadSigns", "id");
            AddForeignKey("dbo.DescriptionForRS", "DescriptionRS_id", "dbo.RoadSigns", "id");
        }
    }
}
