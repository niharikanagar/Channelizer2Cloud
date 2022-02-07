namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usertype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_UserType",
                c => new
                    {
                        UserType_Id = c.Int(nullable: false, identity: true),
                        UserTypeName = c.String(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.UserType_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_UserType");
        }
    }
}
