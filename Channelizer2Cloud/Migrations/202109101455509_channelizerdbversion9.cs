namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_User_LogTime",
                c => new
                    {
                        User_LogTime_Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(),
                        SessionId = c.Int(nullable: false),
                        LogInTime = c.DateTime(),
                        LogOutTime = c.DateTime(),
                        Offline = c.Boolean(),
                    })
                .PrimaryKey(t => t.User_LogTime_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_User_LogTime");
        }
    }
}
