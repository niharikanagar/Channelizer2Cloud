namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdb2version4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_UserLoginDeviceInfo", "login_time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_UserLoginDeviceInfo", "login_time", c => c.String());
        }
    }
}
