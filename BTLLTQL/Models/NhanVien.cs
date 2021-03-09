using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTLLTQL.Models
{
    [Table("NhanViens")]
    public class NhanVien
    {
        [Key]
        public String IDNhanVien { get; set; }
        public String TenNhanVien { get; set; }
        public String SĐT { get; set; }
    }
}