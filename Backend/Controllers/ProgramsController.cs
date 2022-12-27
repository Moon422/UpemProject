using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Dtos;
using Microsoft.AspNetCore.Mvc;
using Backend.Services;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ProgramsController : ControllerBase
{
    IProgramService programService;

    public ProgramsController(IProgramService programService)
    {
        this.programService = programService;
    }

    [HttpGet]
    public IEnumerable<ShowProgramDto> GetAllPrograms()
    {
        return this.programService.GetAll();
    }

    [HttpGet("{programId}")]
    public async Task<IActionResult> GetProgramById(Guid programId)
    {
        try
        {
            return Ok(await this.programService.GetOneById(programId));
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateProgram(CreateProgramDto dto)
    {
        try
        {
            var program = await this.programService.CreateOne(dto);
            return CreatedAtAction(nameof(GetProgramById), new { programId = program.Id }, program);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{programId}")]
    public async Task<IActionResult> DeleteProgramById(Guid programId)
    {
        try
        {
            await this.programService.DeleteOneById(programId);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
