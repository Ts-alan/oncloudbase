namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStreetId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SpecificationofRM", new[] { "Street_id" });
            RenameColumn(table: "dbo.SpecificationofRM", name: "Street_id", newName: "StreetId");
            AlterColumn("dbo.SpecificationofRM", "StreetId", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationofRM", "StreetId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SpecificationofRM", new[] { "StreetId" });
            AlterColumn("dbo.SpecificationofRM", "StreetId", c => c.Int());
            RenameColumn(table: "dbo.SpecificationofRM", name: "StreetId", newName: "Street_id");
            CreateIndex("dbo.SpecificationofRM", "Street_id");
        }
    }
}
