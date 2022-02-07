namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdb2version2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_FieldType",
                c => new
                    {
                        FieldType_Id = c.Int(nullable: false, identity: true),
                        FieldTypeName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        LastModifiedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FieldType_Id);
            
            CreateTable(
                "dbo.tbl_ReferenceDataListItem",
                c => new
                    {
                        ReferenceDataListItem_Id = c.Int(nullable: false, identity: true),
                        DisplayValue = c.String(),
                        DataValue = c.String(),
                        Sequence = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        LastModifiedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ReferenceDataListItem_Id);
            
            CreateTable(
                "dbo.tbl_ReferenceDataList",
                c => new
                    {
                        ReferenceDataList_Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        ReferenceListName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        LastModifiedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Guid(nullable: false),
                        ReferenceDataListItem_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReferenceDataList_Id)
                .ForeignKey("dbo.tbl_ReferenceDataListItem", t => t.ReferenceDataListItem_Id, cascadeDelete: true)
                .Index(t => t.ReferenceDataListItem_Id);
            
            CreateTable(
                "dbo.tbl_UserLoginDeviceInfo",
                c => new
                    {
                        UserLoginDeviceInfo_Id = c.Int(nullable: false, identity: true),
                        ip = c.String(),
                        country = c.String(),
                        city = c.String(),
                        continent = c.String(),
                        latitude = c.String(),
                        longitude = c.String(),
                        currency_Symbol = c.String(),
                        currency_Code = c.String(),
                        timezone = c.String(),
                        login_time = c.String(),
                    })
                .PrimaryKey(t => t.UserLoginDeviceInfo_Id);
            
            CreateTable(
                "dbo.tbl_Vendor_Program",
                c => new
                    {
                        Vendor_Program_Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        ProgramName = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        LastModifiedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Vendor_Program_Id);
            
            CreateTable(
                "dbo.tbl_Vendor_RegistrationFormField",
                c => new
                    {
                        Vendor_RegistrationFormField_Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        VendorProgramId = c.Int(nullable: false),
                        FieldName = c.String(),
                        FieldLabel = c.String(),
                        FieldTypeId = c.Int(nullable: false),
                        FieldDescription = c.String(),
                        Placeholder = c.String(),
                        ReferenceDataListId = c.Int(nullable: false),
                        Sequence = c.Int(nullable: false),
                        IsRequired = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        LastModifiedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Vendor_RegistrationFormField_Id);
            
            CreateTable(
                "dbo.tbl_Vendor",
                c => new
                    {
                        Vendor_Id = c.Int(nullable: false, identity: true),
                        VendorName = c.String(nullable: false),
                        VendorLogo = c.String(),
                        VendorPrimaryColor = c.String(nullable: false),
                        VendorSecondaryColor = c.String(),
                        VendorFont = c.String(nullable: false),
                        TwitterLink = c.String(),
                        LinkedinLink = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        LastModifiedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Vendor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_ReferenceDataList", "ReferenceDataListItem_Id", "dbo.tbl_ReferenceDataListItem");
            DropIndex("dbo.tbl_ReferenceDataList", new[] { "ReferenceDataListItem_Id" });
            DropTable("dbo.tbl_Vendor");
            DropTable("dbo.tbl_Vendor_RegistrationFormField");
            DropTable("dbo.tbl_Vendor_Program");
            DropTable("dbo.tbl_UserLoginDeviceInfo");
            DropTable("dbo.tbl_ReferenceDataList");
            DropTable("dbo.tbl_ReferenceDataListItem");
            DropTable("dbo.tbl_FieldType");
        }
    }
}
