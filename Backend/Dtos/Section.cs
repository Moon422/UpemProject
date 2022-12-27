using System;
using Backend.Models.Enums;

namespace Backend.Dtos;

public abstract class SectionDto
{
    public int Number { get; set; }
    public bool Blocked { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public ClassDay ClassDay { get; set; }
    public Semester Semester { get; set; }
    public int Year { get; set; }
    public Guid CourseId { get; set; }
    public Guid FacultyId { get; set; }
    public Guid ClassroomId { get; set; }
}

public class ShowSectionDto : SectionDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdated { get; set; }
}

public class CreatedSectionDto : SectionDto { }
