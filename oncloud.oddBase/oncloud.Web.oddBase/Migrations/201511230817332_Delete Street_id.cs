namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteStreet_id : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SpecificationofRM", new[] { "Street_id" });
            AlterColumn("dbo.SpecificationofRM", "Street_id", c => c.Int());
            CreateIndex("dbo.SpecificationofRM", "Street_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SpecificationofRM", new[] { "Street_id" });
            AlterColumn("dbo.SpecificationofRM", "Street_id", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationofRM", "Street_id");
        }
    }
}
