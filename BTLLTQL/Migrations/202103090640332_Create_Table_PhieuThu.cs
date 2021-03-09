namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_PhieuThu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhieuThus",
                c => new
                    {
                        IDPhieuThu = c.String(nullable: false, maxLength: 128),
                        IDKhachHang = c.String(),
                        Ngay = c.String(),
                        IDNhanVien = c.String(),
                        TongTien = c.String(),
                    })
                .PrimaryKey(t => t.IDPhieuThu);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhieuThus");
        }
    }
}
