namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpecificationOfRb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecificationOfRbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Length = c.String(),
                        NumberOfMeters = c.Double(nullable: false),
                        Street_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Street", t => t.Street_id)
                .Index(t => t.Street_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecificationOfRbs", "Street_id", "dbo.Street");
            DropIndex("dbo.SpecificationOfRbs", new[] { "Street_id" });
            DropTable("dbo.SpecificationOfRbs");
        }
    }
}
