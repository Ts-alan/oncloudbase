namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndifikatorMultipleIandT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MultipleIandTForRoadSigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                        Description = c.String(),
                        RoadSignsid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoadSigns", t => t.RoadSignsid, cascadeDelete: true)
                .Index(t => t.RoadSignsid);
            
            AddColumn("dbo.RoadSigns", "IndifikatorMultipleIandT", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MultipleIandTForRoadSigns", "RoadSignsid", "dbo.RoadSigns");
            DropIndex("dbo.MultipleIandTForRoadSigns", new[] { "RoadSignsid" });
            DropColumn("dbo.RoadSigns", "IndifikatorMultipleIandT");
            DropTable("dbo.MultipleIandTForRoadSigns");
        }
    }
}
