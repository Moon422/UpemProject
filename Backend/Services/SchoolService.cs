using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        return this._dbContext.Schools.Select(s => s.ToShowDto());
    }

    public async Task<bool> CreateSchool(CreateSchoolDto dto)
    {
        School school = dto.ToSchool();

        await this._dbContext.Schools.AddAsync(school);

        return await this._dbContext.SaveChangesAsync(true) == 1;
    }
}
