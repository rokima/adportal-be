using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace adportal_be.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        [Required]
        public string FileName { get; set; }
        public string Data { get; set; }
    }
}