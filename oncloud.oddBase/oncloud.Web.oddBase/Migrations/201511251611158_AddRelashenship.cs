namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelashenship : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.layoutDislocations", new[] { "Segment_id" });
            DropColumn("dbo.layoutDislocations", "Id");
            RenameColumn(table: "dbo.layoutDislocations", name: "Segment_id", newName: "Id");
            DropPrimaryKey("dbo.layoutDislocations");
            AlterColumn("dbo.layoutDislocations", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.layoutDislocations", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.layoutDislocations", "Id");
            CreateIndex("dbo.layoutDislocations", "Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.layoutDislocations", new[] { "Id" });
            DropPrimaryKey("dbo.layoutDislocations");
            AlterColumn("dbo.layoutDislocations", "Id", c => c.Int());
            AlterColumn("dbo.layoutDislocations", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.layoutDislocations", "Id");
            RenameColumn(table: "dbo.layoutDislocations", name: "Id", newName: "Segment_id");
            AddColumn("dbo.layoutDislocations", "Id", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.layoutDislocations", "Segment_id");
        }
    }
}
