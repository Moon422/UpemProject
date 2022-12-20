using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpemProject.Models;

[Table("Classrooms")]
public class Classroom
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(15)]
    public string RoomNumber { get; set; }

    [Required]
    public int Capacity { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
}
