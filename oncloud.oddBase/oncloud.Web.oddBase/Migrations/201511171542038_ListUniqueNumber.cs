namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListUniqueNumber : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListUniqueNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueNumber = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ListUniqueNumbers");
        }
    }
}
