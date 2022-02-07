namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion27 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_RolesAppPermission",
                c => new
                    {
                        RolesAppPermission_Id = c.Int(nullable: false, identity: true),
                        Role_Id = c.Int(),
                        Controller = c.String(),
                        Action = c.String(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.RolesAppPermission_Id);
            
            DropColumn("dbo.tbl_RolesUserPermission", "Controller");
            DropColumn("dbo.tbl_RolesUserPermission", "Action");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_RolesUserPermission", "Action", c => c.String());
            AddColumn("dbo.tbl_RolesUserPermission", "Controller", c => c.String());
            DropTable("dbo.tbl_RolesAppPermission");
        }
    }
}
