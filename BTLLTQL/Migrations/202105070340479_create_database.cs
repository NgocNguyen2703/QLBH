namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bans",
                c => new
                    {
                        IDBan = c.String(nullable: false, maxLength: 128),
                        SoBan = c.String(),
                    })
                .PrimaryKey(t => t.IDBan);
            
            CreateTable(
                "dbo.Cas",
                c => new
                    {
                        IDCa = c.String(nullable: false, maxLength: 128),
                        Ngay = c.String(),
                        Gio = c.String(),
                    })
                .PrimaryKey(t => t.IDCa);
            
            CreateTable(
                "dbo.CheckAccounts",
                c => new
                    {
                        CheckUsername = c.String(nullable: false, maxLength: 128),
                        CheckPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CheckUsername);
            
            CreateTable(
                "dbo.CuaHangs",
                c => new
                    {
                        IDCuaHang = c.String(nullable: false, maxLength: 128),
                        TenCuaHang = c.String(),
                        ChiNhanh = c.String(),
                    })
                .PrimaryKey(t => t.IDCuaHang);
            
            CreateTable(
                "dbo.DichVus",
                c => new
                    {
                        IDDichVu = c.String(nullable: false, maxLength: 128),
                        TenDV = c.String(),
                        IDLoaiDV = c.String(),
                    })
                .PrimaryKey(t => t.IDDichVu);
            
            CreateTable(
                "dbo.DonGiaChis",
                c => new
                    {
                        IDPhieuChi = c.String(nullable: false, maxLength: 128),
                        IDDonHang = c.String(),
                        TongTienHang = c.String(),
                    })
                .PrimaryKey(t => t.IDPhieuChi);
            
            CreateTable(
                "dbo.DonGiaThus",
                c => new
                    {
                        IDPhieuThu = c.String(nullable: false, maxLength: 128),
                        IDDichVu = c.String(),
                        TenDV = c.String(),
                        DonGia = c.String(),
                    })
                .PrimaryKey(t => t.IDPhieuThu);
            
            CreateTable(
                "dbo.DonHangs",
                c => new
                    {
                        IĐonHang = c.String(nullable: false, maxLength: 128),
                        IDDichVu = c.String(),
                        IDNhanVien = c.String(),
                        Ngay = c.String(),
                    })
                .PrimaryKey(t => t.IĐonHang);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        IDKhachHang = c.String(nullable: false, maxLength: 128),
                        TenKH = c.String(),
                        DiaChi = c.String(),
                        SoBan = c.String(),
                    })
                .PrimaryKey(t => t.IDKhachHang);
            
            CreateTable(
                "dbo.LoaiDichVus",
                c => new
                    {
                        IDLoaiDichVu = c.String(nullable: false, maxLength: 128),
                        TenLoaiDichVu = c.String(),
                    })
                .PrimaryKey(t => t.IDLoaiDichVu);
            
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        IDNhanVien = c.String(nullable: false, maxLength: 128),
                        TenNhanVien = c.String(),
                        SĐT = c.String(),
                    })
                .PrimaryKey(t => t.IDNhanVien);
            
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
            
            CreateTable(
                "dbo.QuanLys",
                c => new
                    {
                        IDNhanVien = c.String(nullable: false, maxLength: 128),
                        IDBan = c.String(),
                        IDCa = c.String(),
                    })
                .PrimaryKey(t => t.IDNhanVien);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QuanLys");
            DropTable("dbo.PhieuThus");
            DropTable("dbo.PhieuChis");
            DropTable("dbo.NhanViens");
            DropTable("dbo.LoaiDichVus");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.DonHangs");
            DropTable("dbo.DonGiaThus");
            DropTable("dbo.DonGiaChis");
            DropTable("dbo.DichVus");
            DropTable("dbo.CuaHangs");
            DropTable("dbo.CheckAccounts");
            DropTable("dbo.Cas");
            DropTable("dbo.Bans");
        }
    }
}
