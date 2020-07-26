using System;
using System.Collections.Generic;
using System.Text;
using LAM.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LAM.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Leave> Leave { get; set; }

        public DbSet<LType> LType { get; set; }
    }
}
