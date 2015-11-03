namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StreetId1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.layoutDislocations", "Street_id", "dbo.Street");
            DropIndex("dbo.layoutDislocations", new[] { "Street_id" });
            RenameColumn(table: "dbo.layoutDislocations", name: "Street_id", newName: "StreetId");
            AlterColumn("dbo.layoutDislocations", "StreetId", c => c.Int(nullable: false));
            CreateIndex("dbo.layoutDislocations", "StreetId");
            AddForeignKey("dbo.layoutDislocations", "StreetId", "dbo.Street", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.layoutDislocations", "StreetId", "dbo.Street");
            DropIndex("dbo.layoutDislocations", new[] { "StreetId" });
            AlterColumn("dbo.layoutDislocations", "StreetId", c => c.Int());
            RenameColumn(table: "dbo.layoutDislocations", name: "StreetId", newName: "Street_id");
            CreateIndex("dbo.layoutDislocations", "Street_id");
            AddForeignKey("dbo.layoutDislocations", "Street_id", "dbo.Street", "id");
        }
    }
}
