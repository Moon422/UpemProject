using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

[Table("Departments")]
public class Department
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    // [Required]
    // [StringLength(6)]
    // public string Code { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

    [Required]
    public Guid SchoolId { get; set; }
    public School School { get; set; }

    public List<Program> Programs { get; set; }
}
