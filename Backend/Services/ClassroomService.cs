using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.Models;

namespace Backend.Services;

public interface IClassroomService : ICrudService<Classroom, Guid, ShowClassroomDto, CreateClassroomDto>
{ }

public class ClassroomService : IClassroomService
{
    UpemDbContext dbContext;

    public ClassroomService(UpemDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<ShowClassroomDto> CreateOne(CreateClassroomDto dto)
    {
        var classroom = dto.ToClassroom();
        await CrudOperationHelpers.CreateOpeartion(classroom, this.dbContext, this.dbContext.Classrooms);
        return classroom.ToShowDto();
    }

    public async Task DeleteOneById(Guid id)
    {
        await CrudOperationHelpers.DeleteOperation(id, this.dbContext, this.dbContext.Classrooms);
    }

    public IEnumerable<ShowClassroomDto> GetAll()
    {
        return this.dbContext.Classrooms.Select(c => c.ToShowDto());
    }

    public async Task<ShowClassroomDto> GetOneById(Guid id)
    {
        var classroom = await CrudOperationHelpers.GetOneByIdOperation(id, this.dbContext, this.dbContext.Classrooms);
        return classroom.ToShowDto();
    }
}
