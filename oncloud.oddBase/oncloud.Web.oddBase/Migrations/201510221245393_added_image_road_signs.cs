namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_image_road_signs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoadSigns", "ImageData", c => c.Binary());
            AddColumn("dbo.RoadSigns", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoadSigns", "ImageMimeType");
            DropColumn("dbo.RoadSigns", "ImageData");
        }
    }
}
