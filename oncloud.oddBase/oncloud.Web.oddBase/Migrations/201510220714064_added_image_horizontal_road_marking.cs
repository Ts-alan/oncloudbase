namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_image_horizontal_road_marking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TheHorizontalRoadMarking", "ImageData", c => c.Binary());
            AddColumn("dbo.TheHorizontalRoadMarking", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TheHorizontalRoadMarking", "ImageMimeType");
            DropColumn("dbo.TheHorizontalRoadMarking", "ImageData");
        }
    }
}
