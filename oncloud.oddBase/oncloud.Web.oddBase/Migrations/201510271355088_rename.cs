namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename : DbMigration
    {
        public override void Up()
        {

            RenameColumn(table: "dbo.SpecificationofRM", name: "RoadBarriers_id", newName: "TheHorizontalRoadMarking_id");
           
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.SpecificationofRM", name: "RoadBarriers_id", newName: "TheHorizontalRoadMarking_id");
        }
    }
}
