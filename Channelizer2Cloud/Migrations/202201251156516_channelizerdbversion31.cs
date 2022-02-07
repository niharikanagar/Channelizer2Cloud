namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion31 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_Vendor_Program", "VendorId", "dbo.tbl_Vendor");
            DropIndex("dbo.tbl_Vendor_Program", new[] { "VendorId" });
            AlterColumn("dbo.tbl_Vendor_Program", "VendorId", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_Vendor_Program", "VendorId");
            AddForeignKey("dbo.tbl_Vendor_Program", "VendorId", "dbo.tbl_Vendor", "Vendor_Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Vendor_Program", "VendorId", "dbo.tbl_Vendor");
            DropIndex("dbo.tbl_Vendor_Program", new[] { "VendorId" });
            AlterColumn("dbo.tbl_Vendor_Program", "VendorId", c => c.Int());
            CreateIndex("dbo.tbl_Vendor_Program", "VendorId");
            AddForeignKey("dbo.tbl_Vendor_Program", "VendorId", "dbo.tbl_Vendor", "Vendor_Id");
        }
    }
}
