using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos;

namespace UpemProject.Services;

public interface IDepartmentService
{
    IEnumerable<ShowDepartmentDto> GetAllDepartments();
    Task<ShowDepartmentDto> GetDepartmentById(Guid departmentId);
    Task<ShowDepartmentDto> CreateDepartment(CreateDepartmentDto dto);
    Task DeleteDepartmentById(Guid departmentId);
}

public class DepartmentService : IDepartmentService
{
    UpemDbContext dbContext;

    public DepartmentService(UpemDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<ShowDepartmentDto> GetAllDepartments()
    {
        return this.dbContext.Departments.Select(d => d.ToShowDto());
    }

    public async Task<ShowDepartmentDto> GetDepartmentById(Guid departmentId)
    {
        var department = await this.dbContext.Departments.FindAsync(departmentId);
        if (department == null)
        {
            throw new KeyNotFoundException($"Department with id {departmentId} not found");
        }
        return department.ToShowDto();
    }

    public async Task<ShowDepartmentDto> CreateDepartment(CreateDepartmentDto dto)
    {
        var department = dto.ToDepartment();
        await this.dbContext.Departments.AddAsync(department);
        await this.dbContext.SaveChangesAsync();
        return department.ToShowDto();
    }

    public async Task DeleteDepartmentById(Guid departmentId)
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
