namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultipleImageForRS : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.IndifikatorMultipleImages", newName: "MultipleImageForRS");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.MultipleImageForRS", newName: "IndifikatorMultipleImages");
        }
    }
}
