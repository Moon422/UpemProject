using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Models.Enums;

namespace Backend.Models;

[Table("Sections")]
public class Section
{
    public Guid Id { get; set; }

    [Required]
    public int Number { get; set; }

    [Required]
    public bool Blocked { get; set; }

    [Required]
    public TimeOnly StartTime { get; set; }

    [Required]
    public TimeOnly EndTime { get; set; }

    [Required]
    public ClassDay ClassDay { get; set; }

    [Required]
    public Semester Semester { get; set; }

    [Required]
    public int Year { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

    [Required]
    public Guid CourseId { get; set; }
    public Course Course { get; set; }

    [Required]
    public Guid FacultyId { get; set; }
    public Faculty Faculty { get; set; }

    [Required]
    public Guid ClassroomId { get; set; }
    public Classroom Classroom { get; set; }
}
