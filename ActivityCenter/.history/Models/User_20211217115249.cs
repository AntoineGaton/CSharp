using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityCenter.Models
{
    public class User
    {
        [Key]
        public int UserUD { get; set; }

        [Required(ErrorMessage = "Name is required...")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long...")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required...")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required...")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters...")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password is Invalid, Please make sure that there is at least 1 uppercase, 1 lowercase, and 1 special character.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [NotMapped] //Makes sure that it doesn't get added to DB
        [Required(ErrorMessage = "Please confirm password...")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match!")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Actividad> CreatedActivities { get; set; }
        public List<ActivityUser> ActiveUser { get; set; }
    }
}