using System;

namespace Backend.Dtos;

public abstract class SchoolDto
{
    public string Name { get; set; }
    public string Code { get; set; }
}

public class CreateSchoolDto : SchoolDto
{

}

public class ShowSchoolDto : SchoolDto
{
    public Guid Id { get; set; }
}