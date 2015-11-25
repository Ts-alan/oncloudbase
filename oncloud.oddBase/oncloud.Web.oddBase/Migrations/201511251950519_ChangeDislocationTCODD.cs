namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDislocationTCODD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Segment", "ChangeDislocationTCODD", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Segment", "ChangeDislocationTCODD");
        }
    }
}
