using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Services;

public interface ICrudService<TModel, TModelId, TShowDto, TCreateDto> where TModel : class
{
    IEnumerable<TShowDto> GetAll();
    Task<TShowDto> GetOneById(TModelId id);
    Task<TShowDto> CreateOne(TCreateDto dto);
    Task DeleteOneById(TModelId id);
}
