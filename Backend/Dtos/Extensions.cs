using System;
using UpemProject.Models;

namespace Backend.Dtos;

public static class DtoExtensions
{
    public static ShowSchoolDto ToShowDto(this School school)
    {
        return new ShowSchoolDto()
        {
            Id = school.Id,
            Name = school.Name,
            Code = school.Code
        };
    }

    public static School ToSchool(this CreateSchoolDto dto)
    {
        return new School()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Code = dto.Code,
            CreatedAt = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow
        };
    }
}