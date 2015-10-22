namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpecificationofRM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecificationofRS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Street_id = c.Int(nullable: false),
                        Street_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Street", t => t.Street_id1)
                .Index(t => t.Street_id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecificationofRS", "Street_id1", "dbo.Street");
            DropIndex("dbo.SpecificationofRS", new[] { "Street_id1" });
            DropTable("dbo.SpecificationofRS");
        }
    }
}
