using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpemProject.Models;

[Table("Users")]
public abstract class User
{
    public Guid Id { get; set; }

    [Required]
    public string OrganizationId { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public UserType UserType { get; set; }
}

public class Faculty : User
{

}
