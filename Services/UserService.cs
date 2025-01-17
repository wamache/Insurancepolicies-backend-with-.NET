using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public UserService(IUserRepository userRepository, IEmailService emailService, ApplicationDbContext context)
    {
        _userRepository = userRepository;
        _emailService = emailService;
        _context = context;
    }

    public async Task<IActionResult> RegisterUserAsync(RegisterRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
        {
            return new BadRequestObjectResult(new { Error = "Email and Password are required." });
        }

        // Check if user already exists
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (existingUser != null)
        {
            return new ConflictObjectResult(new { Error = "A user with this email already exists." });
        }

        // Hash the password
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        // Create and save the new user
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = hashedPassword,
            IsEmailVerified = false
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        // Send verification email
        await SendVerificationEmailAsync(newUser);

        return new OkObjectResult(new { Message = "Registration successful! Please verify your email." });
    }

    public async Task SendVerificationEmailAsync(User user)
    {
        var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        user.EmailVerificationToken = token;
        user.EmailVerificationTokenExpires = DateTime.UtcNow.AddHours(24);

        // Save changes to the database
        await _userRepository.UpdateUserAsync(user);

        // Generate the verification link
        var verificationLink = $"http://localhost:5138/api/verifyemail/verify-email?token={token}&email={user.Email}";

        // Send email
        var subject = "Verify your email address";
        var body = $"<p>Click the link below to verify your email address:</p><a href='{verificationLink}'>Verify Email</a>";
        await _emailService.SendEmailAsync(user.Email, subject, body);
    }
}
