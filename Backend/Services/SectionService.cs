using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.Models;

namespace Backend.Services;

public interface ISectionService : ICrudService<Section, Guid, ShowSectionDto, CreatedSectionDto>
{

}

public class SectionService : ISectionService
{
    UpemDbContext dbContext;

    public SectionService(UpemDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<ShowSectionDto> CreateOne(CreatedSectionDto dto)
    {
        var section = dto.ToSection();
        await CrudOperationHelpers.CreateOpeartion(section, this.dbContext, this.dbContext.Sections);
        return section.ToShowDto();
    }

    public async Task DeleteOneById(Guid id)
    {
        await CrudOperationHelpers.DeleteOperation(id, this.dbContext, this.dbContext.Sections);
    }

    public IEnumerable<ShowSectionDto> GetAll()
    {
        return this.dbContext.Sections.Select(s => s.ToShowDto());
    }

    public async Task<ShowSectionDto> GetOneById(Guid id)
    {
        return (await CrudOperationHelpers.GetOneByIdOperation(id, this.dbContext, this.dbContext.Sections)).ToShowDto();
    }
}
