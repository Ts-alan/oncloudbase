namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpecificationofRSItemOrderId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecificationofRS", "ItemOrderId", c => c.Int());
            DropColumn("dbo.RoadSigns", "ItemOrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoadSigns", "ItemOrderId", c => c.Int());
            DropColumn("dbo.SpecificationofRS", "ItemOrderId");
        }
    }
}
