namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion24 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_ReferenceDataListItem",
                c => new
                    {
                        ReferenceDataListItem_Id = c.Int(nullable: false, identity: true),
                        ReferenceDataListId = c.Int(),
                        ProgramId = c.Int(),
                        DisplayValue = c.String(),
                        DataValue = c.String(),
                        Sequence = c.Int(nullable: false),
                        IsActive = c.Boolean(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.ReferenceDataListItem_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_ReferenceDataListItem");
        }
    }
}
