namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onetoone : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SpecificationOfRbs", new[] { "RoadBarriers_id1" });
            DropColumn("dbo.SpecificationOfRbs", "RoadBarriers_id");
            RenameColumn(table: "dbo.SpecificationOfRbs", name: "RoadBarriers_id1", newName: "RoadBarriers_Id");
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
            
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_Id", c => c.Int());
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_id", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationOfRbs", "RoadBarriers_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.layoutSchemes", "Id", "dbo.Street");
            DropForeignKey("dbo.layoutDislocations", "Street_id", "dbo.Street");
            DropIndex("dbo.SpecificationOfRbs", new[] { "RoadBarriers_Id" });
            DropIndex("dbo.layoutSchemes", new[] { "Id" });
            DropIndex("dbo.layoutDislocations", new[] { "Street_id" });
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_id", c => c.Int());
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_Id", c => c.Int(nullable: false));
            DropTable("dbo.layoutSchemes");
            DropTable("dbo.layoutDislocations");
            RenameColumn(table: "dbo.SpecificationOfRbs", name: "RoadBarriers_Id", newName: "RoadBarriers_id1");
            AddColumn("dbo.SpecificationOfRbs", "RoadBarriers_id", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationOfRbs", "RoadBarriers_id1");
        }
    }
}
