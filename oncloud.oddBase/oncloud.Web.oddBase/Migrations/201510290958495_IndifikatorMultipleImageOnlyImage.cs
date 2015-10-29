namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndifikatorMultipleImageOnlyImage : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MultipleIandTForRoadSigns", newName: "IndifikatorMultipleImages");
            AddColumn("dbo.RoadSigns", "IndifikatorMultipleImage", c => c.Boolean(nullable: false));
            DropColumn("dbo.RoadSigns", "IndifikatorMultipleIandT");
            DropColumn("dbo.IndifikatorMultipleImages", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IndifikatorMultipleImages", "Description", c => c.String());
            AddColumn("dbo.RoadSigns", "IndifikatorMultipleIandT", c => c.Boolean(nullable: false));
            DropColumn("dbo.RoadSigns", "IndifikatorMultipleImage");
            RenameTable(name: "dbo.IndifikatorMultipleImages", newName: "MultipleIandTForRoadSigns");
        }
    }
}
