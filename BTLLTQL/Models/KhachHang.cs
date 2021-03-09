using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTLLTQL.Models
{
    [Table("KhachHangs")]
    public class KhachHang
    {
        [Key]
        public  String IDKhachHang { get; set; }
        public  String TenKH { get; set; }
        public  String DiaChi { get; set; }
        public  int SoBan { get; set; }
    }
}