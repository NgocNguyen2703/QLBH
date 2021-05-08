using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BTLLTQL.Models
{
    public partial class BTLDbConText : DbContext
    {
        public BTLDbConText()
            : base("name=BTLDbConText")
        {
        }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<LoaiDichVu> LoaiDichVus { get; set; }
        public virtual DbSet<Ban> Bans { get; set; }
        public virtual DbSet<Ca> Cas { get; set; }
        public virtual DbSet<CuaHang> CuaHangs { get; set; }
        public virtual DbSet<PhieuThu> PhieuThus { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<PhieuChi> PhieuChis { get; set; }
        public virtual DbSet<DonGiaThu> DonGiaThus { get; set; }
        public virtual DbSet<DonGiaChi> DonGiaChis { get; set; }
        public virtual DbSet<QuanLy> QuanLys { get; set; }
        public virtual DbSet<CheckAccount> CheckAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
