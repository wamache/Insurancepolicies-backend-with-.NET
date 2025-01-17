using System.ComponentModel.DataAnnotations;  // For Required, EmailAddress, MinLength, etc.
using Microsoft.EntityFrameworkCore;

public class LoginResponse
{
    public string Token { get; set; }
}