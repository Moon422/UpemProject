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
public class SectionsController : ControllerBase
{
    ISectionService sectionService;

    public SectionsController(ISectionService sectionService)
    {
        this.sectionService = sectionService;
    }

    [HttpGet]
    public IEnumerable<ShowSectionDto> GetAll()
    {
        return this.sectionService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(Guid id)
    {
        try
        {
            return Ok(await this.sectionService.GetOneById(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateOne(CreatedSectionDto dto)
    {
        try
        {
            var section = await this.sectionService.CreateOne(dto);
            return CreatedAtAction(nameof(GetOne), new { id = section.Id }, section);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOne(Guid id)
    {
        try
        {
            await this.sectionService.DeleteOneById(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("dummy")]
    public async Task<IActionResult> CreateDummy()
    {
        CreatedSectionDto dto = new CreatedSectionDto()
        {
            Number = 1,
            Blocked = false,
            StartTime = new TimeOnly(8, 0),
            EndTime = new TimeOnly(9, 30),
            ClassDay = ClassDay.ST,
            Semester = Semester.AUTUMN,
            Year = 2023,
            CourseId = Guid.Parse("418326e2-80e5-4f1e-a306-94d4ccfa0ebf"),
            FacultyId = Guid.Parse("c9675bc3-ade2-4390-ac3d-ac326ef87f5c"),
            ClassroomId = Guid.Parse("389e9210-b94a-4195-85ff-651b295efe25")
        };

        return await this.CreateOne(dto);
    }
}
