namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1", "dbo.TheHorizontalRoadMarking");
            DropForeignKey("dbo.SpecificationofRM", "Street_id", "dbo.Street");
            DropIndex("dbo.SpecificationofRM", new[] { "Street_id" });
            DropIndex("dbo.SpecificationofRM", new[] { "TheHorizontalRoadMarking_id1" });
            DropTable("dbo.SpecificationofRM");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1");
            CreateIndex("dbo.SpecificationofRM", "Street_id");
            AddForeignKey("dbo.SpecificationofRM", "Street_id", "dbo.Street", "id");
            AddForeignKey("dbo.SpecificationofRM", "TheHorizontalRoadMarking_id1", "dbo.TheHorizontalRoadMarking", "id", cascadeDelete: true);
        }
    }
}
