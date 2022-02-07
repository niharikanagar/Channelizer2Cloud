namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion30 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.tbl_Vendor_Program", "VendorId");
            AddForeignKey("dbo.tbl_Vendor_Program", "VendorId", "dbo.tbl_Vendor", "Vendor_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Vendor_Program", "VendorId", "dbo.tbl_Vendor");
            DropIndex("dbo.tbl_Vendor_Program", new[] { "VendorId" });
        }
    }
}
