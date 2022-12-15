using System;
using Microsoft.EntityFrameworkCore;
using UpemProject.Models;
using UpemProject.Models.Enums;
using UpemProgram = UpemProject.Models.Program;

namespace UpemProject.Services;

public class UpemDbContext : DbContext
{
    public DbSet<School> Schools { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<UpemProgram> Programs { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Faculty> Faculties { get; set; }


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
        modelBuilder.Entity<Course>(
            entity =>
            {
                entity
                    .HasOne(c => c.CoOfferedWith)
                    .WithMany(c => c.CoOfferedCourses);
            }
        );

        modelBuilder.Entity<User>(
            entity =>
            {
                entity
                    .HasDiscriminator<UserType>("UserType")
                    .HasValue<Faculty>(UserType.FACULTY);
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}
