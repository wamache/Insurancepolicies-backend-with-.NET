using System.ComponentModel.DataAnnotations;  // For Required, EmailAddress, MinLength, etc.
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;



public class LoginRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}