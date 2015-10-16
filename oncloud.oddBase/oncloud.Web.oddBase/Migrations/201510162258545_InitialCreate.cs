namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Streets",
                c => new
                    {
                        StreetId = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                        StartPointLongitude = c.Double(),
                        StartPointLatitude = c.Double(),
                        EndPointLongitude = c.Double(),
                        EndPointLatitude = c.Double(),
                    })
                .PrimaryKey(t => t.StreetId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Streets");
            DropTable("dbo.Cities");
        }
    }
}
