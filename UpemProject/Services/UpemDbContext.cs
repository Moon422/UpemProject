using System;
using Microsoft.EntityFrameworkCore;
using UpemProject.Models;

namespace UpemProject.Services;

public class UpemDbContext : DbContext
{
    public DbSet<School> Schools { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            "server=localhost;user=spms_user;password=hola;database=upem_db",
            new MySqlServerVersion(
                new Version(8, 0, 31)
            )
        );

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<School>(
            entity =>
            {
                entity
                    .Property(s => s.CreatedAt)
                    .HasDefaultValueSql("now()");

                entity
                    .Property(s => s.LastUpdated)
                    .HasDefaultValue("now()");
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}
