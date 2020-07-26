using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LAM.Models
{
    public class Leave
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Available Leaves")]
        public int AL { get; set; }

        [Required]
        public string Reason { get; set; }

        [Required]
        public DateTime SDate { get; set; }

        [Required]
        public DateTime EDate { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Leave Type ID")]
        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public LType LType { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
