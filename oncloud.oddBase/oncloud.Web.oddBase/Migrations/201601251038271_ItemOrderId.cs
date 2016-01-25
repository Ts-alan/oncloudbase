namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemOrderId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoadSigns", "ItemOrderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoadSigns", "ItemOrderId");
        }
    }
}
