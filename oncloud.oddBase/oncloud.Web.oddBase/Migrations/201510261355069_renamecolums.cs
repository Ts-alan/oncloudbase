namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamecolums : DbMigration
    {
        public override void Up()
        {
            RenameColumn("RoadSigns", "NumberMarking", "NumberRoadSigns");
        }
        
        public override void Down()
        {
            RenameColumn("RoadSigns", "NumberMarking", "NumberRoadSigns");
        }
    }
}
