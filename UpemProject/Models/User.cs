using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
}

public class Faculty : User
{

}
