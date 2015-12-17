namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class string120Symbol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Segment", "string120Symbol", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Segment", "string120Symbol");
        }
    }
}
