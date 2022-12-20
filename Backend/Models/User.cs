using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UpemProject.Models.Enums;

namespace UpemProject.Models;

[Table("Users")]
public abstract class User
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(10)]
    public string OrganizationId { get; set; }

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    public UserType UserType { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
}

public class Faculty : User
{
    public List<Section> Sections { get; set; }
}
