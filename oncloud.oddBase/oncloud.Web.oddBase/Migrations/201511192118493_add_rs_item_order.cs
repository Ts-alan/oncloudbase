namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_rs_item_order : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoadSignItems", "ItemOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoadSignItems", "ItemOrder");
        }
    }
}
