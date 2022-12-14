using System;
using Microsoft.EntityFrameworkCore;
using UpemProject.Models;

using UpemProgram = UpemProject.Models.Program;

namespace UpemProject.Services;

public class UpemDbContext : DbContext
{
    public DbSet<School> Schools { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<UpemProgram> Programs { get; set; }
    public DbSet<Course> Courses { get; set; }


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
        base.OnModelCreating(modelBuilder);
    }
}
