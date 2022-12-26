using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos;

namespace UpemProject.Services;

public interface IProgramService
{
    IEnumerable<ShowProgramDto> GetAllPrograms();
    Task<ShowProgramDto> GetProgramById(Guid programId);
    Task<ShowProgramDto> CreateProgram(CreateProgramDto dto);
    Task DeleteProgramById(Guid programId);
}

public class ProgramService : IProgramService
{
    UpemDbContext dbContext;

    public ProgramService(UpemDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<ShowProgramDto> GetAllPrograms()
    {
        return this.dbContext.Programs.Select(p => p.ToShowDto());
    }

    public async Task<ShowProgramDto> GetProgramById(Guid programId)
    {
        var program = await this.dbContext.Programs.FindAsync(programId);

        if (program == null)
        {
            throw new KeyNotFoundException($"Program with ${programId} does not exist");
        }

        return program.ToShowDto();
    }

    public async Task<ShowProgramDto> CreateProgram(CreateProgramDto dto)
    {
        var program = dto.ToProgram();
        await this.dbContext.Programs.AddAsync(program);
        await this.dbContext.SaveChangesAsync();
        return program.ToShowDto();
    }

    public async Task DeleteProgramById(Guid programId)
    {
        var program = await this.dbContext.Programs.FindAsync(programId);

        if (program == null)
        {
            throw new KeyNotFoundException($"Program with ${programId} does not exist");
        }

        this.dbContext.Programs.Remove(program);
        await this.dbContext.SaveChangesAsync();
    }
}
