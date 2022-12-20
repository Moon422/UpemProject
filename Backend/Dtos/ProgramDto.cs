using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos;

public abstract class ProgramDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Code { get; set; }

    [Required]
    public Guid DepartmentId { get; set; }
}

public class ShowProgramDto : ProgramDto
{
    public Guid Id { get; set; }
}

public class CreateProgramDto : ProgramDto
{

}