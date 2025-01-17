using System.ComponentModel.DataAnnotations;  // For Required, EmailAddress, MinLength, etc.
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


public class RegisterRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}
