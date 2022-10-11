using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Travel.Entities;

namespace Travel.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Country>? Countries { get; set; }
        public DbSet<City>? Cities { get; set; }
        public DbSet<TravelModel>? Travels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name= "Rusiya Federasiyası"
                },
                new Country
                {
                    Id = 2,
                    Name = "Türkiyə Cumhuriyyəti"
                },
                new Country
                {
                    Id = 3,
                    Name = "Amerika Birləşmiş Ştatları"
                },
                new Country
                {
                    Id = 4,
                    Name = "İngiltərə"
                }
            );
        }
    }
}
