using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpemProject.Models;

[Table("Courses")]
public class Course
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Code { get; set; }

    [Required]
    public byte CreditHours { get; set; }

    [Required]
    public Guid ProgramId { get; set; }
    public Program Program { get; set; }
}
