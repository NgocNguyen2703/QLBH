using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTLLTQL.Models
{
    [Table("DonGiaChis")]
    public class DonGiaChi
    {
        [Key]
        public String IDPhieuChi { get; set; }
        public String IDDonHang { get; set; }
        public String TongTienHang { get; set; }
    }
}