using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpemProject.Models;

[Table("Schools")]
public class School
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Code { get; set; }

    public List<Department> Departments { get; set; }
}
