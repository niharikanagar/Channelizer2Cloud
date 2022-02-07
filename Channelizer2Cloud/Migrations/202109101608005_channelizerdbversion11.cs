namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_UserInformation",
                c => new
                    {
                        UserInformation_Id = c.Guid(nullable: false),
                        UserTypeId = c.Int(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Password = c.String(),
                        SuccessfulLoginCount = c.Int(),
                        ForcePasswordChangeNextLogin = c.Boolean(),
                        IsActive = c.Boolean(),
                        IsLockedOut = c.Boolean(),
                        LastLogindate = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.UserInformation_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_UserInformation");
        }
    }
}
