namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion32 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_Vendor_Program", "VendorId", "dbo.tbl_Vendor");
            DropIndex("dbo.tbl_Vendor_Program", new[] { "VendorId" });
            AddColumn("dbo.tbl_Vendor_Program", "vendor_Vendor_Id", c => c.Int());
            AlterColumn("dbo.tbl_Vendor_Program", "VendorId", c => c.Int());
            CreateIndex("dbo.tbl_Vendor_Program", "vendor_Vendor_Id");
            AddForeignKey("dbo.tbl_Vendor_Program", "vendor_Vendor_Id", "dbo.tbl_Vendor", "Vendor_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Vendor_Program", "vendor_Vendor_Id", "dbo.tbl_Vendor");
            DropIndex("dbo.tbl_Vendor_Program", new[] { "vendor_Vendor_Id" });
            AlterColumn("dbo.tbl_Vendor_Program", "VendorId", c => c.Int(nullable: false));
            DropColumn("dbo.tbl_Vendor_Program", "vendor_Vendor_Id");
            CreateIndex("dbo.tbl_Vendor_Program", "VendorId");
            AddForeignKey("dbo.tbl_Vendor_Program", "VendorId", "dbo.tbl_Vendor", "Vendor_Id", cascadeDelete: true);
        }
    }
}
