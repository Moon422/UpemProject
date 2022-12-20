using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpemProject.Models;

[Table("Courses")]
public class Course
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(10)]
    public string Code { get; set; }

    [Required]
    public byte CreditHours { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

    [Required]
    public Guid ProgramId { get; set; }
    public Program Program { get; set; }

    public Guid? CoOfferedWithId { get; set; }
    public Course CoOfferedWith { get; set; }

    public List<Course> CoOfferedCourses { get; set; }

    public List<Section> Sections { get; set; }
}
