namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion33 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.tbl_Vendor_Program", name: "vendor_Vendor_Id", newName: "Vendor_Id");
            RenameIndex(table: "dbo.tbl_Vendor_Program", name: "IX_vendor_Vendor_Id", newName: "IX_Vendor_Id");
            DropColumn("dbo.tbl_Vendor_Program", "VendorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_Vendor_Program", "VendorId", c => c.Int());
            RenameIndex(table: "dbo.tbl_Vendor_Program", name: "IX_Vendor_Id", newName: "IX_vendor_Vendor_Id");
            RenameColumn(table: "dbo.tbl_Vendor_Program", name: "Vendor_Id", newName: "vendor_Vendor_Id");
        }
    }
}
