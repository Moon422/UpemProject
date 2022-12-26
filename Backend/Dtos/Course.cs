using System;

namespace Backend.Dtos;

public abstract class CourseDto
{
    public string Name { get; set; }
    public string Code { get; set; }
    public byte CreditHours { get; set; }
    public Guid ProgramId { get; set; }
    public Guid? CoOfferedWithId { get; set; }
}

public class ShowCourseDto : CourseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdated { get; set; }
}

public class CreateCourseDto : CourseDto { }
