using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Dtos;
using Microsoft.AspNetCore.Mvc;
using Backend.Services;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentsController : ControllerBase
{
    IDepartmentService departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        this.departmentService = departmentService;
    }

    [HttpGet]
    public IEnumerable<ShowDepartmentDto> GetAllDepartments()
    {
        return this.departmentService.GetAllDepartments();
    }

    [HttpGet("{departmentId}")]
    public async Task<IActionResult> GetDepartmentById(Guid departmentId)
    {
        try
        {
            return Ok(await this.departmentService.GetDepartmentById(departmentId));
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment(CreateDepartmentDto dto)
    {
        try
        {
            var deptDto = await this.departmentService.CreateDepartment(dto);
            return CreatedAtAction(nameof(GetDepartmentById), new { departmentId = deptDto.Id }, deptDto);
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("{departmentId}")]
    public async Task<IActionResult> DeleteDepartmentById(Guid departmentId)
    {
        try
        {
            await this.departmentService.DeleteDepartmentById(departmentId);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
