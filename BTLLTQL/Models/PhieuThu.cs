using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTLLTQL.Models
{
    [Table("PhieuThus")]
    public class PhieuThu
    {
        [Key]
        public String IDPhieuThu { get; set; }
        public String IDKhachHang { get; set; }
        public String Ngay { get; set; }
        public String IDNhanVien { get; set; }
        public String TongTien { get; set; }
    }
}