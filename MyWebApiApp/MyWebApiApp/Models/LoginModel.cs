﻿using System.ComponentModel.DataAnnotations; 

namespace MyWebApiApp.Models
 
{
    public class LoginModel
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength (50)]
        public string Password { get; set; }     
    }
}
