using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KapyNews2.Models
{
    public class UserAccount
    {
        [Key]
        public int userId { get; set; }


        [Required(ErrorMessage = "Please provide a valid username", AllowEmptyStrings = false)]
        public string userName { get; set; }

        [Required(ErrorMessage = "Please provide a valid password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be 8 character long.")]
        public string password { get; set; }

        [Compare("password", ErrorMessage = "Please confirm your password")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string confirmPassword { get; set; }


     
  
        public string email { get; set; }
        public bool isActive { get; set; }
        public int roleID { get; set; }
        public int notifyFreq { get; set; }
        public bool isNotified { get; set; }

    }
}