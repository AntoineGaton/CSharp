using System;
using System.ComponentModel.DataAnnotations;

namespace ActivityCenter.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Email is required...")]
        [EmailAddress]
        [Display(Name = "Login Email")]
        public string LoginEmail { get; set; }

        [Required(ErrorMessage = "Password is required...")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters...")]
        [Display(Name = "Login Password")]
        public string LoginPassword { get; set; }
    }
}