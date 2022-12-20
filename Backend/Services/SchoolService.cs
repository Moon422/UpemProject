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
    private UpemDbContext _dbContext;

    public SchoolService(UpemDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public IEnumerable<ShowSchoolDto> GetAllSchools()
    {
        return this._dbContext.Schools.Select(s => s.ToShowDto());
    }

    public async Task<ShowSchoolDto> GetSchoolById(Guid schoolId)
    {
        var school = (await this._dbContext.Schools.FindAsync(schoolId)).ToShowDto();

        if (school == null)
        {
            throw new KeyNotFoundException($"School with the following id ${schoolId} not found");
        }

        return school;
    }

    public async Task<ShowSchoolDto> CreateSchool(CreateSchoolDto dto)
    {
        School school = dto.ToSchool();

        await this._dbContext.Schools.AddAsync(school);

        if (await this._dbContext.SaveChangesAsync(true) == 1)
        {
            return school.ToShowDto();
        }

        throw new InvalidOperationException("School creation failed");
    }

    public async Task DeleteSchoolById(Guid schoolId)
    {
        var school = await this._dbContext.Schools.FindAsync(schoolId);
        if (school == null)
        {
            throw new KeyNotFoundException($"School with id {schoolId} not found");
        }

        this._dbContext.Schools.Remove(school);
        if (await this._dbContext.SaveChangesAsync() == 1)
        {
            return;
        }

        throw new InvalidOperationException("Error removing the school");
    }
}
