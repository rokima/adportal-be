using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using adportal_be.Models;

namespace adportal_be.Data
{
    public class AdPortalDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AdType> Types { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}