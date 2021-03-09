using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTLLTQL.Models
{
    [Table("CuaHangs")]
    public class CuaHang
    {
        [Key]
        public String IDCuaHang { get; set; }
        public String TenCuaHang { get; set; }
        public String ChiNhanh { get; set; }
    }
}