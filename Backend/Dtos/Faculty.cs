using System;
using Backend.Models.Enums;

namespace Backend.Dtos;

public abstract class FacultyDto
{
    public string OrganizationId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserType UserType { get; set; }
}

public class ShowFacultyDto : FacultyDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdated { get; set; }
}

public class CreateFacultyDto : FacultyDto
{

}
