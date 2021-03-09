using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTLLTQL.Models
{
    [Table("QuanLys")]
    public class QuanLy
    {
        [Key]
        public String IDNhanVien { get; set; }
        public String IDBan { get; set; }
        public String IDCa { get; set; }
    }
}