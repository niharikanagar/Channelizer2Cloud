namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion29 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Mvs_DealData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mvs_DealId = c.Int(nullable: false),
                        DataKey = c.String(),
                        DataValue = c.String(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_Mvs_DealData");
        }
    }
}
