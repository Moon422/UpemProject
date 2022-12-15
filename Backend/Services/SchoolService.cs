using Backend.Dtos;
using UpemProject.Models;

namespace UpemProject.Services;

public class SchoolService
{
    private UpemDbContext _dbContext;

    public SchoolService(UpemDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public IEnumerable<ShowSchoolDto> GetAllSchools()
    {
        return this._dbContext.Schools.Select(s => s.ToDto());
    }

    public async Task<bool> CreateSchool(CreateSchoolDto dto)
    {
        School school = dto.ToSchool();

        await this._dbContext.Schools.AddAsync(school);

        return await this._dbContext.SaveChangesAsync(true) == 1;
    }
}
