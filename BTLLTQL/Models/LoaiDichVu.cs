using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTLLTQL.Models
{
    [Table("LoaiDichVus")]
    public class LoaiDichVu
    {
        [Key]
        public String IDLoaiDichVu { get; set; }
        public String TenLoaiDichVu { get; set; }
    }
}