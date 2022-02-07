namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion23 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_CustomerContact",
                c => new
                    {
                        CustomerContact_Id = c.Int(nullable: false, identity: true),
                        Customer_Id = c.Int(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Title = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        Mobile = c.String(),
                        Website = c.String(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.CustomerContact_Id)
                .ForeignKey("dbo.tbl_Customer", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.tbl_Customer",
                c => new
                    {
                        Customer_Id = c.Int(nullable: false, identity: true),
                        Mvs_VarId = c.Int(),
                        Name = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Website = c.String(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Customer_Id);
            
            CreateTable(
                "dbo.tbl_Mvs_Deal",
                c => new
                    {
                        Mvs_Deal_Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(),
                        DealName = c.String(),
                        DealDescription = c.String(),
                        ExpectedRevenue = c.String(),
                        DealStatus = c.String(),
                        SubmittedOn = c.DateTime(),
                        Mvs_VarId = c.Int(),
                        CustomerId = c.Int(),
                        CustomerContactId = c.Int(),
                        SalesRepId = c.Int(),
                        SubmitedBy = c.Int(),
                        IsActive = c.Boolean(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Mvs_Deal_Id);
            
            CreateTable(
                "dbo.tbl_MvsSalesRepresentative",
                c => new
                    {
                        MvsSalesRepresentative_Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        IsActive = c.Boolean(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.MvsSalesRepresentative_Id);
            
            CreateTable(
                "dbo.tbl_VarUser",
                c => new
                    {
                        VarUser_Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(),
                        Mvs_VarId = c.Int(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.VarUser_Id);
            
            CreateTable(
                "dbo.tbl_VendorUser",
                c => new
                    {
                        VendorUser_Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(),
                        VendorId = c.Int(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.VendorUser_Id);
            
            DropTable("dbo.tbl_ReferenceDataListItem");
        }
        
        public override void Down()
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
            
            DropForeignKey("dbo.tbl_CustomerContact", "Customer_Id", "dbo.tbl_Customer");
            DropIndex("dbo.tbl_CustomerContact", new[] { "Customer_Id" });
            DropTable("dbo.tbl_VendorUser");
            DropTable("dbo.tbl_VarUser");
            DropTable("dbo.tbl_MvsSalesRepresentative");
            DropTable("dbo.tbl_Mvs_Deal");
            DropTable("dbo.tbl_Customer");
            DropTable("dbo.tbl_CustomerContact");
        }
    }
}
