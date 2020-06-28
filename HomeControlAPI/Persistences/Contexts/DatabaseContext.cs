using HomeControlAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeControlAPI.Persistences.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Device> Device { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Device>().ToTable("device");
            builder.Entity<Device>().HasKey(a => a.Id);
            builder.Entity<Device>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Device>().Property(a => a.Port).IsRequired();
            builder.Entity<Device>().Property(a => a.Status).IsRequired();

            builder.Entity<Device>().HasData(
                new Device { Id = 1, Port = 3, Status = true}    
            );

        }
    }
}
