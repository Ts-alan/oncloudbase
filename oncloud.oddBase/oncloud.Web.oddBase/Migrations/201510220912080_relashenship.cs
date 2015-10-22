namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relashenship : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SpecificationofRS", new[] { "Street_id1" });
            DropColumn("dbo.SpecificationofRS", "Street_id");
            RenameColumn(table: "dbo.SpecificationofRS", name: "Street_id1", newName: "Street_id");
            AlterColumn("dbo.SpecificationofRS", "Street_id", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationofRS", "Street_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SpecificationofRS", new[] { "Street_id" });
            AlterColumn("dbo.SpecificationofRS", "Street_id", c => c.Int());
            RenameColumn(table: "dbo.SpecificationofRS", name: "Street_id", newName: "Street_id1");
            AddColumn("dbo.SpecificationofRS", "Street_id", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationofRS", "Street_id1");
        }
    }
}
