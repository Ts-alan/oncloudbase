namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoadBarriers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoadBarriers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NumberBarriers = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 4000),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RoadBarriers");
        }
    }
}
