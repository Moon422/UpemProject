using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos;
using UpemProject = Backend.Models.Program;

namespace Backend.Services;

public interface IProgramService : ICrudService<UpemProject, Guid, ShowProgramDto, CreateProgramDto>
{ }

public class ProgramService : IProgramService
{
    UpemDbContext dbContext;

    public ProgramService(UpemDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<ShowProgramDto> CreateOne(CreateProgramDto dto)
    {
        var program = dto.ToProgram();
        await this.dbContext.Programs.AddAsync(program);
        await this.dbContext.SaveChangesAsync();
        return program.ToShowDto();
    }

    public async Task DeleteOneById(Guid id)
    {
        var program = await this.dbContext.Programs.FindAsync(id);

        if (program == null)
        {
            throw new KeyNotFoundException($"Program with ${id} does not exist");
        }

        this.dbContext.Programs.Remove(program);
        await this.dbContext.SaveChangesAsync();
    }

    public IEnumerable<ShowProgramDto> GetAll()
    {
        return this.dbContext.Programs.Select(p => p.ToShowDto());
    }

    public async Task<ShowProgramDto> GetOneById(Guid id)
    {
        var program = await this.dbContext.Programs.FindAsync(id);

        if (program == null)
        {
            throw new KeyNotFoundException($"Program with ${id} does not exist");
        }

        return program.ToShowDto();
    }
}
