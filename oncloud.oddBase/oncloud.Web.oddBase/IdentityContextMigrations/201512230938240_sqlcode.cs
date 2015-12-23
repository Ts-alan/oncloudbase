namespace oncloud.Web.oddBase.IdentityContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sqlcode : DbMigration
    {
        public override void Up()
        {
            Sql("Delete From AspNetRoles ");
            Sql("Delete From AspNetUsers ");
        }
        
        public override void Down()
        {
        }
    }
}
