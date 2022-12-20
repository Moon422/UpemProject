using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos;

public abstract class DepartmentDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public Guid SchoolId { get; set; }
}

public class ShowDepartmentDto : DepartmentDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdated { get; set; }
}

public class CreateDepartmentDto : DepartmentDto
{

}
