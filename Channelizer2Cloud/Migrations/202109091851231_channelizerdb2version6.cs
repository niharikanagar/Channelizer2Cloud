namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdb2version6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_ReferenceDataList", "ReferenceDataListItem_Id", "dbo.tbl_ReferenceDataListItem");
            DropIndex("dbo.tbl_ReferenceDataList", new[] { "ReferenceDataListItem_Id" });
            CreateTable(
                "dbo.tbl_Auditlog",
                c => new
                    {
                        Auditlog_Id = c.Int(nullable: false, identity: true),
                        EventLevel = c.String(),
                        EventType = c.String(),
                        VendorId = c.Int(nullable: false),
                        Message = c.String(),
                        EventRaiser = c.String(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Auditlog_Id);
            
            CreateTable(
                "dbo.tbl_EventLog",
                c => new
                    {
                        EventLog_Id = c.Int(nullable: false, identity: true),
                        EventLevel = c.String(),
                        EventType = c.String(),
                        UserId = c.Guid(),
                        VendorId = c.Int(nullable: false),
                        Message = c.String(),
                        ExceptionMessage = c.String(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.EventLog_Id);
            
            AddColumn("dbo.tbl_ReferenceDataListItem", "ReferenceDataListId", c => c.Int());
            AddColumn("dbo.tbl_ReferenceDataListItem", "referenceDataList_ReferenceDataList_Id", c => c.Int());
            AlterColumn("dbo.tbl_ReferenceDataListItem", "IsActive", c => c.Boolean());
            AlterColumn("dbo.tbl_ReferenceDataListItem", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.tbl_ReferenceDataListItem", "CreatedBy", c => c.Guid());
            AlterColumn("dbo.tbl_ReferenceDataListItem", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.tbl_ReferenceDataListItem", "LastModifiedOn", c => c.DateTime());
            AlterColumn("dbo.tbl_ReferenceDataListItem", "ModifiedBy", c => c.Guid());
            AlterColumn("dbo.tbl_ReferenceDataList", "VendorId", c => c.Int());
            AlterColumn("dbo.tbl_ReferenceDataList", "IsActive", c => c.Boolean());
            AlterColumn("dbo.tbl_ReferenceDataList", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.tbl_ReferenceDataList", "CreatedBy", c => c.Guid());
            AlterColumn("dbo.tbl_ReferenceDataList", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.tbl_ReferenceDataList", "LastModifiedOn", c => c.DateTime());
            AlterColumn("dbo.tbl_ReferenceDataList", "ModifiedBy", c => c.Guid());
            AlterColumn("dbo.tbl_UserLoginDeviceInfo", "login_time", c => c.DateTime());
            AlterColumn("dbo.tbl_Vendor_Program", "VendorId", c => c.Int());
            AlterColumn("dbo.tbl_Vendor_Program", "IsActive", c => c.Boolean());
            AlterColumn("dbo.tbl_Vendor_Program", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.tbl_Vendor_Program", "CreatedBy", c => c.Guid());
            AlterColumn("dbo.tbl_Vendor_Program", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.tbl_Vendor_Program", "LastModifiedOn", c => c.DateTime());
            AlterColumn("dbo.tbl_Vendor_Program", "ModifiedBy", c => c.Guid());
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "VendorId", c => c.Int());
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "VendorProgramId", c => c.Int());
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "FieldTypeId", c => c.Int());
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "ReferenceDataListId", c => c.Int());
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "Sequence", c => c.Int());
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "IsRequired", c => c.Boolean());
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "IsActive", c => c.Boolean());
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "CreatedBy", c => c.Guid());
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "LastModifiedOn", c => c.DateTime());
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "ModifiedBy", c => c.Guid());
            AlterColumn("dbo.tbl_Vendor", "IsActive", c => c.Boolean());
            AlterColumn("dbo.tbl_Vendor", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.tbl_Vendor", "CreatedBy", c => c.Guid());
            AlterColumn("dbo.tbl_Vendor", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.tbl_Vendor", "LastModifiedOn", c => c.DateTime());
            AlterColumn("dbo.tbl_Vendor", "ModifiedBy", c => c.Guid());
            CreateIndex("dbo.tbl_ReferenceDataListItem", "referenceDataList_ReferenceDataList_Id");
            AddForeignKey("dbo.tbl_ReferenceDataListItem", "referenceDataList_ReferenceDataList_Id", "dbo.tbl_ReferenceDataList", "ReferenceDataList_Id");
            DropColumn("dbo.tbl_ReferenceDataList", "ReferenceDataListItem_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_ReferenceDataList", "ReferenceDataListItem_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.tbl_ReferenceDataListItem", "referenceDataList_ReferenceDataList_Id", "dbo.tbl_ReferenceDataList");
            DropIndex("dbo.tbl_ReferenceDataListItem", new[] { "referenceDataList_ReferenceDataList_Id" });
            AlterColumn("dbo.tbl_Vendor", "ModifiedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.tbl_Vendor", "LastModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_Vendor", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbl_Vendor", "CreatedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.tbl_Vendor", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_Vendor", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "ModifiedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "LastModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "CreatedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "IsRequired", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "Sequence", c => c.Int(nullable: false));
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "ReferenceDataListId", c => c.Int(nullable: false));
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "FieldTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "VendorProgramId", c => c.Int(nullable: false));
            AlterColumn("dbo.tbl_Vendor_RegistrationFormField", "VendorId", c => c.Int(nullable: false));
            AlterColumn("dbo.tbl_Vendor_Program", "ModifiedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.tbl_Vendor_Program", "LastModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_Vendor_Program", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbl_Vendor_Program", "CreatedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.tbl_Vendor_Program", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_Vendor_Program", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbl_Vendor_Program", "VendorId", c => c.Int(nullable: false));
            AlterColumn("dbo.tbl_UserLoginDeviceInfo", "login_time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_ReferenceDataList", "ModifiedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.tbl_ReferenceDataList", "LastModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_ReferenceDataList", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbl_ReferenceDataList", "CreatedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.tbl_ReferenceDataList", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_ReferenceDataList", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbl_ReferenceDataList", "VendorId", c => c.Int(nullable: false));
            AlterColumn("dbo.tbl_ReferenceDataListItem", "ModifiedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.tbl_ReferenceDataListItem", "LastModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_ReferenceDataListItem", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbl_ReferenceDataListItem", "CreatedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.tbl_ReferenceDataListItem", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_ReferenceDataListItem", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.tbl_ReferenceDataListItem", "referenceDataList_ReferenceDataList_Id");
            DropColumn("dbo.tbl_ReferenceDataListItem", "ReferenceDataListId");
            DropTable("dbo.tbl_EventLog");
            DropTable("dbo.tbl_Auditlog");
            CreateIndex("dbo.tbl_ReferenceDataList", "ReferenceDataListItem_Id");
            AddForeignKey("dbo.tbl_ReferenceDataList", "ReferenceDataListItem_Id", "dbo.tbl_ReferenceDataListItem", "ReferenceDataListItem_Id", cascadeDelete: true);
        }
    }
}
