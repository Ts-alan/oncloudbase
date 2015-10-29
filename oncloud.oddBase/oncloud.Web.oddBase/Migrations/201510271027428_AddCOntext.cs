namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCOntext : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SpecificationOfRbs", new[] { "RoadBarriers_Id" });
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_Id", c => c.Int());
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_id", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationOfRbs", "RoadBarriers_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SpecificationOfRbs", new[] { "RoadBarriers_Id" });
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_id", c => c.Int());
            AlterColumn("dbo.SpecificationOfRbs", "RoadBarriers_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecificationOfRbs", "RoadBarriers_Id");
        }
    }
}
