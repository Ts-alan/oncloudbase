namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relshiship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TextForRS", "RoadSigns_id", "dbo.RoadSigns");
            DropForeignKey("dbo.TextForRS", "Id", "dbo.DescriptionForRS");
            DropIndex("dbo.TextForRS", new[] { "RoadSigns_id" });
            RenameColumn(table: "dbo.TextForRS", name: "RoadSigns_id", newName: "RoadSignsId");
            DropPrimaryKey("dbo.DescriptionForRS");
            AddColumn("dbo.DescriptionForRS", "RoadSignId", c => c.Int(nullable: false));
            AlterColumn("dbo.DescriptionForRS", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.TextForRS", "RoadSignsId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.DescriptionForRS", "Id");
            CreateIndex("dbo.DescriptionForRS", "Id");
            CreateIndex("dbo.TextForRS", "RoadSignsId");
            AddForeignKey("dbo.DescriptionForRS", "Id", "dbo.ImageForRS", "Id");
            AddForeignKey("dbo.TextForRS", "RoadSignsId", "dbo.RoadSigns", "id", cascadeDelete: true);
            AddForeignKey("dbo.TextForRS", "Id", "dbo.DescriptionForRS", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TextForRS", "Id", "dbo.DescriptionForRS");
            DropForeignKey("dbo.TextForRS", "RoadSignsId", "dbo.RoadSigns");
            DropForeignKey("dbo.DescriptionForRS", "Id", "dbo.ImageForRS");
            DropIndex("dbo.TextForRS", new[] { "RoadSignsId" });
            DropIndex("dbo.DescriptionForRS", new[] { "Id" });
            DropPrimaryKey("dbo.DescriptionForRS");
            AlterColumn("dbo.TextForRS", "RoadSignsId", c => c.Int());
            AlterColumn("dbo.DescriptionForRS", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.DescriptionForRS", "RoadSignId");
            AddPrimaryKey("dbo.DescriptionForRS", "Id");
            RenameColumn(table: "dbo.TextForRS", name: "RoadSignsId", newName: "RoadSigns_id");
            CreateIndex("dbo.TextForRS", "RoadSigns_id");
            AddForeignKey("dbo.TextForRS", "Id", "dbo.DescriptionForRS", "Id");
            AddForeignKey("dbo.TextForRS", "RoadSigns_id", "dbo.RoadSigns", "id");
        }
    }
}
