namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullItemOrderId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoadSigns", "ItemOrderId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoadSigns", "ItemOrderId", c => c.Int(nullable: false));
        }
    }
}
