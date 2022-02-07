namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion26 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_AllActions",
                c => new
                    {
                        Action_Id = c.Int(nullable: false, identity: true),
                        ActionName = c.String(),
                        Controller_Id = c.Int(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Action_Id)
                .ForeignKey("dbo.tbl_AllControllers", t => t.Controller_Id)
                .Index(t => t.Controller_Id);
            
            CreateTable(
                "dbo.tbl_AllControllers",
                c => new
                    {
                        Controller_Id = c.Int(nullable: false, identity: true),
                        ControllerName = c.String(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Controller_Id);
            
            CreateTable(
                "dbo.tbl_Roles",
                c => new
                    {
                        Role_Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Role_Id);
            
            CreateTable(
                "dbo.tbl_RolesUserPermission",
                c => new
                    {
                        RolesUserPermission_Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Guid(),
                        Role_Id = c.Int(),
                        Controller = c.String(),
                        Action = c.String(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.RolesUserPermission_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_AllActions", "Controller_Id", "dbo.tbl_AllControllers");
            DropIndex("dbo.tbl_AllActions", new[] { "Controller_Id" });
            DropTable("dbo.tbl_RolesUserPermission");
            DropTable("dbo.tbl_Roles");
            DropTable("dbo.tbl_AllControllers");
            DropTable("dbo.tbl_AllActions");
        }
    }
}
