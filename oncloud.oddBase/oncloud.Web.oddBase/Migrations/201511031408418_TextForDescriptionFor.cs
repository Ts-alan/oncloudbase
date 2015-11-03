namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TextForDescriptionFor : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TextForRS");
            AlterColumn("dbo.TextForRS", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TextForRS", "Id");
            CreateIndex("dbo.TextForRS", "Id");
            AddForeignKey("dbo.TextForRS", "Id", "dbo.DescriptionForRS", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TextForRS", "Id", "dbo.DescriptionForRS");
            DropIndex("dbo.TextForRS", new[] { "Id" });
            DropPrimaryKey("dbo.TextForRS");
            AlterColumn("dbo.TextForRS", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TextForRS", "Id");
        }
    }
}
