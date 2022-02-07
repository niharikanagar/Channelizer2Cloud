namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion71 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_UserLoginDeviceInfo", "user_id", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_UserLoginDeviceInfo", "user_id");
        }
    }
}
