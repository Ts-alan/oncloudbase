namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.layoutDislocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                        Street_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Street", t => t.Street_id)
                .Index(t => t.Street_id);
            
            CreateTable(
                "dbo.layoutSchemes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Street", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.layoutSchemes", "Id", "dbo.Street");
            DropForeignKey("dbo.layoutDislocations", "Street_id", "dbo.Street");
            DropIndex("dbo.layoutSchemes", new[] { "Id" });
            DropIndex("dbo.layoutDislocations", new[] { "Street_id" });
            DropTable("dbo.layoutSchemes");
            DropTable("dbo.layoutDislocations");
        }
    }
}
