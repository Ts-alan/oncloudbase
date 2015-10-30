namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletecolums : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SpecificationOfRbs", "NumberOfMeters");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SpecificationOfRbs", "NumberOfMeters", c => c.Double(nullable: false));
        }
    }
}
