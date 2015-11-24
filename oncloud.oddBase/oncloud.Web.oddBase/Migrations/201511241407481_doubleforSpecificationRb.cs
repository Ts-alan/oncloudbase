namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doubleforSpecificationRb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SpecificationOfRbs", "Length", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SpecificationOfRbs", "Length", c => c.Int(nullable: false));
        }
    }
}
