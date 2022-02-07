namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdb2version3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_UserLoginDeviceInfo", "region", c => c.String());
            AddColumn("dbo.tbl_UserLoginDeviceInfo", "loc", c => c.String());
            AddColumn("dbo.tbl_UserLoginDeviceInfo", "org", c => c.String());
            AddColumn("dbo.tbl_UserLoginDeviceInfo", "postal", c => c.String());
            DropColumn("dbo.tbl_UserLoginDeviceInfo", "continent");
            DropColumn("dbo.tbl_UserLoginDeviceInfo", "latitude");
            DropColumn("dbo.tbl_UserLoginDeviceInfo", "longitude");
            DropColumn("dbo.tbl_UserLoginDeviceInfo", "currency_Symbol");
            DropColumn("dbo.tbl_UserLoginDeviceInfo", "currency_Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_UserLoginDeviceInfo", "currency_Code", c => c.String());
            AddColumn("dbo.tbl_UserLoginDeviceInfo", "currency_Symbol", c => c.String());
            AddColumn("dbo.tbl_UserLoginDeviceInfo", "longitude", c => c.String());
            AddColumn("dbo.tbl_UserLoginDeviceInfo", "latitude", c => c.String());
            AddColumn("dbo.tbl_UserLoginDeviceInfo", "continent", c => c.String());
            DropColumn("dbo.tbl_UserLoginDeviceInfo", "postal");
            DropColumn("dbo.tbl_UserLoginDeviceInfo", "org");
            DropColumn("dbo.tbl_UserLoginDeviceInfo", "loc");
            DropColumn("dbo.tbl_UserLoginDeviceInfo", "region");
        }
    }
}
