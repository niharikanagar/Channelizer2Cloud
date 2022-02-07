namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_User_LogTime", "SessionId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_User_LogTime", "SessionId", c => c.Int(nullable: false));
        }
    }
}
