namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColums : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecificationofRM",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        length = c.String(),
                        area = c.String(),
                        Street_id = c.Int(nullable: false),
                        TheHorizontalRoadMarking_id = c.Int(nullable: false),
                        TheHorizontalRoadMarking_id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TheHorizontalRoadMarking", t => t.TheHorizontalRoadMarking_id1, cascadeDelete: true)
                .ForeignKey("dbo.Street", t => t.Street_id)
                .Index(t => t.Street_id)
                .Index(t => t.TheHorizontalRoadMarking_id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecificationofRM", "Street_id", "dbo.Street");
            DropForeignKey("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1", "dbo.TheHorizontalRoadMarking");
            DropIndex("dbo.SpecificationofRM", new[] { "TheHorizontalRoadMarking_id1" });
            DropIndex("dbo.SpecificationofRM", new[] { "Street_id" });
            DropTable("dbo.SpecificationofRM");
        }
    }
}
