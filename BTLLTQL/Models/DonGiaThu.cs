using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTLLTQL.Models
{
    [Table("DonGiaThus")]
    public class DonGiaThu
    {
        [Key]
        public String IDPhieuThu { get; set; }
        public String IDDichVu { get; set; }
        public String TenDV { get; set; }
        public String DonGia { get; set; }
    }
}