using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTLLTQL.Models
{
    [Table("CheckAccounts")]
    public class CheckAccount
    {
        [Key]
        //Validation with Model
        //UserName k được để trống
        [Required(ErrorMessage = "Username is required.")]
        public string CheckUsername { get; set; }
        //password k được để trống 
        [Required(ErrorMessage = "Password is required.")]
        //Định nghĩa DataType
        [DataType(DataType.Password)]
        public string CheckPassword { get; set; }
    }
}