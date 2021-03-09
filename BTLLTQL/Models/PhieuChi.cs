using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTLLTQL.Models
{
    [Table("PhieuChis")]
    public class PhieuChi
    {
        [Key]
        public String IDPhieuChi { get; set; }
        public String IDNhanVien { get; set; }
        public String IDCuaHang { get; set; }
        public String Ngay { get; set; }
        public String Tongtienchi { get; set; }

    }
}