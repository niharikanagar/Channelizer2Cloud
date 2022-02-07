namespace Channelizer2Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelizerdbversion25 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Mvs_Deal", "ProgramId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Mvs_Deal", "ProgramId");
        }
    }
}
