using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.Models;

namespace Backend.Services;

public interface ISchoolService : ICrudService<School, Guid, ShowSchoolDto, CreateSchoolDto>
{
}

public class SchoolService : ISchoolService
{
    UpemDbContext dbContext;

    public SchoolService(UpemDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public IEnumerable<ShowSchoolDto> GetAll()
    {
        return this.dbContext.Schools.Select(s => s.ToShowDto());
    }

    public async Task<ShowSchoolDto> GetOneById(Guid schoolId)
    {
        var school = (await this.dbContext.Schools.FindAsync(schoolId)).ToShowDto();
        if (school == null)
        {
            throw new KeyNotFoundException($"School with the following id ${schoolId} not found");
        }
        return school;
    }

    public async Task<ShowSchoolDto> CreateOne(CreateSchoolDto dto)
    {
        School school = dto.ToSchool();
        await this.dbContext.Schools.AddAsync(school);
        await this.dbContext.SaveChangesAsync(true);
        return school.ToShowDto();
    }

    public async Task DeleteOneById(Guid schoolId)
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
