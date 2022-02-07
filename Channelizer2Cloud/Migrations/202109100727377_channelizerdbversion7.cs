namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_UserLoginDeviceInfo", "onetimepassword", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_UserLoginDeviceInfo", "onetimepassword");
        }
    }
}
