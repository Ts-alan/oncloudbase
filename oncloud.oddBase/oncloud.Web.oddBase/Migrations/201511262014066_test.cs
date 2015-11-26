namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpecificationOfRbs", "SegmentId", "dbo.Segment");
            DropForeignKey("dbo.SpecificationofRS", "SegmentId", "dbo.Segment");
            DropForeignKey("dbo.layoutDislocations", "Id", "dbo.Segment");
            DropPrimaryKey("dbo.Segment");
            AlterColumn("dbo.Segment", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Segment", "id");
            AddForeignKey("dbo.SpecificationOfRbs", "SegmentId", "dbo.Segment", "id", cascadeDelete: true);
            AddForeignKey("dbo.SpecificationofRS", "SegmentId", "dbo.Segment", "id", cascadeDelete: true);
            AddForeignKey("dbo.layoutDislocations", "Id", "dbo.Segment", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.layoutDislocations", "Id", "dbo.Segment");
            DropForeignKey("dbo.SpecificationofRS", "SegmentId", "dbo.Segment");
            DropForeignKey("dbo.SpecificationOfRbs", "SegmentId", "dbo.Segment");
            DropPrimaryKey("dbo.Segment");
            AlterColumn("dbo.Segment", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Segment", "id");
            AddForeignKey("dbo.layoutDislocations", "Id", "dbo.Segment", "id");
            AddForeignKey("dbo.SpecificationofRS", "SegmentId", "dbo.Segment", "id", cascadeDelete: true);
            AddForeignKey("dbo.SpecificationOfRbs", "SegmentId", "dbo.Segment", "id", cascadeDelete: true);
        }
    }
}
