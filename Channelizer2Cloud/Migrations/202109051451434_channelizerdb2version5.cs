namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdb2version5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_FieldType", "IsActive", c => c.Boolean());
            AlterColumn("dbo.tbl_FieldType", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.tbl_FieldType", "CreatedBy", c => c.Guid());
            AlterColumn("dbo.tbl_FieldType", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.tbl_FieldType", "LastModifiedOn", c => c.DateTime());
            AlterColumn("dbo.tbl_FieldType", "ModifiedBy", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_FieldType", "ModifiedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.tbl_FieldType", "LastModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_FieldType", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbl_FieldType", "CreatedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.tbl_FieldType", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_FieldType", "IsActive", c => c.Boolean(nullable: false));
        }
    }
}
