using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.Models;

namespace Backend.Services;

public interface ICourseService : ICrudService<Course, Guid, ShowCourseDto, CreateCourseDto>
{
}

public class CourseService : ICourseService
{
    UpemDbContext dbContext;

    public CourseService(UpemDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<ShowCourseDto> GetAll()
    {
        return this.dbContext.Courses.Select(c => c.ToShowDto());
    }

    public async Task<ShowCourseDto> GetOneById(Guid courseId)
    {
        var course = await this.dbContext.Courses.FindAsync(courseId);
        if (course == null)
        {
            throw new KeyNotFoundException($"Course with id {courseId} not found");
        }
        return course.ToShowDto();
    }

    public async Task<ShowCourseDto> CreateOne(CreateCourseDto dto)
    {
        var course = dto.ToCourse();
        await this.dbContext.Courses.AddAsync(course);
        await this.dbContext.SaveChangesAsync();
        return course.ToShowDto();
    }

    public async Task DeleteOneById(Guid courseId)
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
