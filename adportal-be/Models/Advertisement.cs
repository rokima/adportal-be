using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace adportal_be.Models
{
    public class Advertisement
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(80), MinLength(10)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public string Price { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}