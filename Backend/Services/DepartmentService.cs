using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.Models;

namespace Backend.Services;

public interface IDepartmentService : ICrudService<Department, Guid, ShowDepartmentDto, CreateDepartmentDto>
{
}

public class DepartmentService : IDepartmentService
{
    UpemDbContext dbContext;

    public DepartmentService(UpemDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<ShowDepartmentDto> GetAll()
    {
        return this.dbContext.Departments.Select(d => d.ToShowDto());
    }

    public async Task<ShowDepartmentDto> GetOneById(Guid departmentId)
    {
        var department = await this.dbContext.Departments.FindAsync(departmentId);
        if (department == null)
        {
            throw new KeyNotFoundException($"Department with id {departmentId} not found");
        }
        return department.ToShowDto();
    }

    public async Task<ShowDepartmentDto> CreateOne(CreateDepartmentDto dto)
    {
        var department = dto.ToDepartment();
        await this.dbContext.Departments.AddAsync(department);
        await this.dbContext.SaveChangesAsync();
        return department.ToShowDto();
    }

    public async Task DeleteOneById(Guid departmentId)
    {
        var department = await this.dbContext.Departments.FindAsync(departmentId);
        if (department == null)
        {
            throw new KeyNotFoundException($"Department with id {departmentId} not found");
        }

        this.dbContext.Departments.Remove(department);
        await this.dbContext.SaveChangesAsync();
    }
}
