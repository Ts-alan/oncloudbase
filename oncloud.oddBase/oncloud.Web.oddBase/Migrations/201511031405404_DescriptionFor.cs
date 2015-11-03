namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescriptionFor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageForRS", "RoadSigns_id", "dbo.RoadSigns");
            CreateTable(
                "dbo.DescriptionForRS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 4000),
                        DescriptionRS_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoadSigns", t => t.DescriptionRS_id)
                .Index(t => t.DescriptionRS_id);
            
            CreateTable(
                "dbo.TextForRS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoadSigns_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoadSigns", t => t.RoadSigns_id)
                .Index(t => t.RoadSigns_id);
            
            AddColumn("dbo.ImageForRS", "RoadSigns_id1", c => c.Int());
            AddColumn("dbo.ImageForRS", "RoadSigns_id2", c => c.Int());
            CreateIndex("dbo.ImageForRS", "RoadSigns_id1");
            CreateIndex("dbo.ImageForRS", "RoadSigns_id2");
            AddForeignKey("dbo.ImageForRS", "RoadSigns_id2", "dbo.RoadSigns", "id");
            AddForeignKey("dbo.ImageForRS", "RoadSigns_id1", "dbo.RoadSigns", "id");
            DropColumn("dbo.RoadSigns", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoadSigns", "Description", c => c.String(nullable: false, maxLength: 4000));
            DropForeignKey("dbo.ImageForRS", "RoadSigns_id1", "dbo.RoadSigns");
            DropForeignKey("dbo.TextForRS", "RoadSigns_id", "dbo.RoadSigns");
            DropForeignKey("dbo.ImageForRS", "RoadSigns_id2", "dbo.RoadSigns");
            DropForeignKey("dbo.DescriptionForRS", "DescriptionRS_id", "dbo.RoadSigns");
            DropIndex("dbo.TextForRS", new[] { "RoadSigns_id" });
            DropIndex("dbo.ImageForRS", new[] { "RoadSigns_id2" });
            DropIndex("dbo.ImageForRS", new[] { "RoadSigns_id1" });
            DropIndex("dbo.DescriptionForRS", new[] { "DescriptionRS_id" });
            DropColumn("dbo.ImageForRS", "RoadSigns_id2");
            DropColumn("dbo.ImageForRS", "RoadSigns_id1");
            DropTable("dbo.TextForRS");
            DropTable("dbo.DescriptionForRS");
            AddForeignKey("dbo.ImageForRS", "RoadSigns_id", "dbo.RoadSigns", "id");
        }
    }
}
