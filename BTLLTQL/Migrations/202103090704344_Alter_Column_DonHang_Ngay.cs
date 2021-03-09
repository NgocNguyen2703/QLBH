namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Column_DonHang_Ngay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonHangs", "Ngay", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonHangs", "Ngay");
        }
    }
}
