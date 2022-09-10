using System;
using System.ComponentModel.DataAnnotations;

namespace ActivityCenter.Models
{
    public class ActivityUser
    {
        [Key]
        public int ActivityUserID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int UserID { get; set; }
        public User User { get; set; }
        public int ActivityID { get; set; }
        public Actividad Activity { get; set; }
    }
}