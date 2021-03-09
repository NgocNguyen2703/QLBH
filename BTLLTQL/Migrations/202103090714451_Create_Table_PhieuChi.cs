namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_PhieuChi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhieuChis",
                c => new
                    {
                        IDPhieuChi = c.String(nullable: false, maxLength: 128),
                        IDNhanVien = c.String(),
                        IDCuaHang = c.String(),
                        Ngay = c.String(),
                        Tongtienchi = c.String(),
                    })
                .PrimaryKey(t => t.IDPhieuChi);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhieuChis");
        }
    }
}
