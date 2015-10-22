namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoadSigns : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoadSigns",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NumberMarking = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RoadSigns");
        }
    }
}
