using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace adportal_be.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email in not valid")]
        public string Email { get; set; }
        [Required]
        [StringLength(25)]
        public string Login { get; set; }
        [Required]
        [StringLength(25), MinLength(6)]
        public string Password { get; set; }
        [RegularExpression("[A-Z][a-z]")]
        public string Country { get; set; }
        [RegularExpression("[A-Z][a-z]")]
        public string City { get; set; }
        [RegularExpression("[A-Z][a-z]")]
        public string Address { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }
    }
}