using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.Models.Enums;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class FacultiesController : ControllerBase
{
    IFacultyService facultyService;

    public FacultiesController(IFacultyService facultyService)
    {
        this.facultyService = facultyService;
    }

    [HttpGet]
    public IEnumerable<ShowFacultyDto> GetAll()
    {
        return this.facultyService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(Guid id)
    {
        try
        {
            return Ok(await this.facultyService.GetOneById(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFacultyDto dto)
    {
        try
        {
            var faculty = await this.facultyService.CreateOne(dto);
            return CreatedAtAction(nameof(GetOne), new { id = faculty.Id }, faculty);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await this.facultyService.DeleteOneById(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("dummy")]
    public async Task<IActionResult> Dummy()
    {
        CreateFacultyDto dto = new CreateFacultyDto()
        {
            FirstName = "Dummy",
            LastName = "Teacher",
            OrganizationId = "696969",
            UserType = UserType.FACULTY
        };

        return await this.Create(dto);
    }
}
