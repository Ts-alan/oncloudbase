namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamecolums : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoadSigns", "NumberSigns", c => c.String(nullable: false));
            DropColumn("dbo.RoadSigns", "NumberMarking");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoadSigns", "NumberMarking", c => c.String(nullable: false));
            DropColumn("dbo.RoadSigns", "NumberSigns");
        }
    }
}
