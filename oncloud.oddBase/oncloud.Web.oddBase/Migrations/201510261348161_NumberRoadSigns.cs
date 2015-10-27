namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumberRoadSigns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoadSigns", "NumberRoadSigns", c => c.String(nullable: false));
            DropColumn("dbo.RoadSigns", "NumberSigns");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoadSigns", "NumberSigns", c => c.String(nullable: false));
            DropColumn("dbo.RoadSigns", "NumberRoadSigns");
        }
    }
}
