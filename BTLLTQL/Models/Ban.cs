﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTLLTQL.Models
{
    [Table("Bans")]
    public class Ban
    {
        [Key]
        public String IDBan { get; set; }
        public String SoBan { get; set; }
    }
}