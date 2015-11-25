namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrelashenship : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.layoutDislocations");
            AlterColumn("dbo.layoutDislocations", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.layoutDislocations", "Id");
            CreateIndex("dbo.layoutDislocations", "Id");
            AddForeignKey("dbo.layoutDislocations", "Id", "dbo.Segment", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.layoutDislocations", "Id", "dbo.Segment");
            DropIndex("dbo.layoutDislocations", new[] { "Id" });
            DropPrimaryKey("dbo.layoutDislocations");
            AlterColumn("dbo.layoutDislocations", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.layoutDislocations", "Id");
        }
    }
}
