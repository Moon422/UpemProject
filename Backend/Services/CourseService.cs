using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos;

namespace Backend.Services;

public interface ICourseService
{
    Task<ShowCourseDto> CreateCourse(CreateCourseDto dto);
    Task DeleteCourseById(Guid courseId);
    IEnumerable<ShowCourseDto> GetAllCourses();
    Task<ShowCourseDto> GetCourseById(Guid courseId);
}

public class CourseService : ICourseService
{
    UpemDbContext dbContext;

    public CourseService(UpemDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<ShowCourseDto> GetAllCourses()
    {
        return this.dbContext.Courses.Select(c => c.ToShowDto());
    }

    public async Task<ShowCourseDto> GetCourseById(Guid courseId)
    {
        var course = await this.dbContext.Courses.FindAsync(courseId);
        if (course == null)
        {
            throw new KeyNotFoundException($"Course with id {courseId} not found");
        }
        return course.ToShowDto();
    }

    public async Task<ShowCourseDto> CreateCourse(CreateCourseDto dto)
    {
        var course = dto.ToCourse();
        await this.dbContext.Courses.AddAsync(course);
        await this.dbContext.SaveChangesAsync();
        return course.ToShowDto();
    }

    public async Task DeleteCourseById(Guid courseId)
    {
        var course = await this.dbContext.Courses.FindAsync(courseId);
        if (course == null)
        {
            throw new KeyNotFoundException($"Course with id {courseId} not found");
        }
        this.dbContext.Courses.Remove(course);
        await this.dbContext.SaveChangesAsync();
    }
}
