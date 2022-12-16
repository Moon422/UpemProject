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

    public UpemDbContext(DbContextOptions<UpemDbContext> options) : base(options)
    {

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