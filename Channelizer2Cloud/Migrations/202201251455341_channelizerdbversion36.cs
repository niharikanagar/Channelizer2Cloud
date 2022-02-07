namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion36 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.tbl_Mvs_Deal", name: "mvsSalesRepresentative_MvsSalesRepresentative_Id", newName: "MvsSalesRepresentative_Id");
            RenameIndex(table: "dbo.tbl_Mvs_Deal", name: "IX_mvsSalesRepresentative_MvsSalesRepresentative_Id", newName: "IX_MvsSalesRepresentative_Id");
            DropColumn("dbo.tbl_Mvs_Deal", "SalesRepId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_Mvs_Deal", "SalesRepId", c => c.Int());
            RenameIndex(table: "dbo.tbl_Mvs_Deal", name: "IX_MvsSalesRepresentative_Id", newName: "IX_mvsSalesRepresentative_MvsSalesRepresentative_Id");
            RenameColumn(table: "dbo.tbl_Mvs_Deal", name: "MvsSalesRepresentative_Id", newName: "mvsSalesRepresentative_MvsSalesRepresentative_Id");
        }
    }
}
