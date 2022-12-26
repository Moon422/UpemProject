using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class CoursesController : ControllerBase
{
    ICourseService courseService;

    public CoursesController(ICourseService courseService)
    {
        this.courseService = courseService;
    }

    [HttpGet]
    public IActionResult GetAllCourses()
    {
        return Ok(this.courseService.GetAllCourses());
    }

    [HttpGet("{courseId}")]
    public async Task<IActionResult> GetCourseById(Guid courseId)
    {
        try
        {
            return Ok(await this.courseService.GetCourseById(courseId));
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse(CreateCourseDto dto)
    {
        try
        {
            var courseDto = await this.courseService.CreateCourse(dto);
            return CreatedAtAction(nameof(GetCourseById), new { courseId = courseDto.Id }, courseDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{courseId}")]
    public async Task<IActionResult> DeleteCourseById(Guid courseId)
    {
        try
        {
            await this.courseService.DeleteCourseById(courseId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
