using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassroomController : ControllerBase
{
    IClassroomService classroomService;

    public ClassroomController(IClassroomService classroomService)
    {
        this.classroomService = classroomService;
    }

    [HttpGet]
    public IEnumerable<ShowClassroomDto> GetAll()
    {
        return this.classroomService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(Guid id)
    {
        try
        {
            return Ok(await this.classroomService.GetOneById(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateClassroomDto dto)
    {
        try
        {
            var classroom = await this.classroomService.CreateOne(dto);
            return CreatedAtAction(nameof(GetOne), new { id = classroom.Id }, classroom);
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
            await this.classroomService.DeleteOneById(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
