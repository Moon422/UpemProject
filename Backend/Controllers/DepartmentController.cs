using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Dtos;
using Microsoft.AspNetCore.Mvc;
using UpemProject.Services;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController : ControllerBase
{
    IDepartmentService departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        this.departmentService = departmentService;
    }

    [HttpGet("all")]
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

    [HttpPost("new")]
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
}
