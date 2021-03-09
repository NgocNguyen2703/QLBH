namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_DonHang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonHangs",
                c => new
                    {
                        IĐonHang = c.String(nullable: false, maxLength: 128),
                        IDDichVu = c.String(),
                        IDNhanVien = c.String(),
                    })
                .PrimaryKey(t => t.IĐonHang);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DonHangs");
        }
    }
}
