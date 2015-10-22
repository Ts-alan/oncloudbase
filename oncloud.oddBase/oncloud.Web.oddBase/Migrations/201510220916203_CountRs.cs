namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountRs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecificationofRS", "CountRS", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpecificationofRS", "CountRS");
        }
    }
}
