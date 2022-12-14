using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpemProject.Models;

[Table("Programs")]
public class Program
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Code { get; set; }

    [Required]
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }

    public List<Course> Courses { get; set; }
}