namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StreetId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpecificationOfRbs", "Street_id", "dbo.Street");
            DropForeignKey("dbo.SpecificationOfRbs", "RoadBarriers_Id", "dbo.RoadBarriers");
            DropIndex("dbo.SpecificationOfRbs", new[] { "RoadBarriers_Id" });
            DropIndex("dbo.SpecificationOfRbs", new[] { "Street_id" });
            RenameColumn(table: "dbo.SpecificationOfRbs", name: "Street_id", newName: "StreetId");
            RenameColumn(table: "dbo.SpecificationOfRbs", name: "RoadBarriers_Id", newName: "RoadBarriersId");
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriersId", c => c.Int(nullable: false));
            AlterColumn("dbo.SpecificationOfRbs", "StreetId", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationOfRbs", "RoadBarriersId");
            CreateIndex("dbo.SpecificationOfRbs", "StreetId");
            AddForeignKey("dbo.SpecificationOfRbs", "StreetId", "dbo.Street", "id", cascadeDelete: true);
            AddForeignKey("dbo.SpecificationOfRbs", "RoadBarriersId", "dbo.RoadBarriers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecificationOfRbs", "RoadBarriersId", "dbo.RoadBarriers");
            DropForeignKey("dbo.SpecificationOfRbs", "StreetId", "dbo.Street");
            DropIndex("dbo.SpecificationOfRbs", new[] { "StreetId" });
            DropIndex("dbo.SpecificationOfRbs", new[] { "RoadBarriersId" });
            AlterColumn("dbo.SpecificationOfRbs", "StreetId", c => c.Int());
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriersId", c => c.Int());
            RenameColumn(table: "dbo.SpecificationOfRbs", name: "RoadBarriersId", newName: "RoadBarriers_Id");
            RenameColumn(table: "dbo.SpecificationOfRbs", name: "StreetId", newName: "Street_id");
            CreateIndex("dbo.SpecificationOfRbs", "Street_id");
            CreateIndex("dbo.SpecificationOfRbs", "RoadBarriers_Id");
            AddForeignKey("dbo.SpecificationOfRbs", "RoadBarriers_Id", "dbo.RoadBarriers", "Id");
            AddForeignKey("dbo.SpecificationOfRbs", "Street_id", "dbo.Street", "id");
        }
    }
}
