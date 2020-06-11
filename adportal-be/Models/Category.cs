using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adportal_be.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }
    }
}