using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC00.Models
{
    public class Status
    {
        public string Author { get; set; }
        public DateTime Timestamp { get; set; }
        public string Project { get; set; }

        [Required]
        [MaxLength(140, ErrorMessage = "Your status is too long, the shorter the cooler")]
        [Display(Name="Status")]
        public string Text { get; set; }
        public string ImageUrl { get; set; }
    }
}