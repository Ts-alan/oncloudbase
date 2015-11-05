namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class multiple_rs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoadSignItems",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Hallmark = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                    })
                .PrimaryKey(t => new { t.Id, t.Hallmark })
                .ForeignKey("dbo.RoadSigns", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            DropColumn("dbo.RoadSigns", "Description");
            DropColumn("dbo.RoadSigns", "ImageData");
            DropColumn("dbo.RoadSigns", "ImageMimeType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoadSigns", "ImageMimeType", c => c.String());
            AddColumn("dbo.RoadSigns", "ImageData", c => c.Binary());
            AddColumn("dbo.RoadSigns", "Description", c => c.String(nullable: false, maxLength: 4000));
            DropForeignKey("dbo.RoadSignItems", "Id", "dbo.RoadSigns");
            DropIndex("dbo.RoadSignItems", new[] { "Id" });
            DropTable("dbo.RoadSignItems");
        }
    }
}
