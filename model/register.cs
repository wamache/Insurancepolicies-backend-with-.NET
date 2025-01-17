using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class User
{
//     public Guid Id { get; set; }
//     public string FirstName { get; set; }
//     public string LastName { get; set; }
//     public string Email { get; set; }
//     public string Password { get; set; }
// }

    public Guid Id { get; set; }
    public required string FirstName { get; set; } = string.Empty;
    public required string LastName { get; set; } = string.Empty;
    public required string Email { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;
    public bool IsEmailVerified { get; set; } = false; // New property
    public string? EmailVerificationToken { get; set; } // Token for verification
    public DateTime? EmailVerificationTokenExpires { get; set; } // Expiry time for the token
}