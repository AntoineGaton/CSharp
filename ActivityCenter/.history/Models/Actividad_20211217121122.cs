using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActivityCenter.Models
{
    public class Actividad
    {
        [Key]
        public int ActividadID { get; set; }//TO BE SAFE MAKE SURE TO NAME ID THE SAME AS CLASS

        [Required(ErrorMessage = "Activity name is required!")]
        [MinLength(3, ErrorMessage = "Activity name must contain at least three characters...")]
        [Display(Name = "Activity Name")]
        public string ActivityName { get; set; }
    
        [Required(ErrorMessage = "Date is required!")]
        [DataType(DataType.Date)]
        [Display(Name = "Activity Date")]
        public DateTime ActivityDate { get; set; }
        
        [Required(ErrorMessage = "Activity time is required!")]
        [DataType(DataType.Time)]
        [Display(Name = "Activity Time")]
        public DateTime ActivityTime { get; set; }

        [Required(ErrorMessage = "Duration is required!")]
        [DataType(DataType.Time)]
        [Display(Name = "Duration")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Description of the activity is required!")]
        [MinLength(5, ErrorMessage = "Must be more than 5 characters...")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int UserID { get; set; }
        public User User { get; set; }
        public List<ActivityUser> ActiveUser { get; set; }

    }
}