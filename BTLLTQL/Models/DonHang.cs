using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTLLTQL.Models
{
    [Table("DonHangs")]
    public class DonHang
    {
        [Key]
        public String IĐonHang { get; set; }
        public String IDDichVu { get; set; }
        public String IDNhanVien { get; set; }
        public String Ngay { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual DichVu DichVu { get; set; }
    }
}