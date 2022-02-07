namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion35 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Mvs_Deal", "Vendor_Id", c => c.Int());
            AddColumn("dbo.tbl_Mvs_Deal", "Vendor_Program_Id", c => c.Int());
            AddColumn("dbo.tbl_Mvs_Deal", "Customer_Id", c => c.Int());
            AddColumn("dbo.tbl_Mvs_Deal", "CustomerContact_Id", c => c.Int());
            AddColumn("dbo.tbl_Mvs_Deal", "mvsSalesRepresentative_MvsSalesRepresentative_Id", c => c.Int());
            CreateIndex("dbo.tbl_Mvs_Deal", "Vendor_Id");
            CreateIndex("dbo.tbl_Mvs_Deal", "Vendor_Program_Id");
            CreateIndex("dbo.tbl_Mvs_Deal", "Customer_Id");
            CreateIndex("dbo.tbl_Mvs_Deal", "CustomerContact_Id");
            CreateIndex("dbo.tbl_Mvs_Deal", "mvsSalesRepresentative_MvsSalesRepresentative_Id");
            AddForeignKey("dbo.tbl_Mvs_Deal", "Customer_Id", "dbo.tbl_Customer", "Customer_Id");
            AddForeignKey("dbo.tbl_Mvs_Deal", "CustomerContact_Id", "dbo.tbl_CustomerContact", "CustomerContact_Id");
            AddForeignKey("dbo.tbl_Mvs_Deal", "mvsSalesRepresentative_MvsSalesRepresentative_Id", "dbo.tbl_MvsSalesRepresentative", "MvsSalesRepresentative_Id");
            AddForeignKey("dbo.tbl_Mvs_Deal", "Vendor_Id", "dbo.tbl_Vendor", "Vendor_Id");
            AddForeignKey("dbo.tbl_Mvs_Deal", "Vendor_Program_Id", "dbo.tbl_Vendor_Program", "Vendor_Program_Id");
            DropColumn("dbo.tbl_Mvs_Deal", "VendorId");
            DropColumn("dbo.tbl_Mvs_Deal", "ProgramId");
            DropColumn("dbo.tbl_Mvs_Deal", "CustomerId");
            DropColumn("dbo.tbl_Mvs_Deal", "CustomerContactId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_Mvs_Deal", "CustomerContactId", c => c.Int());
            AddColumn("dbo.tbl_Mvs_Deal", "CustomerId", c => c.Int());
            AddColumn("dbo.tbl_Mvs_Deal", "ProgramId", c => c.Int());
            AddColumn("dbo.tbl_Mvs_Deal", "VendorId", c => c.Int());
            DropForeignKey("dbo.tbl_Mvs_Deal", "Vendor_Program_Id", "dbo.tbl_Vendor_Program");
            DropForeignKey("dbo.tbl_Mvs_Deal", "Vendor_Id", "dbo.tbl_Vendor");
            DropForeignKey("dbo.tbl_Mvs_Deal", "mvsSalesRepresentative_MvsSalesRepresentative_Id", "dbo.tbl_MvsSalesRepresentative");
            DropForeignKey("dbo.tbl_Mvs_Deal", "CustomerContact_Id", "dbo.tbl_CustomerContact");
            DropForeignKey("dbo.tbl_Mvs_Deal", "Customer_Id", "dbo.tbl_Customer");
            DropIndex("dbo.tbl_Mvs_Deal", new[] { "mvsSalesRepresentative_MvsSalesRepresentative_Id" });
            DropIndex("dbo.tbl_Mvs_Deal", new[] { "CustomerContact_Id" });
            DropIndex("dbo.tbl_Mvs_Deal", new[] { "Customer_Id" });
            DropIndex("dbo.tbl_Mvs_Deal", new[] { "Vendor_Program_Id" });
            DropIndex("dbo.tbl_Mvs_Deal", new[] { "Vendor_Id" });
            DropColumn("dbo.tbl_Mvs_Deal", "mvsSalesRepresentative_MvsSalesRepresentative_Id");
            DropColumn("dbo.tbl_Mvs_Deal", "CustomerContact_Id");
            DropColumn("dbo.tbl_Mvs_Deal", "Customer_Id");
            DropColumn("dbo.tbl_Mvs_Deal", "Vendor_Program_Id");
            DropColumn("dbo.tbl_Mvs_Deal", "Vendor_Id");
        }
    }
}
