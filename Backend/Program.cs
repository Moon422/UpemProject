using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ISchoolService, SchoolService>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IProgramService, ProgramService>();
builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddTransient<IClassroomService, ClassroomService>();
builder.Services.AddTransient<ISectionService, SectionService>();
builder.Services.AddTransient<IFacultyService, FacultyService>();

builder.Services.AddDbContext<UpemDbContext>(
    options =>
    {
        options.UseMySql(
            builder.Configuration.GetConnectionString("MySql"),
            new MySqlServerVersion(
                new Version(8, 0, 31)
            )
        );
    }
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
