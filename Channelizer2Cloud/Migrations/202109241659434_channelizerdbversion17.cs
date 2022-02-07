namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion17 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_ReferenceDataListItem", "referenceDataList_ReferenceDataList_Id", "dbo.tbl_ReferenceDataList");
            DropIndex("dbo.tbl_ReferenceDataListItem", new[] { "referenceDataList_ReferenceDataList_Id" });
            AddColumn("dbo.tbl_ReferenceDataListItem", "ProgramId", c => c.Int());
            AlterColumn("dbo.tbl_ReferenceDataListItem", "Sequence", c => c.Int(nullable: false));
            DropColumn("dbo.tbl_ReferenceDataListItem", "referenceDataList_ReferenceDataList_Id");
            DropTable("dbo.tbl_ReferenceDataList");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tbl_ReferenceDataList",
                c => new
                    {
                        ReferenceDataList_Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(),
                        ReferenceListName = c.String(),
                        IsActive = c.Boolean(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.ReferenceDataList_Id);
            
            AddColumn("dbo.tbl_ReferenceDataListItem", "referenceDataList_ReferenceDataList_Id", c => c.Int());
            AlterColumn("dbo.tbl_ReferenceDataListItem", "Sequence", c => c.String());
            DropColumn("dbo.tbl_ReferenceDataListItem", "ProgramId");
            CreateIndex("dbo.tbl_ReferenceDataListItem", "referenceDataList_ReferenceDataList_Id");
            AddForeignKey("dbo.tbl_ReferenceDataListItem", "referenceDataList_ReferenceDataList_Id", "dbo.tbl_ReferenceDataList", "ReferenceDataList_Id");
        }
    }
}
