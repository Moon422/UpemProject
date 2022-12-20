using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos;
using Microsoft.EntityFrameworkCore;
using UpemProject.Models;

namespace UpemProject.Services;

public interface ISchoolService
{
    IEnumerable<ShowSchoolDto> GetAllSchools();
    Task<ShowSchoolDto> GetSchoolById(Guid schoolId);
    Task<ShowSchoolDto> CreateSchool(CreateSchoolDto dto);
    Task DeleteSchoolById(Guid schoolid);
}

public class SchoolService : ISchoolService
{
    UpemDbContext dbContext;

    public SchoolService(UpemDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<ShowSchoolDto> GetAllSchools()
    {
        return this.dbContext.Schools.Select(s => s.ToShowDto());
    }

    public async Task<ShowSchoolDto> GetSchoolById(Guid schoolId)
    {
        var school = (await this.dbContext.Schools.FindAsync(schoolId)).ToShowDto();
        if (school == null)
        {
            throw new KeyNotFoundException($"School with the following id ${schoolId} not found");
        }
        return school;
    }

    public async Task<ShowSchoolDto> CreateSchool(CreateSchoolDto dto)
    {
        School school = dto.ToSchool();
        await this.dbContext.Schools.AddAsync(school);
        await this.dbContext.SaveChangesAsync(true);
        return school.ToShowDto();
    }

    public async Task DeleteSchoolById(Guid schoolId)
    {
        var school = await this.dbContext.Schools.FindAsync(schoolId);
        if (school == null)
        {
            throw new KeyNotFoundException($"School with id {schoolId} not found");
        }

        this.dbContext.Schools.Remove(school);
        await this.dbContext.SaveChangesAsync();
    }
}
