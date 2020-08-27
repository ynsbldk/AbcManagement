using AbcManagement.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbcManagement.DataAccess.Data
{
    public class AbcDbContext : IdentityDbContext<ApplicationUser>
    {
        public readonly ILoggerFactory loggerFactory;     

        public AbcDbContext(DbContextOptions<AbcDbContext> options, ILoggerFactory loggerFacto)
           : base(options)
        {
            this.loggerFactory = loggerFacto;

        }      

        protected override void OnModelCreating(ModelBuilder builder)
        {
        
            base.OnModelCreating(builder);
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer("Server=.;Database=AbcManagement;Trusted_Connection=True;MultipleActiveResultSets=true");           

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Log> Log { get; set; }

    }

}
