using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTLLTQL.Models
{
    [Table("DichVus")]
    public class DichVu
    {
        [Key]
        public String IDDichVu { get; set; }
        public String TenDV { get; set; }
        public String IDLoaiDV { get; set; }
    }
}