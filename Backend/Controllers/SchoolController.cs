using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Dtos;
using Microsoft.AspNetCore.Mvc;
using UpemProject.Services;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class SchoolController : ControllerBase
{
    private SchoolService _schoolService;

    public SchoolController(SchoolService schoolService)
    {
        this._schoolService = schoolService;
    }

    [HttpGet("all")]
    public IEnumerable<ShowSchoolDto> GetAllSchools()
    {
        return this._schoolService.GetAllSchools();
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateSchool(CreateSchoolDto dto)
    {
        if (await this._schoolService.CreateSchool(dto))
        {
            return Ok("School Created");
        }

        return BadRequest("Failed to add school");
    }
}
