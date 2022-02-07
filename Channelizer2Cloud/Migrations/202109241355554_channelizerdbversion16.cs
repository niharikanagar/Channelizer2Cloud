namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Country",
                c => new
                    {
                        Country_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                        ISOCode = c.String(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Country_Id);
            
            CreateTable(
                "dbo.tbl_State",
                c => new
                    {
                        State_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                        ISOCode = c.String(),
                        Country_Id = c.Int(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                        LastModifiedOn = c.DateTime(),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.State_Id)
                .ForeignKey("dbo.tbl_Country", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_State", "Country_Id", "dbo.tbl_Country");
            DropIndex("dbo.tbl_State", new[] { "Country_Id" });
            DropTable("dbo.tbl_State");
            DropTable("dbo.tbl_Country");
        }
    }
}
