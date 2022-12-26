using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Dtos;
using Microsoft.AspNetCore.Mvc;
using UpemProject.Services;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ProgramController : ControllerBase
{
    ProgramService programService;

    public ProgramController(ProgramService programService)
    {
        this.programService = programService;
    }

    [HttpGet("all")]
    public IEnumerable<ShowProgramDto> GetAllPrograms()
    {
        return this.programService.GetAllPrograms();
    }

    [HttpGet("{programId}")]
    public async Task<IActionResult> GetProgramById(Guid programId)
    {
        try
        {
            return Ok(await this.programService.GetProgramById(programId));
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("new")]
    public async Task<IActionResult> CreateProgram(CreateProgramDto dto)
    {
        try
        {
            var program = await this.programService.CreateProgram(dto);
            return CreatedAtAction(nameof(GetProgramById), new { programId = program.Id }, program);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    public async Task<IActionResult> DeleteProgramById(Guid programId)
    {
        try
        {
            var program = await this.programService.CreateProgram(dto);
            return CreatedAtAction(nameof(GetProgramById), new { programId = program.Id }, program);
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
