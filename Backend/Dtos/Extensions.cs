using System;
using Backend.Models;

using UpemProgram = Backend.Models.Program;

namespace Backend.Dtos;

public static class DtoExtensions
{
    public static ShowSchoolDto ToShowDto(this School school)
    {
        return new ShowSchoolDto()
        {
            Id = school.Id,
            Name = school.Name,
            Code = school.Code
        };
    }

    public static School ToSchool(this CreateSchoolDto dto)
    {
        return new School()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Code = dto.Code,
            CreatedAt = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow
        };
    }

    public static ShowDepartmentDto ToShowDto(this Department department)
    {
        return new ShowDepartmentDto()
        {
            Id = department.Id,
            Name = department.Name,
            SchoolId = department.SchoolId,
            CreatedAt = department.CreatedAt,
            LastUpdated = department.LastUpdated
        };
    }

    public static Department ToDepartment(this CreateDepartmentDto dto)
    {
        return new Department()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            SchoolId = dto.SchoolId
        };
    }

    public static ShowProgramDto ToShowDto(this UpemProgram program)
    {
        return new ShowProgramDto()
        {
            Id = program.Id,
            Name = program.Name,
            Code = program.Code,
            DepartmentId = program.DepartmentId,
            CreatedAt = program.CreatedAt,
            LastUpdated = program.LastUpdated
        };
    }

    public static UpemProgram ToProgram(this CreateProgramDto dto)
    {
        return new UpemProgram()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Code = dto.Code,
            DepartmentId = dto.DepartmentId
        };
    }

    public static ShowCourseDto ToShowDto(this Course course)
    {
        return new ShowCourseDto()
        {
            Id = course.Id,
            Name = course.Name,
            Code = course.Code,
            CreditHours = course.CreditHours,
            ProgramId = course.ProgramId,
            CoOfferedWithId = course.CoOfferedWithId,
            CreatedAt = course.CreatedAt,
            LastUpdated = course.LastUpdated
        };
    }

    public static Course ToCourse(this CreateCourseDto dto)
    {
        return new Course()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Code = dto.Code,
            CreditHours = dto.CreditHours,
            ProgramId = dto.ProgramId,
            CoOfferedWithId = dto.CoOfferedWithId
        };
    }

    public static ShowClassroomDto ToShowDto(this Classroom classroom)
    {
        return new ShowClassroomDto()
        {
            Id = classroom.Id,
            RoomNumber = classroom.RoomNumber,
            Capacity = classroom.Capacity,
            CreatedAt = classroom.CreatedAt,
            LastUpdated = classroom.LastUpdated
        };
    }

    public static Classroom ToClassroom(this CreateClassroomDto dto)
    {
        return new Classroom()
        {
            Id = Guid.NewGuid(),
            RoomNumber = dto.RoomNumber,
            Capacity = dto.Capacity
        };
    }

    public static ShowSectionDto ToShowDto(this Section section)
    {
        return new ShowSectionDto()
        {
            Id = section.Id,
            Number = section.Number,
            Blocked = section.Blocked,
            StartTime = section.StartTime,
            EndTime = section.EndTime,
            ClassDay = section.ClassDay,
            Semester = section.Semester,
            Year = section.Year,
            CreatedAt = section.CreatedAt,
            LastUpdated = section.LastUpdated,
            CourseId = section.CourseId,
            FacultyId = section.FacultyId,
            ClassroomId = section.ClassroomId
        };
    }

    public static Section ToSection(this CreatedSectionDto dto)
    {
        return new Section()
        {
            Id = Guid.NewGuid(),
            Number = dto.Number,
            Blocked = dto.Blocked,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            ClassDay = dto.ClassDay,
            Semester = dto.Semester,
            Year = dto.Year,
            CourseId = dto.CourseId,
            FacultyId = dto.FacultyId,
            ClassroomId = dto.ClassroomId,
        };
    }

    public static ShowFacultyDto ToShowDto(this Faculty faculty)
    {
        return new ShowFacultyDto()
        {
            Id = faculty.Id,
            OrganizationId = faculty.OrganizationId,
            FirstName = faculty.FirstName,
            LastName = faculty.LastName,
            UserType = faculty.UserType,
            CreatedAt = faculty.CreatedAt,
            LastUpdated = faculty.LastUpdated
        };
    }

    public static Faculty ToFaculty(this CreateFacultyDto dto)
    {
        return new Faculty()
        {
            Id = Guid.NewGuid(),
            OrganizationId = dto.OrganizationId,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            UserType = dto.UserType,
        };
    }
}
