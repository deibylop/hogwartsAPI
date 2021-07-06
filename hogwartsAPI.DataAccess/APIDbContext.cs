using hogwartsAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace hogwartsAPI.DataAccess
{
    public class APIDbContext : DbContext
    {
        public DbSet<FirstAdmission> FirstAdmissions { get; set; }

        public APIDbContext(DbContextOptions<APIDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Entity>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
