using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTLLTQL.Models
{
    [Table("Cas")]
    public class Ca
    {
        [Key]
        public String IDCa { get; set; }
        public String Ngay { get; set; }
    }
}