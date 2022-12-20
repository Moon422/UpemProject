using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos;

public abstract class SchoolDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Code { get; set; }
}

public class CreateSchoolDto : SchoolDto
{

}

public class ShowSchoolDto : SchoolDto
{
    public Guid Id { get; set; }
}
