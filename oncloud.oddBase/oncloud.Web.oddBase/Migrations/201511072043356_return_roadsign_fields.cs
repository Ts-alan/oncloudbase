namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class return_roadsign_fields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoadSigns", "Description", c => c.String(nullable: false));
            AddColumn("dbo.RoadSigns", "ImageData", c => c.Binary());
            AddColumn("dbo.RoadSigns", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoadSigns", "ImageMimeType");
            DropColumn("dbo.RoadSigns", "ImageData");
            DropColumn("dbo.RoadSigns", "Description");
        }
    }
}
