using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Services;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class SchoolsController : ControllerBase
{
    ISchoolService schoolService;

    public SchoolsController(ISchoolService schoolService)
    {
        this.schoolService = schoolService;
    }

    [HttpGet]
    public Task<IEnumerable<ShowSchoolDto>> GetAllSchools()
    {
        return Task.FromResult(this.schoolService.GetAll());
    }

    [HttpGet("{schoolId}")]
    public async Task<IActionResult> GetSchoolById(Guid schoolId)
    {
        try
        {
            var school = await this.schoolService.GetOneById(schoolId);
            return Ok(school);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateSchool(CreateSchoolDto schoolDto)
    {
        try
        {
            var school = await this.schoolService.CreateOne(schoolDto);
            return CreatedAtAction(nameof(GetSchoolById), new { schoolId = school.Id }, school);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{schoolId}")]
    public async Task<IActionResult> DeleteSchoolById(Guid schoolId)
    {
        try
        {
            await this.schoolService.DeleteOneById(schoolId);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
