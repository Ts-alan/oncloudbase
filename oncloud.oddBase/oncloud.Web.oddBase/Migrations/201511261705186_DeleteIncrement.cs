namespace oncloud.Web.oddBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteIncrement : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpecificationOfRbs", "SegmentId", "dbo.Segment");
            DropForeignKey("dbo.SpecificationofRS", "SegmentId", "dbo.Segment");
            DropPrimaryKey("dbo.layoutDislocations");
            DropPrimaryKey("dbo.Segment");
            AlterColumn("dbo.layoutDislocations", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Segment", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.layoutDislocations", "id");
            AddPrimaryKey("dbo.Segment", "Id");
            AddForeignKey("dbo.SpecificationOfRbs", "SegmentId", "dbo.Segment", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SpecificationofRS", "SegmentId", "dbo.Segment", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecificationofRS", "SegmentId", "dbo.Segment");
            DropForeignKey("dbo.SpecificationOfRbs", "SegmentId", "dbo.Segment");
            DropPrimaryKey("dbo.Segment");
            DropPrimaryKey("dbo.layoutDislocations");
            AlterColumn("dbo.Segment", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.layoutDislocations", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Segment", "id");
            AddPrimaryKey("dbo.layoutDislocations", "Id");
            AddForeignKey("dbo.SpecificationofRS", "SegmentId", "dbo.Segment", "id", cascadeDelete: true);
            AddForeignKey("dbo.SpecificationOfRbs", "SegmentId", "dbo.Segment", "id", cascadeDelete: true);
        }
    }
}
