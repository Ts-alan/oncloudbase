namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoadMarking : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TheHorizontalRoadMarking", newName: "RoadMarking");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.RoadMarking", newName: "TheHorizontalRoadMarking");
        }
    }
}
