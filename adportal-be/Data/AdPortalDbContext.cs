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
    }
}