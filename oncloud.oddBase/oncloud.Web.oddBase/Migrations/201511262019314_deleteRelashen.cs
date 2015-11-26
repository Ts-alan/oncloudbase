namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteRelashen : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.layoutDislocations", "Id", "dbo.Segment");
            DropIndex("dbo.layoutDislocations", new[] { "Id" });
            DropPrimaryKey("dbo.layoutDislocations");
            AlterColumn("dbo.layoutDislocations", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.layoutDislocations", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.layoutDislocations");
            AlterColumn("dbo.layoutDislocations", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.layoutDislocations", "Id");
            CreateIndex("dbo.layoutDislocations", "Id");
            AddForeignKey("dbo.layoutDislocations", "Id", "dbo.Segment", "id");
        }
    }
}
