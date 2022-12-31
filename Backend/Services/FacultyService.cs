using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.Models;

namespace Backend.Services;

public interface IFacultyService : ICrudService<Faculty, Guid, ShowFacultyDto, CreateFacultyDto>
{
}

public class FacultyService : IFacultyService
{
    UpemDbContext dbContext;

    public FacultyService(UpemDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<ShowFacultyDto> CreateOne(CreateFacultyDto dto)
    {
        var faculty = dto.ToFaculty();
        await CrudOperationHelpers.CreateOpeartion(faculty, this.dbContext, this.dbContext.Faculties);
        return faculty.ToShowDto();
    }

    public async Task DeleteOneById(Guid id)
    {
        await CrudOperationHelpers.DeleteOperation(id, this.dbContext, this.dbContext.Faculties);
    }

    public IEnumerable<ShowFacultyDto> GetAll()
    {
        return this.dbContext.Faculties.Select(f => f.ToShowDto());
    }

    public async Task<ShowFacultyDto> GetOneById(Guid id)
    {
        return (await CrudOperationHelpers.GetOneByIdOperation(id, this.dbContext, this.dbContext.Faculties)).ToShowDto();
    }
}
