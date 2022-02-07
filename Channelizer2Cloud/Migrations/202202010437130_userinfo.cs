namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_UserInformation", "role_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_UserInformation", "role_id");
        }
    }
}
