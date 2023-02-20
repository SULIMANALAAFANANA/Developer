using Developer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Developer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Home> Homes { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Partners> Partners { get; set; }
        public DbSet<Contact_Us> Contact_Us { get; set; }

    }
}
